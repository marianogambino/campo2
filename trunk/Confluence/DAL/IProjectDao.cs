using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.DAL
{
    public interface IProjectDao : IDAO<Project>
    {
        IList<Project> GetAllForUser(String user_name);
        IList<Project> FindAllByName(String user_name, String name);
        IList<Language> FindAllLangs();
        IList<Publication> GetAllPublications();
        Question GetQuestionById(long qid);
    }
}
