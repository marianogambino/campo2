using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using Confluence.DAL;

namespace Confluence.Services
{
    public class AdminService : IAdminService
    {
        #region properties

        private IFamilyDao familyDao;
        public IFamilyDao FamilyDao
        {
            get { return familyDao; }
            set { familyDao = value; }
        }
        private IUserDao userDao;
        public IUserDao UserDao
        {
            get { return userDao; }
            set { userDao = value; }
        }
        #endregion

        public IList<User> FindAllUsers()
        {
            return UserDao.GetAll();
        }

        public User FindUser(long id)
        {
            return UserDao.GetById(id);
        }

        public void UpdateUser(long id, String mail, IList<int> familias, IList<int> patentes)
        {
            User user = UserDao.GetById(id);

            List<Patente> patentes_update = new List<Patente>();
            foreach (int i in patentes)
                patentes_update.Add(new Patente(i, "", ""));

            List<Family> familias_update = new List<Family>();
            foreach (int i in familias)
                familias_update.Add(FamilyDao.GetById(i));

            user.Mail = mail;
            user.Patentes = patentes_update;
            user.Families = familias_update;
            UserDao.Update(user);
        }

        public IList<Patente> FindPatAvailableForUser(long uid)
        {
            return null;
        }

        public IList<Family> FindFamAvailableForUser(long uid)
        {
            return null;
        }
    }
}
