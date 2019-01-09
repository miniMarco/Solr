using SolrNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Solr.Models
{
    public class Operacoes
    {
        public void coreOriginalDeletarTudo()
        {
            ISolrOperations<ArtigoOriginal> solr = SingleSolrOriginal.GetInstance().CoreOriginalInstance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void coreOriginalAdicionarArtigo(List<ArtigoOriginal> artigos)
        {
            ISolrOperations<ArtigoOriginal> solr = SingleSolrOriginal.GetInstance().CoreOriginalInstance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void coreSumarizadoDeletarTudo()
        {
            ISolrOperations<ArtigoSumarizado> solr = SingleSolrSumarizado.GetInstance().CoreSumarizadoInstance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void coreSumarizadoAdicionarArtigo(List<ArtigoSumarizado> artigos)
        {
            ISolrOperations<ArtigoSumarizado> solr = SingleSolrSumarizado.GetInstance().CoreSumarizadoInstance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/
        
        public void core1DeletarTudo()
        {
            ISolrOperations<Artigo> solr = SingleSolr.GetInstance().CoreInstance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core1AdicionarArtigo(List<Artigo> artigos)
        {
            ISolrOperations<Artigo> solr = SingleSolr.GetInstance().CoreInstance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core2DeletarTudo()
        {
            ISolrOperations<Artigo2> solr = SingleSolr2.GetInstance().Core2Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core2AdicionarArtigo(List<Artigo2> artigos)
        {
            ISolrOperations<Artigo2> solr = SingleSolr2.GetInstance().Core2Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core3DeletarTudo()
        {
            ISolrOperations<Artigo3> solr = SingleSolr3.GetInstance().Core3Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core3AdicionarArtigo(List<Artigo3> artigos)
        {
            ISolrOperations<Artigo3> solr = SingleSolr3.GetInstance().Core3Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /**************************************************************************************/

        public void core4DeletarTudo()
        {
            ISolrOperations<Artigo4> solr = SingleSolr4.GetInstance().Core4Instance;
            solr.Delete(SolrQuery.All);
            solr.Commit();
        }
        public void core4AdicionarArtigo(List<Artigo4> artigos)
        {
            ISolrOperations<Artigo4> solr = SingleSolr4.GetInstance().Core4Instance;
            solr.AddRange(artigos);
            solr.Commit();
        }

        /*******************************************************************************************************/
        
        public void processarArtigosC1()
        {
            string nomeArquivo = "50_3cluster.txt";
            List<Artigo> artigos = processarArquivoC1(nomeArquivo);
            recuperarSumariosC1(artigos, nomeArquivo);
            subirArtigosNoSolrC1(artigos);
        }
        public void processarArtigosC2()
        {
            string nomeArquivo = "50_4cluster.txt";
            List<Artigo2> artigos2 = processarArquivoC2(nomeArquivo);
            recuperarSumariosC2(artigos2, nomeArquivo);
            subirArtigosNoSolrC2(artigos2);
        }
        public void processarArtigosC3()
        {
            string nomeArquivo = "50_5cluster.txt";
            List<Artigo3> artigos3 = processarArquivoC3(nomeArquivo);
            recuperarSumariosC3(artigos3, nomeArquivo);
            subirArtigosNoSolrC3(artigos3);
        }
        public void processarArtigosC4()
        {
            string nomeArquivo = "50_semcluster.txt";
            List<Artigo4> artigos4 = processarArquivoC4(nomeArquivo);
            recuperarSumariosC4(artigos4, nomeArquivo);
            subirArtigosNoSolrC4(artigos4);
        }


        public void processarArtigoOriginal()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("c:\\arquivo\\original");
            List<ArtigoOriginal> listaArtigos = new List<ArtigoOriginal>();
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                try
                {
                    StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/original/" + file.Name, Encoding.Default);

                    string linha = string.Empty;

                    List<string> texto = new List<string>();
                    texto.Add(File.ReadAllText("c:/Arquivo/original/" + file.Name, Encoding.UTF8));
                    listaArtigos.Add(new ArtigoOriginal() { Cluster = "", NomeSumario = file.Name, Sumario = texto });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            try
            {
                Operacoes op = new Operacoes();
                op.coreOriginalDeletarTudo();
                op.coreOriginalAdicionarArtigo(listaArtigos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void processarArtigoSumarizado()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("c:\\arquivo\\sumarizado");
            List<ArtigoSumarizado> listaArtigos = new List<ArtigoSumarizado>();
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                try
                {
                    StreamReader arquivoOriginal = new StreamReader("c:/Arquivo/sumarizado/" + file.Name, Encoding.Default);

                    string linha = string.Empty;

                    List<string> texto = new List<string>();
                    texto.Add(File.ReadAllText("c:/Arquivo/sumarizado/" + file.Name, Encoding.Default));
                    listaArtigos.Add(new ArtigoSumarizado() { Cluster = "", NomeSumario = file.Name, Sumario = texto });
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            try
            {
                Operacoes op = new Operacoes();
                op.coreSumarizadoDeletarTudo();
                op.coreSumarizadoAdicionarArtigo(listaArtigos);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        private string formatarNomeArtigo(string linha)
        {
            string[] substrings = linha.Split('"');
            return substrings[1];
        }


    }
}