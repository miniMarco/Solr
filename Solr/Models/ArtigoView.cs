using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    string sigla = artigo.NomeSumario.Substring(0, 3);

                    if (ArtigosRelevantes.ContainsKey(sigla))
                    {
                        ArtigosRelevantes[sigla]++;
                    }
                    else
                    {
                        ArtigosRelevantes.Add(sigla, 1);
                    }

                    if (artigo is ArtigoOriginal)
                        continue;

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

        private string precision;
        public string Precision
        {
            get
            {
                precision = string.Empty;
                if (ArtigosRelevantes == null || ArtigosRelevantes.Count == 0)
                    return string.Empty;
                
                return obterPrecisao();
            }
        }
        public string obterPrecisao(string termo = "")
        {
            Dictionary<string, int> itens = new Dictionary<string, int>();
            itens = extrairArtigosCorretos(termo);
            foreach (KeyValuePair<string, int> item in itens)
            {
                if (string.IsNullOrEmpty(termo))
                    precision += " " + item.Key + ": " + item.Value.ToString() + "/" + Artigos.Count.ToString() + " = " + ((double)item.Value / (double)Artigos.Count).ToString("0.000");
                else
                    precision += " " + ((double)item.Value / (double)Artigos.Count).ToString("0.000");
            }
            return precision;
        }
                
        private string recall;
        public string Recall
        {
            get
            {
                if (ArtigosRelevantes == null || ArtigosRelevantes.Count == 0)
                    return string.Empty;

                return obterRecall();
            }
            
        }
        public string obterRecall(string termo = "")
        {
            Dictionary<string, int> itens = new Dictionary<string, int>();
            itens = extrairArtigosCorretos(termo);

            foreach (KeyValuePair<string, int> item in itens)
            {
                if (string.IsNullOrEmpty(termo))
                    recall += " " + item.Key + ": " + item.Value.ToString() + "/10 = " + ((double)item.Value / (double)10).ToString("0.000");
                else
                    recall += " " + ((double)item.Value / (double)10).ToString("0.000");
            }
            return recall;
        }

        private string medidaF;
        public string MedidaF
        {
            get
            {
                medidaF = string.Empty;
                if (ArtigosRelevantes == null || ArtigosRelevantes.Count == 0)
                    return string.Empty;

                return obterMedidaF();
            }
        }
        public string obterMedidaF(string termo = "")
        {
            Dictionary<string, int> itens = new Dictionary<string, int>();
            itens = extrairArtigosCorretos(termo);

            foreach (KeyValuePair<string, int> item in itens)
            {
                double p = (double)item.Value / (double)Artigos.Count;
                double r = (double)item.Value / (double)10;

                if (string.IsNullOrEmpty(termo))
                    medidaF += " " + item.Key + ": " + (2 * ((p * r) / (p + r))).ToString("0.000");
                else
                    medidaF += " " + (2 * ((p * r) / (p + r))).ToString("0.000");
            }
            return medidaF;
        }

        private Dictionary<string, int> extrairArtigosCorretos(string termo)
        {
            Dictionary<string, int> itens = new Dictionary<string, int>();

            if (string.IsNullOrEmpty(termo))
            {
                return ArtigosRelevantes;
            }
            else if (termo == "educacao especial")
            {
                itens = ArtigosRelevantes.Where(item => item.Key == "EEA").ToDictionary(k => k.Key, v => v.Value);
            }
            else if (termo == "educacao permanente")
            {
                itens = ArtigosRelevantes.Where(item => item.Key == "EPA").ToDictionary(k => k.Key, v => v.Value);
            }
            else if (termo == "educacao pre escolar")
            {
                itens = ArtigosRelevantes.Where(item => item.Key == "EPEA").ToDictionary(k => k.Key, v => v.Value);
            }
            else if (termo == "sociologia da educacao")
            {
                itens = ArtigosRelevantes.Where(item => item.Key == "SEA").ToDictionary(k => k.Key, v => v.Value);
            }

            return itens.Count == 0 ? ArtigosRelevantes : itens;
        }

        public Dictionary<string, int> ArtigosRelevantes { get; set; }

        public Dictionary<string, int> ItemQuantidade { get; set; }

        public TimeSpan  QueryTime { get; set; }
    }
}