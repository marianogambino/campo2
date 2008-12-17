using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IFamilyDao :IDAO<Family>
    {
        IList<Patente> GetAllPatents();
        Family GetByName(String name);
        IList<Patente> GetAllForAssign();
    }
}
