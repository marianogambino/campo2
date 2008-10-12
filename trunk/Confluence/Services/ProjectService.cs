using System;
using System.Collections.Generic;
using System.Text;
using Confluence.DAL;
using Confluence.Domain;

namespace Confluence.Services
{
    public class ProjectService : IProjectService
    {
        private IProjectDao project_dao;
        private IClientDao client_dao;
        public IProjectDao ProjectDao
        {
            get { return project_dao; }
            set { project_dao = value; }
        }
        public IClientDao ClientDao
        {
            get { return client_dao; }
            set { client_dao = value; }
        }
        public IList<Project> GetAllForUser(String user_name)
        {
            return ProjectDao.GetAllForUser(user_name);
        }
        public IList<Project> FindByName(String user_name, String name)
        {
            return ProjectDao.FindAllByName(user_name, name);
        }
        public IList<Language> FindAllLangs()
        {
            return ProjectDao.FindAllLangs();
        }
        public void Save(String user_name, String project_name, String description, long lang_id, DateTime end_date)
        {
            Project project = new Project();
            project.Name = project_name;
            project.Description = description;
            project.Start = DateTime.Now;
            project.End = end_date;
            project.Language = new Language(lang_id);
            project.State = new ProjectState(1);//Nuevo
            project.Owner = ClientDao.GetByName(user_name);
            ProjectDao.Persist(project);
        }
    }
}
