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
        void Update(long pid, String name, String description, long lang_id, DateTime end,String username);
        IList<Publication> GetAllPublications();
        void Publish(long pid, long publication_id,String username);
        void Delete(long pid,String username);
        IList<Question> FindUnansweredQuestions(long pid);
        Question FindQuestionById(long qid);
        void AnswerQuestion(long pid,long qid, String answer,String username);
        IList<Project> FindAllProposals();
        IList<Project> FindProposalsByName(String name);
        void SaveQuestion(long pid, String question,String username);
        bool CanAccept(long pid);
        void AcceptProject(String developer_name, long pid);
        void MakeOffer(String name,long pid, Double amount, DateTime release_date);
        IList<Offer> FindAllOffersForProject(long id);
        IList<Offer> FindAllOffersForUser(string user_name);
        IList<Project> FindAllAvailableProjects(string user_name);
        Offer FindOfferById(long id);
        void AcceptOffer(long offer_id);
        void RejectOffer(long offer_id);
        IList<Project> FindProjectsForDeveloper(long user_id);
        void EndProject(long pid);
        void CancelProject(long pid);
        void ExportCSV(string user);
    }
}
