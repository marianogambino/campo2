using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Web.Code.Helpers;
using Confluence.Domain;

namespace Confluence.Services.Tests.Stubs
{
    public class FamilyDaoStub : IFamilyDao
    {

        public Family GetById(long id)
        {
            return new Family("name", "description");
        }

        public void Persist(Family entity)
        {
           //persisted
        }

        public void Delete(Family entity)
        {
            //deleted
        }

        public void Update(Family entity)
        {
            //updated
        }

        public IList<Family> GetAll()
        {
            List<Family> fams = new List<Family>();
            fams.Add(new Family("bla", "Bla"));
            fams.Add(new Family("bla2", "Bla4"));
            fams.Add(new Family("bla3", "Bla5"));
            return fams;
        }

        public Family GetByName(string name)
        {
            return new Family(name, "algo");
        }
        public IList<Patente> GetAllPatents()
        {
            List<Patente> pats = new List<Patente>();
            pats.Add(new Patente(1, "hola", "mundo"));
            pats.Add(new Patente(2, "hola", "mundo"));
            return pats;
        }
        public bool HasRelations(long id)
        {
            return (id == 0);
        }
    }
}
