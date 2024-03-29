using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Confluence.Domain
{
    public abstract class DomainObject
    {
        private long dv;
        public virtual long DV
        {
            set { dv = value; }
            get { return dv; }
        }

        public virtual void CalculateDV()
        {
            long result = 0;
            int index = 1;
            foreach (PropertyInfo p in this.GetType().GetProperties())
            {
                DV att = GetDVAttribute(p);
                if (att != null)
                {
                    if (att.IsComplex())
                    {
                        result += index * GetComplexValue(p, att.Property);
                    }
                    else
                    {
                        result += index * GetSimpleValue(p, this);
                    }
                    index++;
                }
            }
            DV = result;
        }
        private DV GetDVAttribute(PropertyInfo p)
        {
            foreach (Attribute att in p.GetCustomAttributes(false))
                if (att is DV) return (DV)att;
            return null;
        }
        private long GetComplexValue(PropertyInfo p, String property)
        {
            object o = p.GetGetMethod().Invoke(this,null);
            if (o == null) return 0;

            foreach (PropertyInfo prop in o.GetType().GetProperties())
            {
                if (prop.Name.Equals(property))
                    return GetSimpleValue(prop,o);
            }
            throw new NotSupportedException();
        }
        private long GetSimpleValue(PropertyInfo p, object target)
        {
            object o = p.GetGetMethod().Invoke(target,null);
            if (o == null) return 0;

            if (o is long) return (long)o;
            if (o is int) return long.Parse(o.ToString());
            if (o is decimal) return decimal.ToInt32((decimal)o);

            if (o is string) return ((string)o).GetHashCode();
            if (o is double) return ((double)o).GetHashCode();
            if (o is DateTime) return ((DateTime)o).GetHashCode();

            else throw new NotSupportedException();
        }
    }
}
