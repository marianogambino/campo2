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
        Project GetById(long id);
        void Update(long pid, String name, String description, long lang_id, DateTime end);
        IList<Publication> GetAllPublications();
        void Publish(long pid, long publication_id);
        void Delete(long pid);
        IList<Question> FindUnansweredQuestions(long pid);
        Question FindQuestionById(long qid);
        void AnswerQuestion(long pid,long qid, String answer);
        IList<Project> FindAllProposals();
        IList<Project> FindProposalsByName(String name);
    }
}
