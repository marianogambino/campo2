using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Confluence.Domain;
using Spring.Data.NHibernate.Support;

namespace Confluence.DAL
{
    public class ServiceDao : BaseDao<Service>, IServiceDao
    {
        public override IList<Service> GetAll()
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
