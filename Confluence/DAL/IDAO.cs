using System;
using System.Collections.Generic;
using System.Text;

namespace Confluence.DAL
{
    public interface IDAO<T>
    {
        T GetById(long id);
        void Persist(T entity);
        void Delete(T entity);
        void Update(T entity);
        IList<T> GetAll();
    }
}
