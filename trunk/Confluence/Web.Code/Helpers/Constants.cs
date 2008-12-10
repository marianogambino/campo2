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
        public const String OFFER_ID = "offer_id";
        public const String RESOURCE_ID = "resource_id";
    }

    public static class Redirects
    {
        public const String HOME = "~/Default.aspx";
        public const String MESSAGED_HOME = HOME + "?" + SessionKeys.MESSAGE + "="; 
        public const String LOGIN = "~/Inicio.aspx";
        public const String MUST_LOGIN = LOGIN + "?" + SessionKeys.INVALID +"=true";
        public const String INTRUDER = "~/Intruso.aspx";
        public const String LIST_USERS = "~/ListarUsuarios.aspx";
        public const String USER_DETAIL = "~/UserDetail.aspx?" + Constants.SessionKeys.USER_ID + "=";
        public const String DELETE_USER = "~/EliminarUser.aspx?" + Constants.SessionKeys.USER_ID + "=";
        public const String SING_UP = "~/Register.aspx";
        public const String LIST_SERVICES = "~/ServiceList.aspx";
        public const String LIST_PROJECTS = "~/ListarProyectos.aspx";
        public const String PROJECT_DETAIL = "~/DetallesProyecto.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String PROJECT_QUESTIONS = "~/PreguntasProyecto.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String ANSWER_QUESTIONS = "~/ResponderPregunta.aspx?" + Constants.SessionKeys.QUESTION_ID + "=";
        public const String PROPOSAL_DETAILS = "~/ProposalDetails.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String ASK_QUESTION = "~/RealizarPregunta.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String MAKE_OFFER = "~/RealizarOferta.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String FAMILY_DETAIL = "~/DetalleFamilia.aspx?" + Constants.SessionKeys.FAMILY_ID + "=";
        public const String FAMILY_LIST = "~/ListarFamilias.aspx";
        public const String USER_PROFILE = "~/UserProfile.aspx";
        public const String CHANGE_PWD = "~/CambiarPass.aspx";
        public const String EDIT_PROFILE = "~/EditarPerfil.aspx";
        public const String OFFER_LIST = "~/ListarOfertas.aspx";
        public const String OFFER_DETAIL = "~/DetallesOferta.aspx?" + Constants.SessionKeys.OFFER_ID + "=";
        public const String RESOURCE_LIST = "~/FindRRHH.aspx";
        public const String RESOURCE_DETAILS = "~/ResourceDetail.aspx?" + Constants.SessionKeys.RESOURCE_ID + "=";
        public const String MAKE_OFFER_TO_RESOURCE = "~/OfferRRHH.aspx?" + Constants.SessionKeys.RESOURCE_ID + "=";
        public const String LIST_RRHH_OFFERS = "~/ListRRHHOffers.aspx";
        public const String DEVELOPER_PROJECT_LIST = "~/ListCurrentProjects.aspx";
        public const String DEVELOPER_PROJECT_DETAILS = "~/DeveloperProjectDetails.aspx?" + Constants.SessionKeys.PROJECT_ID + "=";
        public const String DELIVERY_DATES = "~/DeliveryDates.aspx";
    }

    public static class PageNames
    {
        //Publics
        public const String HOME = "default_aspx";
        public const String USER_PROFILE = "userprofile_aspx";
        public const String CHANGE_PASS = "cambiarpass_aspx";
        public const String EDIT_PROFILE = "editarperfil_aspx";

        //Admin
        public const String LIST_USERS = "listarusuarios_aspx";
        public const String USER_DETAIL = "userdetail_aspx";
        public const String DELETE_USER = "eliminaruser_aspx";
        public const String LIST_FAMILIES = "listarfamilias_aspx";
        public const String NEW_FAMILY = "nuevafamilia_aspx";
        public const String FAMILY_DETAILS = "detallefamilia_aspx";
        public const String ACCESS_LOG = "bitacoraaccesos_aspx";
        public const String OPERATION_LOG = "bitacoraoperaciones_aspx";
        public const String BACK_UP = "realizarbackup_aspx";
        public const String RESTORE_DATA = "restoredata_aspx";

        //Supplier
        public const String LIST_SERVICES = "servicelist_aspx";
        public const String NEW_SERVICE = "nuevoservicio_aspx";
        public const String LIST_PROPOSALS = "listarpropuestas_aspx";
        public const String PROPOSAL_DETAILS = "proposaldetails_aspx";
        public const String ASK_QUESTION = "realizarpregunta_aspx";
        public const String MAKE_OFFER = "realizaroferta_aspx";
        public const String LIST_CURRENT_PROJECTS = "listcurrentprojects_aspx";
        public const String DEVELOPER_PROJECT_DETAILS = "developerprojectdetails_aspx";
        public const String DELIVERY_DATES = "deliverydates_aspx";

        //Demandant
        public const String LIST_PROJECTS = "listarproyectos_aspx";
        public const String NEW_PROJECT = "nuevoproyecto_aspx";
        public const String PROJECT_DETAIL = "detallesproyecto_aspx";
        public const String PUBLICATIONS = "publications_aspx";
        public const String PROJECT_QUESTIONS = "preguntasproyecto_aspx";
        public const String ANSWER_QUESTIONS = "responderpregunta_aspx";
        public const String OFFER_LIST = "listarofertas_aspx";
        public const String OFFER_DETAIL = "detallesoferta_aspx";
        public const String LIST_RRHH = "findrrhh_aspx";
        public const String RESOURCE_DETAIL = "resourcedetail_aspx";
        public const String OFFER_RRHH = "offerrrhh_aspx";
        public const String LIST_RRHHOFFERS = "listrrhhoffers_aspx";

    }
}
