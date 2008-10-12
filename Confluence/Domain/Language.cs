using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Language
    {
        #region properties
        private long id;
        private String name;
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
        #endregion

        public Language() { }

        public override bool Equals(object other)
        {
            if (other is Language)
            {
                return ((Language)other).Name.Equals(Name);
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode(){
            return Name.GetHashCode();
        }
        public override String ToString()
        {
            return Name;
        }
    }
}
