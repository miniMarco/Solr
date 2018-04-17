using CommonServiceLocator;
using Solr.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr
{
    public class SingleSolr
    {
        /*Padrão Singleton*/

        private static SingleSolr instance;

        private SingleSolr() { }

        
        public static SingleSolr GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr();

            return instance;
        }

        public ISolrOperations<Artigo> InstanciaDoSolar
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo>>(); }
        }
    }
}