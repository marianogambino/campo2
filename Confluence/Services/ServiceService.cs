using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services
{
    public class ServiceService : IServiceService
    {
        #region properties
        private IServiceDao service_dao;
        public IServiceDao ServiceDao
        {
            set { service_dao = value; }
            get { return service_dao; }
        }
        private IClientDao client_dao;
        public IClientDao ClientDao
        {
            set { client_dao = value; }
            get { return client_dao; }
        }
        #endregion

        public IList<Service> FindServicesForUser(String username)
        {
            return ServiceDao.FindForUser(username);
        }
        public void Delete(long id)
        {
            Service serv = ServiceDao.GetById(id);
            ServiceDao.Delete(serv);
        }
        public IList<Service> FindServicesByName(String username, String name)
        {
            return ServiceDao.GetAllByName(username, name);
        }
        public IList<Language> GetAllLangs()
        {
            return ServiceDao.GetAllLanguages();
        }
        public IList<ServiceType> GetAllSTypes()
        {
            return ServiceDao.GetAllServiceTypes();
        }
        public void Save(String user_name, String name, String desc, long lang_id, long type_id)
        {
            Client client = ClientDao.GetByName(user_name);
            Language lang = ServiceDao.GetLanguageById(lang_id);
            ServiceType type = ServiceDao.GetServiceTypeById(type_id);

            Service service = new Service();
            service.Name = name;
            service.Description = desc;
            service.Supplier = client;
            service.Type = type;
            service.Language = lang;

            ServiceDao.Persist(service);
        }
    }
}
