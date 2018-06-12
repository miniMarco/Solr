using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr.Models
{
    public class ArtigoView
    {
        SolrQueryResults<ArtigoCore> artigos;
        public SolrQueryResults<ArtigoCore> Artigos
        {
            get { return artigos; }
            set
            {
                artigos = value;

                if (ItemQuantidade == null)
                    ItemQuantidade = new Dictionary<string, int>();

                foreach (Artigo artigo in artigos)
                {
                    if (ItemQuantidade.ContainsKey(artigo.Cluster))
                    {
                        ItemQuantidade[artigo.Cluster]++; 
                    }
                    else
                    {
                        ItemQuantidade.Add(artigo.Cluster, 1);
                    }
                    
                }
            }
        }

        public Dictionary<string, int> ItemQuantidade { get; set; }
    }
}