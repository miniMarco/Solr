using Solr.Models;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace Solr.Controllers
{
    public class HomeController : Controller
    {
        #region  ****** Propriedades ********
        Log log = new Log();
        public ISolrOperations<ArtigoOriginal> solrCoreOriginal
        {
            get { return SingleSolrOriginal.GetInstance().CoreOriginalInstance; }
        }
        public ISolrOperations<ArtigoSumarizado> solrCoreSumarizado
        {
            get { return SingleSolrSumarizado.GetInstance().CoreSumarizadoInstance; }
        }
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
        public ISolrOperations<Artigo4> solrCore4
        {
            get { return SingleSolr4.GetInstance().Core4Instance; }
        }
        
        #endregion

        public ActionResult Index()
        {
            ViewBag.CoreId = new SelectList(new Core().ListaCores(), "CoreId", "Nome");
            ArtigoView artigosView = new ArtigoView();
            return View(artigosView);
        }

        [HttpPost]
        public ActionResult Pesquisar(string busca, string quantidadeRelevante, int CoreId)
        {
            

            busca = busca.ToLower();
            busca = Util.removerAcentos(busca);
            ArtigoView artigosView = new ArtigoView();

            if (string.IsNullOrEmpty(quantidadeRelevante))
                artigosView.QuantidadeRelevantes = 10;
            else
                artigosView.QuantidadeRelevantes = Convert.ToInt32(quantidadeRelevante);

            switch (CoreId)
            {
                case (int)CoresId.Core1:
                {
                    SolrQueryResults<Artigo> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog("", "Core 1", artigosView, medidor.Elapsed);
                        
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery2(busca);
                        medidor.Start();
                        artigos = (SolrQueryResults<Artigo>)solrCore.Query(montarQuery2(busca), getHighlightOption());
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog(busca,  "Core 1", artigosView, medidor.Elapsed);
                    }
                break;
                }
                case (int)CoresId.Core2:
                {
                    SolrQueryResults<Artigo2> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore2.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog("", "Core 2", artigosView, medidor.Elapsed);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery2(busca);
                        medidor.Start();
                        artigos = (SolrQueryResults<Artigo2>)solrCore2.Query(query, getHighlightOption());
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog(busca, "Core 2", artigosView, medidor.Elapsed);
                    }
                    break;
                }
                case (int)CoresId.Core3:
                {
                    SolrQueryResults<Artigo3> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore3.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog("", "Core 3", artigosView, medidor.Elapsed);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery2(busca);
                        medidor.Start();
                        artigos = (SolrQueryResults<Artigo3>)solrCore3.Query(query, getHighlightOption());
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog(busca, "Core 3", artigosView, medidor.Elapsed);
                    }
                    break;
                }
                case (int)CoresId.Core4:
                {
                    SolrQueryResults<Artigo4> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore4.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog("", "Core 4", artigosView, medidor.Elapsed);
                        }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery2(busca);
                        medidor.Start();
                        artigos = (SolrQueryResults<Artigo4>)solrCore4.Query(query, getHighlightOption());
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog(busca, "Core 4", artigosView, medidor.Elapsed);
                    }
                    break;
                }
                case (int)CoresId.Core13:
                {
                    SolrQueryResults<ArtigoOriginal> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCoreOriginal.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog("", "Core Original", artigosView, medidor.Elapsed);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery2(busca);
                        medidor.Start();
                        artigos = (SolrQueryResults<ArtigoOriginal>)solrCoreOriginal.Query(query, getHighlightOption());
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        artigosView.Artigos = formatarLista(artigos);
                        log.inserirLog(busca, "Core Original", artigosView, medidor.Elapsed);
                    }
                    break;
                }
                case (int)CoresId.Core14:
                    {
                        SolrQueryResults<ArtigoSumarizado> artigos;
                        Stopwatch medidor = new Stopwatch();
                        if (string.IsNullOrEmpty(busca))
                        {
                            medidor.Start();
                            artigos = solrCoreSumarizado.Query(SolrQuery.All);
                            medidor.Stop();
                            artigosView.Artigos = formatarLista(artigos);
                            log.inserirLog("", "Core_sum", artigosView, medidor.Elapsed);
                        }
                        else
                        {
                            SolrMultipleCriteriaQuery query = montarQuery2(busca);
                            medidor.Start();
                            artigos = (SolrQueryResults<ArtigoSumarizado>)solrCoreSumarizado.Query(query, getHighlightOption());
                            medidor.Stop();
                            artigosView.QueryTime = medidor.Elapsed;
                            artigosView.Artigos = formatarLista(artigos);
                            log.inserirLog(busca, "Core_sum", artigosView, medidor.Elapsed);
                        }
                        break;
                    }
            }

            ViewBag.CoreId = new SelectList(new Core().ListaCores(), "CoreId", "Nome");
            ViewBag.QuantidadeRelevante = artigosView.QuantidadeRelevantes;
            return View("Index", artigosView);
        }

        private SolrQueryResults<ArtigoCore> formatarLista<T>(SolrQueryResults<T> artigos) where T : ArtigoCore
        {
            SolrQueryResults<ArtigoCore> lista = new SolrQueryResults<ArtigoCore>();
            foreach (var item in artigos)
            {
                lista.Add((ArtigoCore)item);
            }
            lista.Highlights = artigos.Highlights;

            if (lista.Highlights == null)
                return lista;

            for (int i = 0; i < lista.Count; i++)
            {
                foreach (var h in lista.Highlights[lista[i].Id])
                {
                    lista[i].TextoH = h.Value.FirstOrDefault();
                }
            }

            return lista;
        }


        private SolrMultipleCriteriaQuery montarQuery2(string busca)
        {
            List<ISolrQuery> lista = new List<ISolrQuery>();
            //if (busca.StartsWith("\"") && busca.EndsWith("\""))
            //{
                lista.Add(new SolrQueryByField("sumario", busca));
                return new SolrMultipleCriteriaQuery(lista);
            //}
            //else
            //{
            //    string[] termos = busca.Split(' ');
            //    foreach (string termo in termos)
            //    {
            //        lista.Add(new SolrQueryByField("sumario", termo));
            //    }
            //    return new SolrMultipleCriteriaQuery(lista, SolrMultipleCriteriaQuery.Operator.AND );
            //}
        }

        private SolrMultipleCriteriaQuery montarQuery(string busca)
        {
            List<ISolrQuery> lista = new List<ISolrQuery>();
            if (busca.StartsWith("\"") && busca.EndsWith("\""))
            { 
                lista.Add(new SolrQueryByField("sumario", busca));
                return new SolrMultipleCriteriaQuery(lista);
            }
            else
            {
                string[] termos = busca.Split(' ');
                foreach (string termo in termos)
                {
                    lista.Add(new SolrQueryByField("sumario", termo));
                }
                return new SolrMultipleCriteriaQuery(lista, "AND");
            }
        }

        private QueryOptions getHighlightOption()
        {
            HighlightingParameters highlight = new HighlightingParameters();
            highlight.Fragsize = 0;
            highlight.Fields = new List<string>();
            highlight.Fields.Add("sumario");
            highlight.BeforeTerm = "<span style=\"background-color: #FFFF00\">";
            highlight.AfterTerm = "</span>";

            return new QueryOptions
            {
                Highlight = highlight
            };
        }
    }
}