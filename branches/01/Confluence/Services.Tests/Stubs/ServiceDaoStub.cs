using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services.Tests.Stubs
{
    public class ServiceDaoStub : IServiceDao
    {
        public IList<ServiceType> GetAllServiceTypes(){ return null;}
        public IList<Language> GetAllLanguages() { return null; }
        public void Persist(Service s) { }
        public void Update(Service s) { }
        public void Delete(Service s) { }
        public IList<Service> GetAll() { return null; }
        public Service GetById(long id) { return null; }
        public IList<Service> FindForUser(String name) { return null; }
        public IList<Service> GetAllByName(String name,String name2) { return null; }
        public Language GetLanguageById(long id) { return null; }
        public ServiceType GetServiceTypeById(long id) { return null; }
    }
}
