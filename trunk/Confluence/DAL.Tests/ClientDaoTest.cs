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
        public override void Delete()
        {
            Client client = new Client("Pablo", "Secret", "Pablo Fernandez", "Argentina");
            ClientDao.Persist(client);
            Assert.AreEqual(ClientDao.GetAll().Count, 1);
            ClientDao.Delete(client);
            Assert.AreEqual(ClientDao.GetAll().Count, 0);
        }

        [Test]
        public override void Update()
        {
            Client client = new Client("Pablo", "Secret", "Pablo Fernandez", "Argentina");
            ClientDao.Persist(client);
            Assert.AreEqual(ClientDao.GetAll().Count, 1);
            client.Phone = 123;
            client.State = "estado!";
            ClientDao.Update(client);
            Client found = ClientDao.GetById(client.Id);
            Assert.AreEqual(123, found.Phone);
            Assert.AreEqual("estado!", found.State);
        }
    }
}
