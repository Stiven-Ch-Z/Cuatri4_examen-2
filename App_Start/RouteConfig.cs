using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace BibliotecaMVC
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.MapPageRoute(//ruta que apunto la pagina web
                    routeName: "RegistrarLibros",//nombre interni
                    routeUrl: "libros/registrar",//url
                    physicalFile: "~/Views/Libros/Registrar.aspx"//pagina fisica
                );
            routes.MapPageRoute(//ruta que apunto la pagina web
                    routeName: "ConsultarLibros",//nombre interni
                    routeUrl: "libros/consultar",//url
                    physicalFile: "~/Views/Libros/Consultar.aspx"//pagina fisica
                );
            routes.MapPageRoute(//ruta que apunto la pagina web
                    routeName: "VerDetallesLibros",//nombre interni
                    routeUrl: "libros/detalles{codigo}",//url
                    physicalFile: "~/Views/Libros/Detalles.aspx"//pagina fisica
                );
        }
    }
}
