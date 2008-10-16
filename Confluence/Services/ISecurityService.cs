using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Services
{
    public interface ISecurityService
    {
        String GetHash(String plaintext);
    }
}
