using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;
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

            Assert.That(user,Is.EqualTo(persisted));
            Assert.That(user.Id, Is.EqualTo(persisted.Id));
            Assert.That(user.Name, Is.EqualTo(persisted.Name));
            Assert.That(user.Mail, Is.EqualTo(persisted.Mail));
            Assert.That(user.Password, Is.EqualTo(persisted.Password));
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
            Assert.That(persisted.Password == updated.Password);
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

            Assert.That(user,Is.EqualTo(persisted));
            Assert.That(user.Password,Is.EqualTo(persisted.Password));

            Assert.That(UserDao.GetByName("GHOST"), Is.Null);
            Assert.That(UserDao.GetByName(user.Password),Is.Null);
        }
        [Test]
        public void PatentsSave() 
        {
            User user = ObjectMother.User;
            user.Patentes.Add(ObjectMother.PatenteYahoo);
            user.Patentes.Add(ObjectMother.PatenteGoogle);
            UserDao.Persist(user);

            User persisted = UserDao.GetById(user.Id);

            Assert.That(persisted.Patentes.Contains(ObjectMother.PatenteGoogle));
            Assert.That(persisted.Patentes.Contains(ObjectMother.PatenteYahoo));
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
            Assert.That(updated.Patentes.Contains(ObjectMother.PatenteGoogle));
            Assert.That(!updated.Patentes.Contains(ObjectMother.PatenteYahoo));
        }
   }
}
