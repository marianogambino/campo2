using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Confluence.DAL;
using System.Collections.Generic;
using System.Data.Common;


[WebServiceBinding]
public class ListarProyectosService : System.Web.Services.WebService
{
    private ConnectionFactory factory;
    public ListarProyectosService()
    {
        factory = ConnectionFactory.GetProductionFactory();
    }

    [WebMethod]
    public ProjectDTO[] ListarProyectos(int user_id)
    {
        List<ProjectDTO> projects = new List<ProjectDTO>();
        factory.UseCommand(delegate(DbCommand cmd)
        {
            cmd.CommandText = "Select p.name, p.date_start, p.date_end, s.name From projects p, projectstates s Where s.id = p.state_id And p.owner_id = " + user_id;
            DbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                projects.Add(new ProjectDTO(reader[0], reader[1], reader[2], reader[3]));
        });
        return projects.ToArray();
    }

    public class ProjectDTO
    {
        private string name;
        private string start;
        private string end;
        private string state;

        public ProjectDTO() { }
        public ProjectDTO(object name, object start, object end, object state)
        {
            Name = name.ToString();
            Start = start.ToString();
            End = end.ToString();
            State = state.ToString();
        }
        public String Name
        {
            set { name = value; }
            get { return name; }
        }
        public String Start
        {
            set { start = value; }
            get { return start; }
        }
        public String End
        {
            set { end = value; }
            get { return end; }
        }
        public String State
        {
            set { state = value; }
            get { return state; }
        }
    }
}

