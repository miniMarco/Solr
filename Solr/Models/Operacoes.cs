using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr.Models
{
    public class Operacoes
    {
        public void core1DeletarTudo()
        {
            ISolrOperations<Artigo> solr = SingleSolr.GetInstance().CoreInstance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }

        public void core1AdicionarArtigo(List<Artigo> artigos)
        {
            ISolrOperations<Artigo> solr = SingleSolr.GetInstance().CoreInstance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        public void core2DeletarTudo()
        {
            ISolrOperations<Artigo2> solr = SingleSolr2.GetInstance().Core2Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }

        public void core2AdicionarArtigo(List<Artigo2> artigos)
        {
            ISolrOperations<Artigo2> solr = SingleSolr2.GetInstance().Core2Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        public void core3DeletarTudo()
        {
            ISolrOperations<Artigo3> solr = SingleSolr3.GetInstance().Core3Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }

        public void core3AdicionarArtigo(List<Artigo3> artigos)
        {
            ISolrOperations<Artigo3> solr = SingleSolr3.GetInstance().Core3Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }


    }
}