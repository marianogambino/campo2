using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Confluence.Services;
using Confluence.DAL;
using System.Data.Common;
using System.Collections.Generic;

[WebService]
public class ListarUsuariosService : System.Web.Services.WebService
{
    private ConnectionFactory factory;
    public ListarUsuariosService()
    {
        factory = ConnectionFactory.GetProductionFactory();
    }
    [WebMethod]
    public UserDTO[] UserList()
    {
        List<UserDTO> list = new List<UserDTO>();
        factory.UseCommand(delegate(DbCommand cmd){
            cmd.CommandText = "SELECT * FROM clients";
            DbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(new UserDTO(reader[1],reader[2],reader[3],reader[4]));
        });
        return list.ToArray();
    }

    public class UserDTO
    {
        private string name;
        private string country;
        private string phone;
        private string state;

        public UserDTO() { }
        public UserDTO(object name, object country, object state, object phone)
        {
            this.name = name.ToString();
            this.state = state.ToString();
            this.phone = phone.ToString();
            this.country = country.ToString();
        }
        
        public String Name
        {
            set { name = value; }
            get { return name; }
        }
        public String State
        {
            set { state = value; }
            get { return state; }
        }
        public String Phone
        {
            set { phone = value; }
            get { return phone; }
        }
        public String Country
        {
            set { country = value; }
            get { return country; }
        }
        
    }
}


