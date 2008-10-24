using System;
using System.Data;
using System.Configuration;

public static class Constants
{
    public static class SessionKeys
    {
        /*FOR USER LOGGED IN*/
        public const String USER = "user";
        /*FOR FAILED LOGIN ATTEMPTS*/
        public const String FAILED = "fallidos";
        /*FOR INVALID ACCESS (SEE BELOW)*/
        public const String INVALID = "invalid";
        public const String USER_ID = "user_id";
        public const String MESSAGE = "info";
        public const String PROJECT_ID = "project_id";
        public const String QUESTION_ID = "question_id";
        public const String FAMILY_ID = "family_id";
    }

    public static class Redirects
    {
        public const String HOME = "~/Default.aspx";
        public const String MESSAGED_HOME = HOME + "?" + SessionKeys.MESSAGE + "="; 
        public const String LOGIN = "~/Login.aspx";
        public const String MUST_LOGIN = LOGIN + "?" + SessionKeys.INVALID +"=true";
        public const String INTRUDER = "~/Intruder.aspx";
        public const String LIST_USERS = "~/ListUsers.aspx";
        public const String USER_DETAIL = "~/UserDetail.aspx?" + Constants.SessionKeys.USER_ID + "=";
        public const String DELETE_USER = "~/DeleteUser.aspx?" + Constants.SessionKeys.USER_ID + "=";
        public const String SING_UP = "~/Register.aspx";
        public const String LIST_SERVICES = "~/ServiceList.aspx";
        public const String LIST_PROJECTS = "~/ListProjects.aspx";
        public const String PROJECT_DETAIL = "~/ProjectDetails.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String PROJECT_QUESTIONS = "~/ProjectQuestions.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String ANSWER_QUESTIONS = "~/AnswerQuestions.aspx?" + Constants.SessionKeys.QUESTION_ID + "=";
        public const String PROPOSAL_DETAILS = "~/ProposalDetails.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String ASK_QUESTION = "~/AskQuestion.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String MAKE_OFFER = "~/MakeOffer.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String FAMILY_DETAIL = "~/FamilyDetail.aspx?" + Constants.SessionKeys.FAMILY_ID + "=";
        public const String FAMILY_LIST = "~/ListFamilies.aspx";
        public const String USER_PROFILE = "~/UserProfile.aspx";
        public const String CHANGE_PWD = "~/ChangePass.aspx";
        public const String EDIT_PROFILE = "~/EditProfile.aspx";
    }

    public static class PageNames
    {
        //Publics
        public const String HOME = "default_aspx";
        public const String USER_PROFILE = "userprofile_aspx";
        public const String CHANGE_PASS = "changepass_aspx";
        public const String EDIT_PROFILE = "editprofile_aspx";

        //Admin
        public const String LIST_USERS = "listusers_aspx";
        public const String USER_DETAIL = "userdetail_aspx";
        public const String DELETE_USER = "deleteuser_aspx";
        public const String LIST_FAMILIES = "listfamilies_aspx";
        public const String NEW_FAMILY = "newfamily_aspx";
        public const String FAMILY_DETAILS = "familydetail_aspx";

        //Supplier
        public const String LIST_SERVICES = "servicelist_aspx";
        public const String NEW_SERVICE = "newservice_aspx";
        public const String LIST_PROPOSALS = "listproposals_aspx";
        public const String PROPOSAL_DETAILS = "proposaldetails_aspx";
        public const String ASK_QUESTION = "askquestion_aspx";
        public const String MAKE_OFFER = "makeoffer_aspx";

        //Demandant
        public const String LIST_PROJECTS = "listprojects_aspx";
        public const String NEW_PROJECT = "newproject_aspx";
        public const String PROJECT_DETAIL = "projectdetails_aspx";
        public const String PUBLICATIONS = "publications_aspx";
        public const String PROJECT_QUESTIONS = "projectquestions_aspx";
        public const String ANSWER_QUESTIONS = "answerquestions_aspx";

    }
}
