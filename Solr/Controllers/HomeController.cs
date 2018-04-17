using Solr.Models;
using SolrNet;
using SolrNet.Commands.Parameters;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Solr.Controllers
{
    public class HomeController : Controller
    {
        public ISolrOperations<Artigo> solr
        {
            get { return SingleSolr.GetInstance().InstanciaDoSolar; }
        }

        private void formatarResumo(List<Artigo> artigos)
        {
            foreach (Artigo artigo in artigos)
            {
                artigo.SumarioLimitado = artigo.Sumario[0].Substring(0, 500) + "...";
            }
        }

        public ActionResult Index()
        {
            ArtigoView artigosView = new ArtigoView();

            // trás somente o campo "cluster"
            //artigosView.Artigos = solr.Query(SolrQuery.All, new QueryOptions { Fields = new[] { "cluster" } });
            artigosView.Artigos = solr.Query(SolrQuery.All);
            formatarResumo(artigosView.Artigos);

            return View(artigosView);
        }

        [HttpPost]
        public ActionResult Pesquisar(string busca)
        {
            List<Artigo> artigos;
            ArtigoView artigosView = new ArtigoView();

            if (string.IsNullOrEmpty(busca))
            {
                artigos = new List<Artigo>();
            }
            else
            {
                artigos = solr.Query(new SolrQuery("sumario:" + busca));
            }
            artigosView.Artigos = artigos;
            formatarResumo(artigosView.Artigos);
            return View("Index", artigosView);
        }

        public ActionResult PesquisarPorCluster(string key)
        {
            ArtigoView artigosView = new ArtigoView();
            artigosView.Artigos = solr.Query(new SolrQuery("cluster:" + key));
            formatarResumo(artigosView.Artigos);
            return View("Index", artigosView);
        }
    }
}