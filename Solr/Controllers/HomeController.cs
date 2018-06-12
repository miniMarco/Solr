using Solr.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Linq;

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

        public ISolrOperations<Artigo3> solrCore3
        {
            get { return SingleSolr3.GetInstance().Core3Instance; }
        }



        public ActionResult Index()
        {
            
            ViewBag.CoreId = new SelectList(new Core().ListaCores(), "CoreId", "Nome");
            ArtigoView artigosView = new ArtigoView();
            return View(artigosView);
        }

        [HttpPost]
        public ActionResult Pesquisar(string busca, int CoreId)
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
                SolrMultipleCriteriaQuery query = montarQuery(busca);

                medidor.Start();
                artigos = solrCore.Query(query);
                medidor.Stop();

                log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
            }
            
            artigosView.Artigos = formatarLista(artigos);
            ViewBag.CoreId = new SelectList(new Core().ListaCores(), "CoreId", "Nome");
            return View("Index", artigosView);
        }

        private SolrQueryResults<ArtigoCore> formatarLista<T>(SolrQueryResults<T> artigos) where T : ArtigoCore
        {
            SolrQueryResults<ArtigoCore> lista = new SolrQueryResults<ArtigoCore>();
            foreach (var item in artigos)
            {
                lista.Add((ArtigoCore)item);
            }

            return lista;
        }

        [HttpPost]
        public ActionResult Listar(string busca, int CoreId)
        {
            ArtigoView artigosView = new ArtigoView();
            object result = null;
            
            Stopwatch medidor = new Stopwatch();
            medidor.Start();
            switch (CoreId)
            {
                case (int)CoresId.Core1:
                    artigosView.Artigos = formatarLista(solrCore.Query(SolrQuery.All));
                    break;
                case (int)CoresId.Core2:
                    artigosView.Artigos = formatarLista(solrCore2.Query(SolrQuery.All));
                    break;
                case (int)CoresId.Core3:
                    artigosView.Artigos = formatarLista(solrCore3.Query(SolrQuery.All));
                    break;
            }
            medidor.Stop();

            artigosView.Artigos = formatarLista(solrCore.Query(SolrQuery.All));
            
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
            SolrQueryResults<Artigo> result = solrCore.Query(new SolrQuery("cluster:" + key));
            medidor.Stop();
            artigosView.Artigos = formatarLista(result);
            
            log.escreverLog("Pesquisa por cluster: " + medidor.Elapsed.ToString());

            return View("Index", artigosView);
        }
    }
}