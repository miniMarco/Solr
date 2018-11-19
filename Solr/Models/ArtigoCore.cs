using SolrNet.Attributes;
using SolrNet.Impl;
using System.Collections.Generic;

namespace Solr.Models
{
    public class ArtigoCore
    {
        [SolrField("id")]
        public string Id { get; set; }
        [SolrField("cluster")]
        public string Cluster { get; set; }
        [SolrField("nomeSumario")]
        public string NomeSumario { get; set; }
        [SolrField("sumario")]
        public List<string> Sumario { get; set; }
        [SolrField("score")]
        public double? Score { get; set; }

        public string TextoH { get; set; }

        public ArtigoCore()
        {
            Sumario = new List<string>();
        }
    }
}