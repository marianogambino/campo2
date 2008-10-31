using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Service : DomainObject
    {
        #region properties
        private long id;
        private String name;
        private String description;
        private Language language;
        private ServiceType type;
        private Client supplier;
        private long dv;
        
        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        [DV]
        public virtual String Name
        {
            set { name = value; }
            get { return name; }
        }
        [DV]
        public virtual String Description
        {
            set { description = value; }
            get { return description; }
        }
        [DV(Property="Id")]
        public virtual Language Language
        {
            set { language = value; }
            get { return language; }
        }
        [DV(Property="Id")]
        public virtual ServiceType Type
        {
            set { type = value; }
            get { return type; }
        }
        [DV(Property="Id")]
        public virtual Client Supplier
        {
            set { supplier = value; }
            get { return supplier; }
        }
        #endregion

        public Service() { }

        public Service(String name, String description, Language lang, ServiceType type, Client supplier)
        {
            Name = name;
            Description = description;
            Language = lang;
            Type = type;
            Supplier = supplier;
            CalculateDV();
        }
    }
}
