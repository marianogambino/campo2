using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface IAdminService
    {
        IList<User> FindAll();
    }
}
