using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Family : DomainObject
    {
        private long id;
        private String name;
        private String description;
        private IList<Patente> patentes;
        public Family() 
        {
            Patentes = new List<Patente>();
        }

        public Family(String name, String description)
            : this()
        {
            Name = name;
            Description = description;
        }

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }


        public virtual IList<Patente> Patentes
        {
            get { return patentes; }
            set { patentes = value; }
        }
        [DV]
        public virtual String Name
        {
            get { return name; }
            set { name = value; }
        }
        [DV]
        public virtual String Description
        {
            set { description = value; }
            get { return description; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Family)
            {
                Family other = (Family)obj;
                return other.Name.Equals(Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return 31 * this.Name.GetHashCode();
        }
    }
}
