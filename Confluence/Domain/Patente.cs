using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Patente
    {
        private long id;
        private String name;
        private String path;

        public Patente() { }

        public Patente(int id, String name, String path)
        {
            Id = id;
            Name = name;
            Path = path;
        }

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }
        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
        public virtual String Path
        {
            get { return path; }
            set { path = value; }
        }
        public override bool Equals(object obj)
        {
            if (obj is Patente)
            {
                Patente other = (Patente)obj;
                return other.Id.Equals(Id);
            }
            else
            {
                return false;
            }
            
        }
        public override int GetHashCode()
        {
            return 31 * Id.GetHashCode();
        }
    }
}
