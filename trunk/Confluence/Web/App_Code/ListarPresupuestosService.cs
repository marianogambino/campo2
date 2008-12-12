using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Confluence.DAL;
using System.Collections.Generic;
using System.Data.Common;

[WebService]
public class ListarPresupuestosService : System.Web.Services.WebService
{
    private ConnectionFactory factory;

    public ListarPresupuestosService()
    {
        factory = ConnectionFactory.GetProductionFactory();
    }

    [WebMethod]
    public ProposalDTO[] ListarPresupuestos(int project_id)
    {
        List<ProposalDTO> props = new List<ProposalDTO>();
       factory.UseCommand(delegate(DbCommand cmd)
       {
           cmd.CommandText = "Select c.name, o.amount, u.email from users u, clients c, offers o Where c.user_account = u.id And o.bidder_id = c.id And o.project_id = " + project_id;
           DbDataReader reader = cmd.ExecuteReader();
           while (reader.Read())
               props.Add(new ProposalDTO(reader[0],reader[1],reader[2]));
       });
       return props.ToArray();
    }

    public class ProposalDTO
    {
        private string name;
        private string amount;
        private string email;
        public ProposalDTO() { }
        public ProposalDTO(object name, object amount, object email)
        {
            Name = name.ToString();
            Amount = amount.ToString();
            Email = amount.ToString();
        }
        public String Name
        {
            set { name = value; }
            get { return name; }
        }
        public String Amount
        {
            set { amount = value; }
            get { return amount; }
        }
        public String Email
        {
            set { email = value; }
            get { return email; }
        }
    }

}

