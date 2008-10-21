using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Confluence.Domain;

namespace Confluence.DAL.Tests
{
    [TestFixture]
    public class ServiceDaoTest : DaoTest
    {
        private IServiceDao service_dao;

        public IServiceDao ServiceDao
        {
            get { return service_dao; }
            set { service_dao = value; }
        }

        #region CRUD

        [Test]
        public override void Create()
        {
            Service service = new Service();
            Client supp = new Client();
            supp.Id = 19;
            service.Supplier = supp;
            service.Language = new Language();
            service.Name = "Oferton";
            service.Description = "mas de mas";
            service.Type = new ServiceType();
            ServiceDao.Persist(service);

            Assert.IsNotNull(ServiceDao.GetById(service.Id));
        }

        [Test]
        public override void Update()
        {
            Service service = new Service();
            Client supp = new Client();
            supp.Id = 19;
            service.Supplier = supp;
            service.Language = new Language();
            service.Name = "Oferton";
            service.Description = "mas de mas";
            service.Type = new ServiceType();
            ServiceDao.Persist(service);

            service.Description = "Changed";
            ServiceDao.Update(service);

            Assert.AreEqual("Changed", ServiceDao.GetById(service.Id).Description);
        }

        [Test]
        [ExpectedException(OBJECT_DELETED)]
        public override void Delete()
        {
            Service service = new Service();
            Client supp = new Client();
            supp.Id = 19;
            service.Supplier = supp;
            service.Language = new Language();
            service.Name = "Oferton";
            service.Description = "mas de mas";
            service.Type = new ServiceType();
            ServiceDao.Persist(service);

            Assert.IsNotNull(ServiceDao.GetById(service.Id));
            ServiceDao.Delete(service);
            ServiceDao.GetById(service.Id);
            Assert.Fail("Should throw ex in previous line");
        }
        #endregion

        [Test]
        public void FindAllLanguages() 
        {
            IList<Language> langs = ServiceDao.GetAllLanguages();
            Language beauty = new Language();
            beauty.Name = "Ruby";
            beauty.Id = 55555;
            Assert.IsTrue(langs.Contains(beauty));
        }
        [Test]
        public void FindAllServiceTypes()
        {
            IList<ServiceType> types = ServiceDao.GetAllServiceTypes();
            ServiceType hard = new ServiceType();
            hard.Description = "Hardware";
            Assert.IsTrue(types.Contains(hard));
        }
        [Test]
        public void GetAll()
        {
            IList<Service> servs = ServiceDao.GetAll();
            Assert.IsNotNull(servs);
            Assert.IsTrue(servs.Count >= 0);
        }
        [Test]
        public void FindForUser()
        {
            IList<Service> servs = ServiceDao.FindForUser("Pablo");
            Assert.IsNotNull(servs);
            Assert.IsTrue(servs.Count > 0);
        }
        [Test]
        public void FindByName()
        {
            IList<Service> servs = ServiceDao.GetAllByName("Pablo", "rollo");
            Assert.IsNotNull(servs);
            Assert.IsTrue(servs.Count > 0);
        }
    }
}
