using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Patente
    {
        private int id;
        private String name;
        private String url;

        public Patente() { }

        public Patente(int id)
        {
            Id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        public String Url
        {
            get { return url; }
            set { url = value; }
        }
    }
}
