using Solr.Models;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;

namespace Solr.Controllers
{
    public class HomeController : Controller
    {
        LogSimples log = new LogSimples();
        public ISolrOperations<Artigo> solrCore
        {
            get { return SingleSolr.GetInstance().CoreInstance; }
        }

        public ISolrOperations<Artigo2> solrCore2
        {
            get { return SingleSolr2.GetInstance().Core2Instance; }
        }

        public ActionResult Index()
        {
            ArtigoView artigosView = new ArtigoView();
            return View(artigosView);
        }

        [HttpPost]
        public ActionResult Pesquisar(string busca)
        {
            SolrQueryResults<Artigo> artigos;
            ArtigoView artigosView = new ArtigoView();

            if (string.IsNullOrEmpty(busca))
            {
                artigos = new SolrQueryResults<Artigo>();
            }
            else
            {
                Stopwatch medidor = new Stopwatch();
                medidor.Start();
                artigos = solrCore.Query(montarQuery(busca));
                medidor.Stop();

                log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
            }
            artigosView.Artigos = artigos;
            return View("Index", artigosView);
        }

        [HttpPost]
        public ActionResult Listar(string busca)
        {
            ArtigoView artigosView = new ArtigoView();

            Stopwatch medidor = new Stopwatch();
            medidor.Start();
            artigosView.Artigos = solrCore.Query(SolrQuery.All);
            medidor.Stop();
            log.escreverLog("Pesquisando todos os artigos: " + medidor.Elapsed.ToString());
            return View("Index", artigosView);
        }

        private SolrMultipleCriteriaQuery montarQuery(string busca)
        {
            List<ISolrQuery> lista = new List<ISolrQuery>();
            string[] termos = busca.Split(' ');
            foreach (string termo in termos)
            {
                lista.Add(new SolrQueryByField("sumario", termo));
            }
            return new SolrMultipleCriteriaQuery(lista);
        }

        public ActionResult PesquisarPorCluster(string key)
        {
            ArtigoView artigosView = new ArtigoView();
            Stopwatch medidor = new Stopwatch();
            medidor.Start();
            artigosView.Artigos = solrCore.Query(new SolrQuery("cluster:" + key));
            medidor.Stop();
            log.escreverLog("Pesquisa por cluster: " + medidor.Elapsed.ToString());

            return View("Index", artigosView);
        }
    }
}