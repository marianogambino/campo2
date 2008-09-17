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
        public bool hasPatente(int patNumber)
        {
            foreach (Patente pat in Patentes)
                if (pat.Id == patNumber) return true;

            return false;
        }
    }
}
