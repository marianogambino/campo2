using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IHashService
    {
        void ComputeTotalHash(DomainObject obj);
        void ValidateDV();
        void RepairDV();
    }
}
