using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services
{
    public class ContactService : IContactService
    {
        private IUserDao user_dao;
        public IUserDao UserDao
        {
            set { user_dao = value; }
            get { return user_dao; }
        }
        private ILog log_service;
        public ILog LogService
        {
            set { log_service = value; }
            get { return log_service; }
        }
        private IHashService hash_service;
        public IHashService HashService
        {
            set { hash_service = value; }
            get { return hash_service; }
        }
        public void SaveMessage(String author, String mail, String message)
        {
            Message msj = new Message(author, mail, message);
            UserDao.SaveUserMessage(msj);

            HashService.ComputeTotalHash(msj);
            LogService.LogOperation("Invitado", "Se guardo un nuevo mensaje de contacto");
        }
    }
}
