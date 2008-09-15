using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Services
{
    public interface ILoginService
    {
        bool doLogin(String userName, String password);
    }
}
