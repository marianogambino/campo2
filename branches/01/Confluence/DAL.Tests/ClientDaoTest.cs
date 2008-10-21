using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using NUnit.Framework;

namespace Confluence.DAL.Tests
{
    [TestFixture]
    public class ClientDaoTest : DaoTest
    {
        private IClientDao client_dao;
        public IClientDao ClientDao
        {
            set { client_dao = value; }
            get { return client_dao; }
        }
        [Test]
        public override void Create()
        {
            Client client = new Client("PabloDos", "Secret", "Pablo Fernandez", "Argentina");
            ClientDao.Persist(client);
            Client found = ClientDao.GetById(client.Id);
            Assert.AreEqual(found, client);
        }
        [Test]
        [ExpectedException(DUPLICATE_ENTITY)]
        public void Duplicate()
        {
            Create();
            Create();
        }

        [Test]
        public override void Delete()
        {
            Client client = new Client("Unexistent", "Secret", "Pablo Fernandez", "Argentina");
            ClientDao.Persist(client);
            Assert.IsNotNull(ClientDao.GetByName("Unexistent"));
            ClientDao.Delete(client);
            Assert.IsNull(ClientDao.GetByName("Unexistent"));
        }

        [Test]
        public override void Update()
        {
            Client client = new Client("Unexistent", "Secret", "Pablo Fernandez", "Argentina");
            ClientDao.Persist(client);
            Assert.IsNotNull(ClientDao.GetByName("Unexistent"));
            client.Phone = 123;
            client.State = "estado!";
            ClientDao.Update(client);
            Client found = ClientDao.GetByName("Unexistent");
            Assert.AreEqual(123, found.Phone);
            Assert.AreEqual("estado!", found.State);
        }
    }
}
