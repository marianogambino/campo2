using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface ILoginService
    {
        User doLogin(String userName, String password);
    }
}
