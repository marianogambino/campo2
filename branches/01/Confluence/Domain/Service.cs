using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Service
    {
        #region properties
        private long id;
        private String name;
        private String description;
        private Language language;
        private ServiceType type;
        private Client supplier;

        public virtual long Id
        {
            set { id = value; }
            get { return id; }
        }
        public virtual String Name
        {
            set { name = value; }
            get { return name; }
        }
        public virtual String Description
        {
            set { description = value; }
            get { return description; }
        }
        public virtual Language Language
        {
            set { language = value; }
            get { return language; }
        }
        public virtual ServiceType Type
        {
            set { type = value; }
            get { return type; }
        }
        public virtual Client Supplier
        {
            set { supplier = value; }
            get { return supplier; }
        }
        #endregion

        public Service() { }
    }
}
