using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Confluence.DAL;
using Confluence.Domain;
using Confluence.DAL.Tests.Utils;

namespace Confluence.DAL.Tests
{
    [TestFixture]
    public class UserDaoTest : DaoTest
    {
        #region Properties
        private IUserDao userDao;

        public IUserDao UserDao
        {
            get { return userDao; }
            set { userDao = value; }
        }
        #endregion

        #region CRUD
        [Test]
        public override void Create()
        {
            User user = ObjectMother.User;
            UserDao.Persist(user);
            User persisted = UserDao.GetById(user.Id);

            Assert.AreEqual(user,persisted);
            Assert.AreEqual(user.Id, persisted.Id);
            Assert.AreEqual(user.Name, persisted.Name);
            Assert.AreEqual(user.Mail, persisted.Mail);
            Assert.AreEqual(user.Password, persisted.Password);
        }
        [Test]
        [ExpectedException(DUPLICATE_ENTITY)]
        public void DuplicateCreate()
        {
            User user = ObjectMother.User;
            UserDao.Persist(user);
            UserDao.Persist(user);
        }

        [Test]
        public override void Update()
        {
            User user = ObjectMother.User;
            UserDao.Persist(user);
            User persisted = UserDao.GetById(user.Id);

            persisted.Password = "New Password";
            UserDao.Update(persisted);

            User updated = UserDao.GetById(user.Id);
            Assert.AreEqual(persisted.Password,updated.Password);
        }

        [Test]
        [ExpectedException(OBJECT_DELETED)]
        public override void Delete()
        {
            User user = ObjectMother.User;
            UserDao.Persist(user);
            long id = user.Id;
            UserDao.Delete(user);
            User notFound = UserDao.GetById(id);

            Assert.Fail("previous get should throw " + OBJECT_DELETED);
        }
        #endregion

        [Test]
        public void FindByName()
        {
            User user = ObjectMother.User;
            UserDao.Persist(user);

            User persisted = UserDao.GetByName(user.Name);

            Assert.AreEqual(user,persisted);

            Assert.IsNull(UserDao.GetByName("GHOST"));
            Assert.IsNull(UserDao.GetByName(user.Password));
        }

        [Test]
        public void PatentsSave() 
        {
            User user = ObjectMother.User;
            user.Patentes.Add(ObjectMother.PatenteYahoo);
            user.Patentes.Add(ObjectMother.PatenteGoogle);
            UserDao.Persist(user);

            User persisted = UserDao.GetById(user.Id);

            Assert.IsTrue(persisted.Patentes.Contains(ObjectMother.PatenteGoogle));
            Assert.IsTrue(persisted.Patentes.Contains(ObjectMother.PatenteYahoo));
        }

        [Test]
        public void PatentsDelete()
        {
            User user = ObjectMother.User;
            user.Patentes.Add(ObjectMother.PatenteYahoo);
            user.Patentes.Add(ObjectMother.PatenteGoogle);
            UserDao.Persist(user);

            User persisted = UserDao.GetById(user.Id);
            persisted.Patentes.Remove(ObjectMother.PatenteYahoo);
            UserDao.Update(persisted);

            User updated = UserDao.GetById(user.Id);
            Assert.IsTrue(updated.Patentes.Contains(ObjectMother.PatenteGoogle));
            Assert.IsTrue(!updated.Patentes.Contains(ObjectMother.PatenteYahoo));
        }
        [Test]
        public void FamiliesSave() 
        {
            User user = ObjectMother.User;
            user.Families.Add(ObjectMother.FullFamily);

            UserDao.Persist(user);
            User persisted = UserDao.GetById(user.Id);
            Assert.IsTrue(persisted.Families.Contains(ObjectMother.FullFamily));
            Assert.IsTrue(persisted.Families[0].Patentes.Contains(ObjectMother.PatenteGoogle));
            Assert.IsTrue(persisted.Families[0].Patentes.Contains(ObjectMother.PatenteYahoo));
        }

        [Test]
        public void FamiliesDelete()
        {
            User user = ObjectMother.User;
            user.Families.Add(ObjectMother.FullFamily);
            UserDao.Persist(user);
            User persisted = UserDao.GetById(user.Id);
            persisted.Families.Remove(ObjectMother.FullFamily);
            UserDao.Update(persisted);

            User updated = UserDao.GetById(user.Id);
            Assert.IsFalse(updated.Families.Contains(ObjectMother.FullFamily));
        }
        [Test]
        public void SaveMessage()
        {
            Message msj = new Message("Jhon Bon Jovi", "bonjo@mail.com", "One More Night!");
            UserDao.SaveUserMessage(msj);
            Assert.IsFalse(msj.Id==0);
        }
        [Test]
        public void GetAll()
        {
            IList<User> all = UserDao.GetAll();
            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count > 0);
        }
        [Test]
        public void FindLike()
        {
            IList<User> many = UserDao.FindLike("a");
            Assert.IsNotNull(many);
            Assert.IsTrue(many.Count > 1);
        }
    }
}
