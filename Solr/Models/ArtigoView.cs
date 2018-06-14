using SolrNet;
using System;
using System.Collections.Generic;

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

                if (ArtigosRelevantes == null)
                    ArtigosRelevantes = new Dictionary<string, int>();

                foreach (ArtigoCore artigo in artigos)
                {
                    if (ItemQuantidade.ContainsKey(artigo.Cluster))
                    {
                        ItemQuantidade[artigo.Cluster]++; 
                    }
                    else
                    {
                        ItemQuantidade.Add(artigo.Cluster, 1);
                    }

                    string sigla = artigo.NomeSumario.Substring(0, 3);

                    if (ArtigosRelevantes.ContainsKey(sigla))
                    {
                        ArtigosRelevantes[sigla]++;
                    }
                    else
                    {
                        ArtigosRelevantes.Add(sigla, 1);
                    }
                }
            }
        }

        public Dictionary<string, int> ArtigosRelevantes { get; set; }

        public Dictionary<string, int> ItemQuantidade { get; set; }

        public TimeSpan  QueryTime { get; set; }
    }
}