using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Confluence.Domain;
using Spring.Data.NHibernate.Support;

namespace Confluence.DAL
{
    public class ServiceDao : BaseDao, IServiceDao
    {
        public Service GetById(long id)
        {
            return (Service)HibernateTemplate.Get(typeof(Service), id);
        }
        public void Persist(Service entity)
        {
            HibernateTemplate.Save(entity);
        }
        public void Delete(Service entity)
        {
            HibernateTemplate.Delete(entity);
        }
        public void Update(Service entity)
        {
            HibernateTemplate.Update(entity);
        }
        public IList<Service> GetAll()
        {
            return FindAllGeneric<Service>("FROM Service s");
        }
        public IList<Language> GetAllLanguages()
        {
            return FindAllGeneric<Language>("FROM Language l");
        }
        public IList<ServiceType> GetAllServiceTypes()
        {
            return FindAllGeneric<ServiceType>("FROM ServiceType st");
        }
        public IList<Service> FindForUser(String username)
        {
            return QueryGeneric<Service>("FROM Service s WHERE s.Supplier.UserAccount.Name = ?", username);
        }
        public IList<Service> GetAllByName(String username, String name)
        {
            return QueryNamedParams<Service>("FROM Service s WHERE s.Name like :name AND s.Supplier.UserAccount.Name = :uname",
                                                new String[] { "name", "uname" },
                                                new object[] { "%"+name+"%", username });
        }
    }
}
