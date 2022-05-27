using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Test_1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Configuration et services API Web

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
            name: "auth_visiteur",
            routeTemplate: "api/Authentification/verification_objVisiteur/{slogin}/{smdp}",
            defaults: new { controller = "Authentification", action = "verification_objVisiteur" }
            );

            config.Routes.MapHttpRoute(
            name: "auth_chef",
            routeTemplate: "api/Authentification/verification_objChef/{slogin}/{smdp}",
            defaults: new { controller = "Authentification", action = "verification_objChef" }
            );

            config.Routes.MapHttpRoute(
            name: "Create_presenter",
            routeTemplate: "api/Medicament/CreatePresenter/{sId_med}/{sId_visit}/{sId_medecin}/{sMonth}",
            defaults: new { controller = "Medicament", action = "CreatePresenter" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { sid = RouteParameter.Optional, slibelle = RouteParameter.Optional, smontant = RouteParameter.Optional }
            );
        }
    }
}
