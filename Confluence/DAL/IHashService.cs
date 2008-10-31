using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public interface IHashService
    {
        void ComputeHashForObject(Type type);
    }
}
