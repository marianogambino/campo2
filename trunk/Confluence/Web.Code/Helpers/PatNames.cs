using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Code.Helpers
{
    public class PatNames
    {
        public static PatNames Instance = new PatNames();
        private IDictionary<String, String> map;

    private PatNames() 
    {
        map = new Dictionary<String, String>();
        //Common
        map.Add("1S", "Iniciar Sesion");
        map.Add("1E", "Login");
        map.Add("2S", "Registrarse");
        map.Add("2E", "Register");
        map.Add("3S", "Contacto");
        map.Add("3E", "Contact");
        map.Add("4S", "Quienes Somos");
        map.Add("4E", "About Confluence");
        map.Add("5S", "Como Funciona");
        map.Add("5E", "How it Works");

        //Admin
        map.Add("101S","Listado de Usuarios");
        map.Add("101E","User List");
        map.Add("102S","Detalle de Usuario");
        map.Add("102E","User Detail");
        map.Add("103S","Eliminar Usuario");
        map.Add("103E","Delete User");
        map.Add("104S","Listado de Familias");
        map.Add("104E","Family List");
        map.Add("105S","Crear Familia");
        map.Add("105E","Create Family");
        map.Add("106S","Editar Familia");
        map.Add("106E","Edit Family");
        map.Add("107S","Bitácora de Accessos");
        map.Add("107E","Access Log");
        map.Add("108S","Bitácora de Operaciones");
        map.Add("108E","Operation Log");
        map.Add("109S","Reparar DV");
        map.Add("109E","Repair DV");
        map.Add("110S","Back Up");
        map.Add("110E","Back Up");
        map.Add("111S","Restaurar");
        map.Add("111E","Restore");

        //Ofertante
        map.Add("201S","Listado de Servicios");
        map.Add("201E","Service List");
        map.Add("202S","Crear Servicio");
        map.Add("202E","Create Service");
        map.Add("203S","Buscar Propuestas");
        map.Add("203E","Find Proposals");
        map.Add("204S","Detalles de Propuesta");
        map.Add("204E","Proposal Details");
        map.Add("205S","Hacer Pregunta por Proyecto");
        map.Add("205E","Ask Project Question");
        map.Add("206S","Realizar Ofertas");
        map.Add("206E","Make Offers");
        map.Add("207S","Listar Proyectos");
        map.Add("207E","Project List");
        map.Add("208S","Detalles de Proyecto");
        map.Add("208E","Project Details");
        map.Add("209S","Fechas de Entrega");
        map.Add("209E","Delivery Dates");
        
        //Demandante
        map.Add("301S","Listado de Proyectos");
        map.Add("301E","Project List");
        map.Add("302S","Crear Proyecto");
        map.Add("302E","Create Project");
        map.Add("303S","Detalles de Proyecto");
        map.Add("303E","Project Details");
        map.Add("304S","Publicar Proyectos");
        map.Add("304E","Publish Projects");
        map.Add("305S","Listar Preguntas de Proyecto");
        map.Add("305E","List Project Questions");
        map.Add("306S","Responder Preguntas de Proyecto");
        map.Add("306E","Answer Project Questions");
        map.Add("307S","Listado de Ofertas");
        map.Add("307E","Offer List");
        map.Add("308S","Detalles de Ofertas");
        map.Add("308E","Offer Details");
        map.Add("309S","Buscar Recursos");
        map.Add("309E","Find Resources");
        map.Add("310S","Detalles de Recurso");
        map.Add("310E","Resource Details");
        map.Add("311S","Realizar Oferta a RRHH");
        map.Add("311E","Make Offer to HHRR");
        map.Add("312S","Listar Ofertas a RRHH");
        map.Add("312E","List HHRR Offers");
    }

    public string get(long pat_id, string culture) 
    {
        string key;
        if (culture.Contains("ñ"))
            key = pat_id.ToString() + "S";
        else
        {
            key = pat_id.ToString() + "E";
        }
        return map[key];
    }




    }
}
