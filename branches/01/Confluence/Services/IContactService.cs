using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.Services
{
    public interface IContactService
    {
        void SaveMessage(String author, String mail, String message);
    }
}
