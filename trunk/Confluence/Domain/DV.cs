using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class DV : Attribute
    {
        public String Property = "";

        public bool IsComplex()
        {
            return Property != "";
        }
    }
}
