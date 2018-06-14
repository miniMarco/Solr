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
            Startup.Init<Artigo4>("http://localhost:8983/solr/core4");
            Startup.Init<Artigo5>("http://localhost:8983/solr/core5");
            Startup.Init<Artigo6>("http://localhost:8983/solr/core6");
            Startup.Init<Artigo7>("http://localhost:8983/solr/core7");
            Startup.Init<Artigo8>("http://localhost:8983/solr/core8");
            Startup.Init<Artigo9>("http://localhost:8983/solr/core9");
            Startup.Init<Artigo10>("http://localhost:8983/solr/core10");
            Startup.Init<Artigo11>("http://localhost:8983/solr/core11");
            Startup.Init<Artigo12>("http://localhost:8983/solr/core12");

            /*** Comentar as linhas para não subir mais artigos para o solr ******/
            string nomeArquivo = "50_3cluster.txt";
            List<Artigo> artigos = processarArquivoC1(nomeArquivo);
            recuperarSumariosC1(artigos, nomeArquivo);
            subirArtigosNoSolrC1(artigos);

            nomeArquivo = "50_4cluster.txt";
            List<Artigo2> artigos2 = processarArquivoC2(nomeArquivo);
            recuperarSumariosC2(artigos2, nomeArquivo);
            subirArtigosNoSolrC2(artigos2);

            nomeArquivo = "50_5cluster.txt";
            List<Artigo3> artigos3 = processarArquivoC3(nomeArquivo);
            recuperarSumariosC3(artigos3, nomeArquivo);
            subirArtigosNoSolrC3(artigos3);

            nomeArquivo = "50_semcluster.txt";
            List<Artigo4> artigos4 = processarArquivoC4(nomeArquivo);
            recuperarSumariosC4(artigos4, nomeArquivo);
            subirArtigosNoSolrC4(artigos4);

            nomeArquivo = "70_3cluster.txt";
            List<Artigo5> artigos5 = processarArquivoC5(nomeArquivo);
            recuperarSumariosC5(artigos5, nomeArquivo);
            subirArtigosNoSolrC5(artigos5);

            nomeArquivo = "70_4cluster.txt";
            List<Artigo6> artigos6 = processarArquivoC6(nomeArquivo);
            recuperarSumariosC6(artigos6, nomeArquivo);
            subirArtigosNoSolrC6(artigos6);

            nomeArquivo = "70_5cluster.txt";
            List<Artigo7> artigos7 = processarArquivoC7(nomeArquivo);
            recuperarSumariosC7(artigos7, nomeArquivo);
            subirArtigosNoSolrC7(artigos7);

            nomeArquivo = "70_semcluster.txt";
            List<Artigo8> artigos8 = processarArquivoC8(nomeArquivo);
            recuperarSumariosC8(artigos8, nomeArquivo);
            subirArtigosNoSolrC8(artigos8);

            nomeArquivo = "90_3Cluster.txt";
            List<Artigo9> artigos9 = processarArquivoC9(nomeArquivo);
            recuperarSumariosC9(artigos9, nomeArquivo);
            subirArtigosNoSolrC9(artigos9);

            nomeArquivo = "90_4cluster.txt";
            List<Artigo10> artigos10 = processarArquivoC10(nomeArquivo);
            recuperarSumariosC10(artigos10, nomeArquivo);
            subirArtigosNoSolrC10(artigos10);

            nomeArquivo = "90_5cluster.txt";
            List<Artigo11> artigos11 = processarArquivoC11(nomeArquivo);
            recuperarSumariosC11(artigos11, nomeArquivo);
            subirArtigosNoSolrC11(artigos11);

            nomeArquivo = "90_semcluster.txt";
            List<Artigo12> artigos12 = processarArquivoC12(nomeArquivo);
            recuperarSumariosC12(artigos12, nomeArquivo);
            subirArtigosNoSolrC12(artigos12);
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

        /**Core 04 ****/
        private List<Artigo4> processarArquivoC4(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo4> listaArtigos = new List<Artigo4>();
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
                        listaArtigos.Add(new Artigo4() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC4(List<Artigo4> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC4(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC4(string nome, string texto, List<Artigo4> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo4 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC4(List<Artigo4> artigos4)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core4DeletarTudo();
                op.core4AdicionarArtigo(artigos4);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 05 ****/
        private List<Artigo5> processarArquivoC5(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo5> listaArtigos = new List<Artigo5>();
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
                        listaArtigos.Add(new Artigo5() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC5(List<Artigo5> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC5(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC5(string nome, string texto, List<Artigo5> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo5 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC5(List<Artigo5> artigos5)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core5DeletarTudo();
                op.core5AdicionarArtigo(artigos5);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 06 ****/
        private List<Artigo6> processarArquivoC6(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo6> listaArtigos = new List<Artigo6>();
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
                        listaArtigos.Add(new Artigo6() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC6(List<Artigo6> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC6(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC6(string nome, string texto, List<Artigo6> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo6 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC6(List<Artigo6> artigos6)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core6DeletarTudo();
                op.core6AdicionarArtigo(artigos6);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 07 ****/
        private List<Artigo7> processarArquivoC7(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo7> listaArtigos = new List<Artigo7>();
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
                        listaArtigos.Add(new Artigo7() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC7(List<Artigo7> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC7(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC7(string nome, string texto, List<Artigo7> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo7 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC7(List<Artigo7> artigos7)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core7DeletarTudo();
                op.core7AdicionarArtigo(artigos7);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 08 ****/
        private List<Artigo8> processarArquivoC8(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo8> listaArtigos = new List<Artigo8>();
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
                        listaArtigos.Add(new Artigo8() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC8(List<Artigo8> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC8(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC8(string nome, string texto, List<Artigo8> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo8 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC8(List<Artigo8> artigos8)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core8DeletarTudo();
                op.core8AdicionarArtigo(artigos8);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 09 ****/
        private List<Artigo9> processarArquivoC9(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo9> listaArtigos = new List<Artigo9>();
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
                        listaArtigos.Add(new Artigo9() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC9(List<Artigo9> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC9(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC9(string nome, string texto, List<Artigo9> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo9 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC9(List<Artigo9> artigos9)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core9DeletarTudo();
                op.core9AdicionarArtigo(artigos9);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 010 ****/
        private List<Artigo10> processarArquivoC10(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo10> listaArtigos = new List<Artigo10>();
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
                        listaArtigos.Add(new Artigo10() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC10(List<Artigo10> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC10(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC10(string nome, string texto, List<Artigo10> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo10 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC10(List<Artigo10> artigos10)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core10DeletarTudo();
                op.core10AdicionarArtigo(artigos10);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 011 ****/
        private List<Artigo11> processarArquivoC11(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo11> listaArtigos = new List<Artigo11>();
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
                        listaArtigos.Add(new Artigo11() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC11(List<Artigo11> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC11(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC11(string nome, string texto, List<Artigo11> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo11 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC11(List<Artigo11> artigos11)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core11DeletarTudo();
                op.core11AdicionarArtigo(artigos11);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /**Core 012 ****/
        private List<Artigo12> processarArquivoC12(string nomeArquivo)
        {
            try
            {
                StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/" + nomeArquivo, Encoding.Default);
                List<Artigo12> listaArtigos = new List<Artigo12>();
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
                        listaArtigos.Add(new Artigo12() { Cluster = nomeDoCluster, NomeSumario = linha.Substring(1) });
                    }
                }
                return listaArtigos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void recuperarSumariosC12(List<Artigo12> artigos, string nomeArquivo)
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
                        preencherSumarioDeArtigoC12(nome, texto, artigos);

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
        private void preencherSumarioDeArtigoC12(string nome, string texto, List<Artigo12> artigos)
        {
            if (string.IsNullOrEmpty(texto) || string.IsNullOrEmpty(nome))
                return;
            Artigo12 artigo = artigos.Where(item => item.NomeSumario == nome).First();
            artigo.Sumario.Add(texto);
        }
        private void subirArtigosNoSolrC12(List<Artigo12> artigos12)
        {
            try
            {
                Operacoes op = new Operacoes();
                op.core12DeletarTudo();
                op.core12AdicionarArtigo(artigos12);
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
