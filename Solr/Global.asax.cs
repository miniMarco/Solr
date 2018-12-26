using CommonServiceLocator;
using Solr.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Solr
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            

            Startup.Init<ArtigoOriginal>("http://localhost:8983/solr/coreOriginal");
            Startup.Init<Artigo>("http://localhost:8983/solr/core");
            Startup.Init<Artigo2>("http://localhost:8983/solr/core2");
            Startup.Init<Artigo3>("http://localhost:8983/solr/core3");
            Startup.Init<Artigo4>("http://localhost:8983/solr/core4");
            Startup.Init<ArtigoSumarizado>("http://localhost:8983/solr/coreSumarizado");

            /*** Comentar as linhas para não subir mais artigos para o solr ******/

            Operacoes op = new Operacoes(); 
            //op.processarArtigoOriginal();
            //op.processarArtigosC1();
            //op.processarArtigosC2();
            //op.processarArtigosC3();
            //op.processarArtigosC4();  
            op.processarArtigoSumarizado();
        }
    }
}
