using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Domain
{
    public class Patente
    {
        public Patente(int id)
        {
            Id = id;
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
