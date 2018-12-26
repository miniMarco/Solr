using CommonServiceLocator;
using Solr.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr
{
    public class SingleSolrOriginal
    {
        /*Padrão Singleton*/

        private static SingleSolrOriginal instance;
        private SingleSolrOriginal() { }
        public static SingleSolrOriginal GetInstance()
        {
            if (instance == null)
                instance = new SingleSolrOriginal();
            return instance;
        }
        public ISolrOperations<ArtigoOriginal> CoreOriginalInstance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<ArtigoOriginal>>(); }
        }
    }

    public class SingleSolrSumarizado
    {
        /*Padrão Singleton*/

        private static SingleSolrSumarizado instance;
        private SingleSolrSumarizado() { }
        public static SingleSolrSumarizado GetInstance()
        {
            if (instance == null)
                instance = new SingleSolrSumarizado();
            return instance;
        }
        public ISolrOperations<ArtigoSumarizado> CoreSumarizadoInstance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<ArtigoSumarizado>>(); }
        }
    }


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

    public class SingleSolr4
    {
        /*Padrão Singleton*/
        private static SingleSolr4 instance;
        private SingleSolr4() { }
        public static SingleSolr4 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr4();
            return instance;
        }
        public ISolrOperations<Artigo4> Core4Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo4>>(); }
        }
    }

    public class SingleSolr5
    {
        /*Padrão Singleton*/
        private static SingleSolr5 instance;
        private SingleSolr5() { }
        public static SingleSolr5 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr5();
            return instance;
        }
        public ISolrOperations<ArtigoSumarizado> Core5Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<ArtigoSumarizado>>(); }
        }
    }

    public class SingleSolr6
    {
        /*Padrão Singleton*/
        private static SingleSolr6 instance;
        private SingleSolr6() { }
        public static SingleSolr6 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr6();
            return instance;
        }
        public ISolrOperations<Artigo6> Core6Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo6>>(); }
        }
    }

    public class SingleSolr7
    {
        /*Padrão Singleton*/
        private static SingleSolr7 instance;
        private SingleSolr7() { }
        public static SingleSolr7 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr7();
            return instance;
        }
        public ISolrOperations<Artigo7> Core7Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo7>>(); }
        }
    }

    public class SingleSolr8
    {
        /*Padrão Singleton*/
        private static SingleSolr8 instance;
        private SingleSolr8() { }
        public static SingleSolr8 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr8();
            return instance;
        }
        public ISolrOperations<Artigo8> Core8Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo8>>(); }
        }
    }

    public class SingleSolr9
    {
        /*Padrão Singleton*/
        private static SingleSolr9 instance;
        private SingleSolr9() { }
        public static SingleSolr9 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr9();
            return instance;
        }
        public ISolrOperations<Artigo9> Core9Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo9>>(); }
        }
    }

    public class SingleSolr10
    {
        /*Padrão Singleton*/
        private static SingleSolr10 instance;
        private SingleSolr10() { }
        public static SingleSolr10 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr10();
            return instance;
        }
        public ISolrOperations<Artigo10> Core10Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo10>>(); }
        }
    }

    public class SingleSolr11
    {
        /*Padrão Singleton*/
        private static SingleSolr11 instance;
        private SingleSolr11() { }
        public static SingleSolr11 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr11();
            return instance;
        }
        public ISolrOperations<Artigo11> Core11Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo11>>(); }
        }
    }

    public class SingleSolr12
    {
        /*Padrão Singleton*/
        private static SingleSolr12 instance;
        private SingleSolr12() { }
        public static SingleSolr12 GetInstance()
        {
            if (instance == null)
                instance = new SingleSolr12();
            return instance;
        }
        public ISolrOperations<Artigo12> Core12Instance
        {
            get { return ServiceLocator.Current.GetInstance<ISolrOperations<Artigo12>>(); }
        }
    }
}