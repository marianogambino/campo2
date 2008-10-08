using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Confluence.Services.Tests
{
    [TestFixture]
    public class AdminServiceTest : ServiceTest
    {
        protected IAdminService adminService;
        public IAdminService AdminService
        {
            get { return adminService; }
            set { adminService = value; }
        }
        [Test]
        public void FindAllUsers()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void FindUser()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void UpdateUser()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void FindPatAvailableForUser()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void FindFamAvailableForUser()
        {
            throw new NotImplementedException();
        }
    }
}
