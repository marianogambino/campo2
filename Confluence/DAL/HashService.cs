using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public class HashService : IHashService
    {
        private ConnectionFactory factory = new SQLServerConnectionFactory();

        public void ComputeHashForObject(Type type)
        {

        }
    }
}
