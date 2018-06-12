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

        public ISolrOperations<Artigo> CoreInstance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo>>(); }
        }
    }

    public class SingleSolr2
    {
        /*Padrão Singleton*/

        private static SingleSolr2 instance;

        private SingleSolr2() { }


        public static SingleSolr2 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr2();

            return instance;
        }

        public ISolrOperations<Artigo2> Core2Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo2>>(); }
        }
    }

    public class SingleSolr3
    {
        /*Padrão Singleton*/

        private static SingleSolr3 instance;

        private SingleSolr3() { }


        public static SingleSolr3 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr3();

            return instance;
        }

        public ISolrOperations<Artigo3> Core3Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo3>>(); }
        }
    }
}