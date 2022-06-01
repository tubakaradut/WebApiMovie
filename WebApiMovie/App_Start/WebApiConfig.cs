using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiMovie
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //***********************************************************************
            //eğer dışarıda bulunan bir api projesine istekte bulunduğumuzda 'Acces-Control-Allow-Origin' hatası alırsak api projesinin oldugu yerdeki projeye nuget package manager'den Microsoft.AspNet.Cors kütüphanesi kurularal izinler verilir.ve buraya webapiconfig'e cors tanımlanır

            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors(cors);  (* bütün sayfalara, bütün headerlara, bütün metotlara izin ver anlamında )



            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();



            //***************************************************************************
            //dısarıdan parametre alarak arama yapmak istediğimizde url (normalde id ile aranıyor) olarak yolu bulamayacağı için yeni bir maproute yazılır.

            config.Routes.MapHttpRoute(
               name: "SearchMovie",
               routeTemplate: "api/movies/{param}", new { controller = "movies", action = "GetSearchMovie"});


            //****************************************************************************
            //projede birden fazla get metodu kullanıldığında hata verdiği için  maproutekısmına controllerin yanına {action} eklenir.

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );



            
        }
    }
}
