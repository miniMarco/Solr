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

        /**************************************************************************************/

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

        /**************************************************************************************/

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

        /**************************************************************************************/

        public void core4DeletarTudo()
        {
            ISolrOperations<Artigo4> solr = SingleSolr4.GetInstance().Core4Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core4AdicionarArtigo(List<Artigo4> artigos)
        {
            ISolrOperations<Artigo4> solr = SingleSolr4.GetInstance().Core4Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core5DeletarTudo()
        {
            ISolrOperations<Artigo5> solr = SingleSolr5.GetInstance().Core5Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core5AdicionarArtigo(List<Artigo5> artigos)
        {
            ISolrOperations<Artigo5> solr = SingleSolr5.GetInstance().Core5Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core6DeletarTudo()
        {
            ISolrOperations<Artigo6> solr = SingleSolr6.GetInstance().Core6Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core6AdicionarArtigo(List<Artigo6> artigos)
        {
            ISolrOperations<Artigo6> solr = SingleSolr6.GetInstance().Core6Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core7DeletarTudo()
        {
            ISolrOperations<Artigo7> solr = SingleSolr7.GetInstance().Core7Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core7AdicionarArtigo(List<Artigo7> artigos)
        {
            ISolrOperations<Artigo7> solr = SingleSolr7.GetInstance().Core7Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core8DeletarTudo()
        {
            ISolrOperations<Artigo8> solr = SingleSolr8.GetInstance().Core8Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core8AdicionarArtigo(List<Artigo8> artigos)
        {
            ISolrOperations<Artigo8> solr = SingleSolr8.GetInstance().Core8Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core9DeletarTudo()
        {
            ISolrOperations<Artigo9> solr = SingleSolr9.GetInstance().Core9Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core9AdicionarArtigo(List<Artigo9> artigos)
        {
            ISolrOperations<Artigo9> solr = SingleSolr9.GetInstance().Core9Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core10DeletarTudo()
        {
            ISolrOperations<Artigo10> solr = SingleSolr10.GetInstance().Core10Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core10AdicionarArtigo(List<Artigo10> artigos)
        {
            ISolrOperations<Artigo10> solr = SingleSolr10.GetInstance().Core10Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core11DeletarTudo()
        {
            ISolrOperations<Artigo11> solr = SingleSolr11.GetInstance().Core11Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core11AdicionarArtigo(List<Artigo11> artigos)
        {
            ISolrOperations<Artigo11> solr = SingleSolr11.GetInstance().Core11Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core12DeletarTudo()
        {
            ISolrOperations<Artigo12> solr = SingleSolr12.GetInstance().Core12Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core12AdicionarArtigo(List<Artigo12> artigos)
        {
            ISolrOperations<Artigo12> solr = SingleSolr12.GetInstance().Core12Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }
    }
}