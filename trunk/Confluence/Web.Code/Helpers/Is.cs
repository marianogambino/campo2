using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Code.Helpers
{
    public static class Is
    {
        public static bool EmptyString(string value)
        {
            return (value.Trim().Length == 0);
        }
    }
}
