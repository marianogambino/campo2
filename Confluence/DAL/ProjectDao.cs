using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public class ProjectDao : BaseDao, IProjectDao
    {
        public Project GetById(long id)
        {
            return (Project) HibernateTemplate.Get(typeof(Project), id);
        }
        public void Persist(Project entity)
        {
            HibernateTemplate.Save(entity);
        }
        public void Update(Project entity)
        {
            HibernateTemplate.Update(entity);
        }
        public void Delete(Project entity)
        {
            HibernateTemplate.Delete(entity);
        }
        public IList<Project> GetAll()
        {
            return FindAllGeneric<Project>("From Project p");
        }
        public IList<Project> GetAllForUser(String user_name)
        {
            return QueryGeneric<Project>("From Project p Where p.Owner.UserAccount.Name = ?", user_name);
        }
        public IList<Project> FindAllByName(String user_name, String name)
        {
            return QueryNamedParams<Project>("From Project p Where p.Owner.UserAccount.Name = :username And p.Name like :name", 
                                                new String[] { "username", "name" }, 
                                                new object[] { user_name, "%"+name+"%" });
        }
        public IList<Language> FindAllLangs()
        {
            return FindAllGeneric<Language>("From Language l");
        }
    }
}
