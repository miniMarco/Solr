using CommonServiceLocator;
using Solr.Models;
using SolrNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Solr
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Startup.Init<Artigo>("http://localhost:8983/solr/core");
            Startup.Init<Artigo2>("http://localhost:8983/solr/core2");
            Startup.Init<Artigo3>("http://localhost:8983/solr/core3");

            /*** Comentar as linhas para não subir mais artigos para o solr ******/
            List<Artigo> artigos = processarArquivoC1("50_3cluster.txt");
            recuperarSumariosC1(artigos, "50_3cluster.txt");
            subirArtigosNoSolrC1(artigos);
            
            List<Artigo2> artigos2 = processarArquivoC2("50_4cluster.txt");
            recuperarSumariosC2(artigos2, "50_4cluster.txt");
            subirArtigosNoSolrC2(artigos2);

            List<Artigo3> artigos3 = processarArquivoC3("50_5cluster.txt");
            recuperarSumariosC3(artigos3, "50_5cluster.txt");
            subirArtigosNoSolrC3(artigos3);

        }

        /**Core 01 ****/
        private List<Artigo> processarArquivoC1(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo> listaArtigos = new List<Artigo>();
                string nomeDoCluster = string.Empty;
                string linha = string.Empty;
                while ((linha = arquivoOriginal.ReadLine()) != null)
                {
                    if (linha.Contains("cluster") && !linha.Contains("Log"))
                    {
                        nomeDoCluster = linha;
                        continue;
                    }

                    if (string.IsNullOrEmpty(linha))
                        continue;

                    if (linha.Contains("Categorias"))
                        break;

                    if (!string.IsNullOrEmpty(nomeDoCluster))
                    {
                        listaArtigos.Add(new Artigo() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }

                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC1(List<Artigo> artigos, string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                bool preencherTexto = false;
                string linha, texto = string.Empty;
                string nome = string.Empty;

                while ((linha = arquivoOriginal.ReadLine()) != null)
                {
                    if (linha.Contains("[Original de:"))
                    {
                        preencherTexto = true;
                        preencherSumarioDeArtigoC1(nome, texto, artigos);

                        nome = formatarNomeArtigo(linha);
                        texto = string.Empty;
                        continue;
                    }
                    if (string.IsNullOrEmpty(linha))
                        continue;
                    if (preencherTexto)
                        texto += linha + " ";
                }
                arquivoOriginal.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void preencherSumarioDeArtigoC1(string nome, string texto, List<Artigo> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC1(List<Artigo> artigos)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core1DeletarTudo();
                op.core1AdicionarArtigo(artigos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 02 ****/
        private List<Artigo2> processarArquivoC2(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo2> listaArtigos = new List<Artigo2>();
                string nomeDoCluster = string.Empty;
                string linha = string.Empty;
                while ((linha = arquivoOriginal.ReadLine()) != null)
                {
                    if (linha.Contains("cluster") && !linha.Contains("Log"))
                    {
                        nomeDoCluster = linha;
                        continue;
                    }
                    if (string.IsNullOrEmpty(linha))
                        continue;
                    if (linha.Contains("Categorias"))
                        break;
                    if (!string.IsNullOrEmpty(nomeDoCluster))
                    {
                        listaArtigos.Add(new Artigo2() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC2(List<Artigo2> artigos, string nomeArquivo)
        {

            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                bool preencherTexto = false;
                string linha, texto = string.Empty;
                string nome = string.Empty;

                while ((linha = arquivoOriginal.ReadLine()) != null)
                {
                    if (linha.Contains("[Original de:"))
                    {
                        preencherTexto = true;
                        preencherSumarioDeArtigoC2(nome, texto, artigos);

                        nome = formatarNomeArtigo(linha);
                        texto = string.Empty;
                        continue;
                    }
                    if (string.IsNullOrEmpty(linha))
                        continue;
                    if (preencherTexto)
                        texto += linha + " ";
                }
                arquivoOriginal.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void preencherSumarioDeArtigoC2(string nome, string texto, List<Artigo2> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo2 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC2(List<Artigo2> artigos2)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core2DeletarTudo();
                op.core2AdicionarArtigo(artigos2);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 03 ****/
        private List<Artigo3> processarArquivoC3(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo3> listaArtigos = new List<Artigo3>();
                string nomeDoCluster = string.Empty;
                string linha = string.Empty;
                while ((linha = arquivoOriginal.ReadLine()) != null)
                {
                    if (linha.Contains("cluster") && !linha.Contains("Log"))
                    {
                        nomeDoCluster = linha;
                        continue;
                    }
                    if (string.IsNullOrEmpty(linha))
                        continue;
                    if (linha.Contains("Categorias"))
                        break;
                    if (!string.IsNullOrEmpty(nomeDoCluster))
                    {
                        listaArtigos.Add(new Artigo3() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC3(List<Artigo3> artigos, string nomeArquivo)
        {

            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                bool preencherTexto = false;
                string linha, texto = string.Empty;
                string nome = string.Empty;

                while ((linha = arquivoOriginal.ReadLine()) != null)
                {
                    if (linha.Contains("[Original de:"))
                    {
                        preencherTexto = true;
                        preencherSumarioDeArtigoC3(nome, texto, artigos);

                        nome = formatarNomeArtigo(linha);
                        texto = string.Empty;
                        continue;
                    }
                    if (string.IsNullOrEmpty(linha))
                        continue;
                    if (preencherTexto)
                        texto += linha + " ";
                }
                arquivoOriginal.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void preencherSumarioDeArtigoC3(string nome, string texto, List<Artigo3> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo3 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC3(List<Artigo3> artigos3)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core3DeletarTudo();
                op.core3AdicionarArtigo(artigos3);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private string formatarNomeArtigo(string linha)
        {
            string[] substrings = linha.Split('"');
            return substrings[1];
        }

        
    }
}
