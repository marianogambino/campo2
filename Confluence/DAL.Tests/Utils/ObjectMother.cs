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
        public static Patente PatenteGoogle
        {
            get 
            {
                return new Patente(0, "Google", "www.google.com");
            }
        }
        public static Patente PatenteYahoo
        {
            get
            {
                return new Patente(1, "Yahoo", "www.yahoo.com");
            }
        }
        public static Family FullFamily
        {
            get
            {
                Family ret = new Family("Full", "Two Patente Family");
                ret.Patentes.Add(PatenteGoogle);
                ret.Patentes.Add(PatenteYahoo);
                return ret;
            }
        }
        public static Family EmptyFamily
        {
            get {return new Family("Adams", "Adams Family");}
        }
    }
}
