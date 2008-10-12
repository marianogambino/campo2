using System;
using System.Collections.Generic;
using System.Text;
using Confluence.Domain;

namespace Confluence.Services
{
    public interface IProjectService
    {
        IList<Project> GetAllForUser(String user_name);
        IList<Project> FindByName(String user_name, String name);
        IList<Language> FindAllLangs();
        void Save(String user_name, String project_name, String description, long lang_id, DateTime end_date);
    }
}
