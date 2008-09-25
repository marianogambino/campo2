using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Confluence.Domain;
using Confluence.DAL.Tests.Utils;

namespace Confluence.DAL.Tests
{
    [TestFixture]
    public class FamilyDaoTest : DaoTest
    {
        private IFamilyDao familyDao;

        public IFamilyDao FamilyDao
        {
            get { return familyDao; }
            set { familyDao = value; }
        }

        #region CRUD

        [Test]
        public override void Create()
        {
            Family newFamily = new Family("one", "family");
            newFamily.Patentes.Add(ObjectMother.PatenteGoogle);
            newFamily.Patentes.Add(ObjectMother.PatenteYahoo);
            
            FamilyDao.Persist(newFamily);

            Family persisted = FamilyDao.GetById(newFamily.Id);

            Assert.AreEqual(newFamily,persisted);
            Assert.AreEqual(newFamily.Description,persisted.Description);
            Assert.IsTrue(newFamily.Patentes.Count==2);
            Assert.IsTrue(newFamily.Patentes.Contains(ObjectMother.PatenteGoogle));
            Assert.IsTrue(newFamily.Patentes.Contains(ObjectMother.PatenteYahoo));
        }

        [Test]
        
        [ExpectedException(DUPLICATE_ENTITY)]
        public void DuplicateCreate()
        {
            Family duplicate = new Family("Duplicate", "me");
            FamilyDao.Persist(duplicate);
            FamilyDao.Persist(duplicate);
        }

        [Test]
        public override void Update()
        {
            Family newFamily = new Family("one", "family");
            FamilyDao.Persist(newFamily);
            
            Family persisted = FamilyDao.GetById(newFamily.Id);
            Assert.IsTrue(persisted.Description.Equals("family"));

            persisted.Description = "new description";
            FamilyDao.Update(persisted);

            Family updated = FamilyDao.GetById(newFamily.Id);
            Assert.AreEqual(updated.Description, "new description");
        }

        [Test]
        [ExpectedException(OBJECT_DELETED)]
        public override void Delete()
        {
            Family newFamily = new Family("one", "family");
            FamilyDao.Persist(newFamily);

            Family persisted = FamilyDao.GetById(newFamily.Id);
            Assert.AreEqual(persisted, newFamily);

            long id = persisted.Id;
            FamilyDao.Delete(persisted);

            FamilyDao.GetById(id);
            Assert.Fail("should not reach here");

        }
        #endregion

    }
}
