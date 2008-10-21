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
            IList<Patente> all = FamilyDao.GetAllPatents();
            User user = UserDao.GetById(uid);
            foreach (Patente pat in user.Patentes)
                if (all.Contains(pat)) all.Remove(pat);
            return all;
        }

        public IList<Family> FindFamAvailableForUser(long uid)
        {
            IList<Family> all = FamilyDao.GetAll();
            User user = UserDao.GetById(uid);
            foreach (Family fam in user.Families)
                if (all.Contains(fam)) all.Remove(fam);
            return all;
        }

        public IList<User> FindUsersLike(String name)
        {
            return UserDao.FindLike(name);
        }
        public void DeleteUser(long id)
        {
            UserDao.Delete(UserDao.GetById(id));
        }
        public void BlockUser(long id)
        {
            User user = UserDao.GetById(id);
            user.Families.Clear();
            user.Patentes.Clear();
            UserDao.Update(user);
        }
        public IList<Family> FindAllFamilies()
        {
            return FamilyDao.GetAll();
        }
        public void DeleteFamily(long id)
        {
            FamilyDao.Delete(FamilyDao.GetById(id));
        }
        public IList<Patente> FindAllPatentes()
        {
            return FamilyDao.GetAllPatents();
        }
        public void CreateFamily(String name, String description, IList<int> patentes)
        {
            Family fam = new Family(name, description);
            foreach (int id in patentes)
                fam.Patentes.Add(new Patente(id,null,null));
            FamilyDao.Persist(fam);
        }
        public bool FamilyExist(String name)
        {
            return (FamilyDao.GetByName(name) != null);
        }
        public IList<Patente> FindPatAvailableForFamily(long family_id)
        {
            IList<Patente> all = FamilyDao.GetAllPatents();
            Family fam = FamilyDao.GetById(family_id);
            foreach (Patente pat in fam.Patentes)
                if (all.Contains(pat)) all.Remove(pat);

            return all;
        }
        public void UpdateFamily(long id, String description, IList<int> patentes)
        {
            Family fam = FamilyDao.GetById(id);
            fam.Description = description;
            fam.Patentes.Clear();
            foreach (int pat_id in patentes)
                fam.Patentes.Add(new Patente(pat_id, null, null));
            FamilyDao.Update(fam);
        }
        public Family FindFamilyById(long id)
        {
            return FamilyDao.GetById(id);
        }

    }
}
