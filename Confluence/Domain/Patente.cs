using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Patente
    {
        private int id;
        private String name;
        private String path;

        public Patente() { }

        public Patente(int id, String name, String path)
        {
            Id = id;
            Name = name;
            Path = path;
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
        public String Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
