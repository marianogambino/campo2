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
            project.Publication = new Publication(0);
            project.Owner = ClientDao.GetByName(user_name);
            ProjectDao.Persist(project);
        }
        public void Update(long pid, String name, String description, long lang_id, DateTime end)
        {
            Project project = ProjectDao.GetById(pid);
            project.Name = name;
            project.Description = description;
            project.Language = new Language(lang_id);
            project.End = end;
            ProjectDao.Update(project);
        }
        public Project GetById(long id)
        {
            return ProjectDao.GetById(id);
        }
        public IList<Publication> GetAllPublications()
        {
            return ProjectDao.GetAllPublications();
        }
        public void Publish(long pid, long publication_id)
        {
            Project project = GetById(pid);
            project.Publication = new Publication(publication_id);
            ProjectDao.Update(project);
        }
        public void Delete(long pid)
        {
            ProjectDao.Delete(GetById(pid));
        }
        public IList<Question> FindUnansweredQuestions(long id)
        {
            Project project = ProjectDao.GetById(id);
            return project.UnansweredQuestions;
        }
        public Question FindQuestionById(long qid)
        {
            return ProjectDao.GetQuestionById(qid);
        }
        public void AnswerQuestion(long pid, long qid, String answer)
        {
            Question question = ProjectDao.GetQuestionById(qid);
            Project project = ProjectDao.GetById(pid);
            project.AnswerQuestion(question, answer);
            ProjectDao.Update(project);
        }
    }
}
