using Solr.Models;
using SolrNet;
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
        public ISolrOperations<Artigo3> solrCore3
        {
            get { return SingleSolr3.GetInstance().Core3Instance; }
        }
        public ISolrOperations<Artigo4> solrCore4
        {
            get { return SingleSolr4.GetInstance().Core4Instance; }
        }
        public ISolrOperations<Artigo5> solrCore5
        {
            get { return SingleSolr5.GetInstance().Core5Instance; }
        }
        public ISolrOperations<Artigo6> solrCore6
        {
            get { return SingleSolr6.GetInstance().Core6Instance; }
        }
        public ISolrOperations<Artigo7> solrCore7
        {
            get { return SingleSolr7.GetInstance().Core7Instance; }
        }
        public ISolrOperations<Artigo8> solrCore8
        {
            get { return SingleSolr8.GetInstance().Core8Instance; }
        }
        public ISolrOperations<Artigo9> solrCore9
        {
            get { return SingleSolr9.GetInstance().Core9Instance; }
        }
        public ISolrOperations<Artigo10> solrCore10
        {
            get { return SingleSolr10.GetInstance().Core10Instance; }
        }
        public ISolrOperations<Artigo11> solrCore11
        {
            get { return SingleSolr11.GetInstance().Core11Instance; }
        }
        public ISolrOperations<Artigo12> solrCore12
        {
            get { return SingleSolr12.GetInstance().Core12Instance; }
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
            ArtigoView artigosView = new ArtigoView();
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
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);

                        artigosView.Artigos = formatarLista(artigos);
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
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore2.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);

                        artigosView.Artigos = formatarLista(artigos);
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
                        }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore3.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
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
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore4.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core5:
                {
                    SolrQueryResults<Artigo5> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore5.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore5.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core6:
                {
                    SolrQueryResults<Artigo6> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore6.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore6.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core7:
                {
                    SolrQueryResults<Artigo7> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore7.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore7.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core8:
                {
                    SolrQueryResults<Artigo8> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore8.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore8.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core9:
                {
                    SolrQueryResults<Artigo9> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore9.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore9.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core10:
                {
                    SolrQueryResults<Artigo10> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore10.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore10.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core11:
                {
                    SolrQueryResults<Artigo11> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore11.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore11.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
                case (int)CoresId.Core12:
                {
                    SolrQueryResults<Artigo12> artigos;
                    Stopwatch medidor = new Stopwatch();
                    if (string.IsNullOrEmpty(busca))
                    {
                        medidor.Start();
                        artigos = solrCore12.Query(SolrQuery.All);
                        medidor.Stop();
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    else
                    {
                        SolrMultipleCriteriaQuery query = montarQuery(busca);
                        medidor.Start();
                        artigos = solrCore12.Query(query);
                        medidor.Stop();
                        artigosView.QueryTime = medidor.Elapsed;
                        log.escreverLog("Pesquisa por busca: " + medidor.Elapsed);
                        artigosView.Artigos = formatarLista(artigos);
                    }
                    break;
                }
            }

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


        /**************************/

        [HttpPost]
        public ActionResult Listar(string busca, int CoreId)
        {
            ArtigoView artigosView = new ArtigoView();
            
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
                lista.Add(new SolrQuery("sumario:" + termo));
            }
            return new SolrMultipleCriteriaQuery(lista, "AND");
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