using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL.Tests.Utils
{
    public class ObjectMother
    {
        public static User User
        {
            get 
            {
                User user = new User("Jhon Doe", "ultra-secret");
                user.Mail = "dummy@confluence.com";
                return user;
            }
        }
    }
}
