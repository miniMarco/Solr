using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr.Models
{
    public class Operacoes
    {
        public Operacoes() { }

        public void deletarTodosOsDados()
        {
            ISolrOperations<Artigo> solr = SingleSolr.GetInstance().InstanciaDoSolar;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }

        internal void adicionarArtigo(List<Artigo> artigos)
        {
            ISolrOperations<Artigo> solr = SingleSolr.GetInstance().InstanciaDoSolar;
            solr.AddRange(artigos);
            solr.Commit();
        }
    }
}