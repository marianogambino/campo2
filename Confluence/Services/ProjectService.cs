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
        private ILog log_service;
        public ILog LogService
        {
            set { log_service = value; }
            get { return log_service; }
        }
        private IHashService hash_service;
        public IHashService HashService
        {
            set { hash_service = value; }
            get { return hash_service; }
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

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(user_name, "Se creó un nuevo Proyecto: " + project.Name);
        }
        public void Update(long pid, String name, String description, long lang_id, DateTime end,String username)
        {
            Project project = ProjectDao.GetById(pid);
            project.Name = name;
            project.Description = description;
            project.Language = new Language(lang_id);
            project.End = end;
            ProjectDao.Update(project);

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(username, "Se actualizó un Proyecto: " + project.Name);
        }
        public Project GetById(long id)
        {
            return ProjectDao.GetById(id);
        }
        public IList<Publication> GetAllPublications()
        {
            return ProjectDao.GetAllPublications();
        }
        public void Publish(long pid, long publication_id,String username)
        {
            Project project = GetById(pid);
            project.Publication = new Publication(publication_id);
            ProjectDao.Update(project);

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(username, "Se publicó un Proyecto: " + project.Name);
        }
        public void Delete(long pid,String username)
        {
            Project project = GetById(pid);
            ProjectDao.Delete(project);

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(username, "Se eliminó un Proyecto: " + project.Name);
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
        public void AnswerQuestion(long pid, long qid, String answer,String username)
        {
            Question question = ProjectDao.GetQuestionById(qid);
            Project project = ProjectDao.GetById(pid);
            project.AnswerQuestion(question, answer);
            ProjectDao.Update(project);

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(username, "Se respondió una pregunta del Proyecto: " + project.Name);
        }
        public IList<Project> FindAllProposals()
        {
            return ProjectDao.GetAllPublicatedProjects();
        }
        public IList<Project> FindProposalsByName(String name)
        {
            return ProjectDao.FindPublicatedsByName(name);
        }
        public void SaveQuestion(long pid, String question,String username)
        {
            Project project = GetById(pid);
            project.AddQuestion(new Question(question));
            ProjectDao.Update(project);

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(username, "Se realizó una pregunta del Proyecto: " + project.Name);
        }
        public bool CanAccept(long pid)
        {
            Project project = GetById(pid);
            return (project.Developer == null);
        }
        public void AcceptProject(String developer_name, long pid)
        {
            Project project = GetById(pid);
            project.AcceptedBy(ClientDao.GetByName(developer_name));
            ProjectDao.Update(project);

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(developer_name, "Se aceptó un Proyecto: " + project.Name);
        }
        public void MakeOffer(String name, long pid, Double amount, DateTime release_date)
        {
            Project project = GetById(pid);
            Client bidder = ClientDao.GetByName(name);
            project.AddOffer(bidder.MakeOffer(amount,release_date));
            ProjectDao.Update(project);

            HashService.ComputeTotalHash(project);
            LogService.LogOperation(name, "Se realizó una oferta por el Proyecto: " + project.Name);
        }
    }
}
