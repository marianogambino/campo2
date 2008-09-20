using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public interface DAO<T>
    {
        T GetById(long id);
        void Persist(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
