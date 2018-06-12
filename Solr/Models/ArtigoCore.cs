using SolrNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr.Models
{
    public class ArtigoCore
    {
        [SolrField("cluster")]
        public string Cluster { get; set; }
        [SolrField("nomeSumario")]
        public string NomeSumario { get; set; }
        [SolrField("sumario")]
        public List<string> Sumario { get; set; }
        [SolrField("score")]
        public double? Score { get; set; }

        public ArtigoCore()
        {
            Sumario = new List<string>();
        }
    }
}