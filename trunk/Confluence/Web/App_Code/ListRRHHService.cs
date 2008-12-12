using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Confluence.DAL;
using System.Collections.Generic;
using System.Data.Common;

[WebService]
public class ListRRHHService : System.Web.Services.WebService
{
    private ConnectionFactory factory;

    public ListRRHHService()
    {
        factory = ConnectionFactory.GetProductionFactory();
    }

    [WebMethod]
    public RRHH[] ListRRHH(int user_id)
    {
        List<RRHH> rrhh = new List<RRHH>();
        factory.UseCommand(delegate(DbCommand cmd)
        {
            cmd.CommandText = "Select c.name, c.phone from clients c, proposals p Where p.resource_id = c.id And p.employer_id = " + user_id;
            DbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                rrhh.Add(new RRHH(reader[0], reader[1]));
        });
        return rrhh.ToArray();
    }

    public class RRHH
    {
        private string name;
        private string phone;

        public RRHH() { }
        public RRHH(object name, object phone)
        {
            Name = name.ToString();
            Phone = phone.ToString();
        }
        public String Name
        {
            set { name = value; }
            get { return name; }
        }
        public String Phone
        {
            set { phone = value; }
            get { return phone; }
        }
    }

}

