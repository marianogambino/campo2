using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class User
    {
        private IList<Patente> patentes;

        public IList<Patente> Patentes
        {
            get { return patentes; }
            set { patentes = value; }
        }
        public User()
        {
            patentes = new List<Patente>();
        }
    }
}
