using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services
{
    public class LoginService : ILoginService
    {
        private IUserDao userDao;
        public IUserDao UserDao
        {
            set { userDao = value; }
            get { return userDao; }
        }
        private ISecurityService security_service;
        public ISecurityService SecurityService
        {
            set { security_service = value; }
            get { return security_service; }
        }
        private ILog log;
        public ILog LogService
        {
            set { log = value; }
            get { return log; }
        }
        private IHashService hash_service;
        public IHashService HashService
        {
            set { hash_service = value; }
            get { return hash_service; }
        }
        private IBackUpService backup_service;
        public IBackUpService BackUpService
        {
            set { backup_service = value; }
            get { return backup_service; }
        }
        public LoginService() 
        {
            LogService = new Log();
        }


        public User doLogin(string userName, string pass)
        {
            BackUpService.CheckSchedule();
            User found = UserDao.GetByName(userName);
            //String password = SecurityService.GetHash(pass);

            if (found == null || !found.Password.Equals(pass))
            {
                LogService.LogAccesFailure(userName);
                return null;
            }
            else
            {
                LogService.LogAccess(found);
                return found;
            }
        }
        public void ChangePassword(String username, String password)
        {
            User user = UserDao.GetByName(username);
            user.Password = /*SecurityService.GetHash(*/password/*)*/;
            UserDao.Update(user);

            HashService.ComputeTotalHash(user);
            LogService.LogOperation(username, "El usuario cambio el password");
        }
        public void ValidateDV()
        {
            HashService.ValidateDV();
        }
        public void RepairDV()
        {
            HashService.RepairDV();
        }
    }
}
