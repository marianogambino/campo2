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
        private ILog log_service;
        public ILog LogService
        {
            set { log_service = value; }
            get { return log_service; }
        }
        private IHashService hash_service;
        public IHashService HashService
        {
            set { hash_service = value; }
            get { return hash_service; }
        }
        #endregion

        public IList<Service> FindServicesForUser(String username)
        {
            return ServiceDao.FindForUser(username);
        }
        public void Delete(long id,String username)
        {
            Service serv = ServiceDao.GetById(id);
            ServiceDao.Delete(serv);

            HashService.ComputeTotalHash(serv);
            LogService.LogOperation(username, "Se eliminó el Servicio: " + serv.Name);
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
            Language lang = new Language(lang_id);
            ServiceType type = new ServiceType(type_id);

            Service service = new Service(name,desc,lang,type,client);

            ServiceDao.Persist(service);

            HashService.ComputeTotalHash(service);
            LogService.LogOperation(user_name, "Se creó el Servicio: " + service.Name);
        }
    }
}
