using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;
using NUnit.Framework;

namespace Confluence.DAL.Tests
{
    [TestFixture]
    public class ProjectDaoTest : DaoTest
    {
        #region properties & SetUp
        private Project prj;
        private IProjectDao project_dao;
        public IProjectDao ProjectDao
        {
            set { project_dao = value; }
            get { return project_dao; }
        }
        public void Creation()
        {
            prj = new Project();
            Language lang = new Language();
            lang.Id = 1;
            ProjectState state = new ProjectState();
            state.Id = 2;
            Client cl = new Client();
            cl.Id = 17;
            prj.Name = "Proyecto";
            prj.Start = DateTime.Now;
            prj.End = DateTime.Now;
            prj.State = state;
            prj.Language = lang;
            prj.Owner = cl;
        }
        #endregion

        [Test]
        public override void Create() 
        {
            Creation();
            Assert.AreEqual(0, prj.Id);
            ProjectDao.Persist(prj);
            Project found = ProjectDao.GetById(prj.Id);
            Assert.AreEqual(found.Name, prj.Name);
        }
        [Test]
        public override void Update() 
        {
            Creation();
            Assert.AreEqual(0, prj.Id);
            ProjectDao.Persist(prj);
            
            Project found = ProjectDao.GetById(prj.Id);
            Assert.AreEqual(found.Name, prj.Name);
            
            prj.Name = "other";
            ProjectDao.Update(prj);

            found = ProjectDao.GetById(prj.Id);
            Assert.AreEqual(found.Name, "other");

        }
        [Test]
        [ExpectedException(OBJECT_DELETED)]
        public override void Delete() 
        {
            Creation();
            Assert.AreEqual(0, prj.Id);
            ProjectDao.Persist(prj);
            Project found = ProjectDao.GetById(prj.Id);
            Assert.AreEqual(found.Name, prj.Name);

            ProjectDao.Delete(prj);
            found = ProjectDao.GetById(prj.Id);
        }
        [Test]
        public void GetAll()
        {
            IList<Project> all = ProjectDao.GetAll();
            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count > 0);
        }
        [Test]
        public void GetAllForUser()
        {
            IList<Project> all = ProjectDao.GetAllForUser("Pablo");
            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count > 0);
        }
        [Test]
        public void FindAllByName()
        {
            IList<Project> all = ProjectDao.FindAllByName("Pablo","fluen");
            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count > 0);
        }
        [Test]
        public void FindAllLangs()
        {
            IList<Language> all = ProjectDao.FindAllLangs();
            Assert.IsNotNull(all);
            Assert.IsTrue(all.Count > 0);
        }
    }
}
