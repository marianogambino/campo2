using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class ServiceType
    {
        #region properties
        private long id;
        private String description;
        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }
        public virtual String Description
        {
            set { description = value; }
            get { return description; }
        }
        #endregion

        public ServiceType() { }
        
        public override bool Equals(object other)
        {
            if (other is ServiceType)
            {
                return ((ServiceType)other).Description.Equals(Description);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return Description.GetHashCode();
        }
    }
}
