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

        [Test]
        public void NewUser()
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
   }
}
