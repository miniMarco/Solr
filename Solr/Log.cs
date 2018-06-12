using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Solr
{
    public class Log
    {
        string NOME_LOG = "MeuLog";
        string SOURCE = "MinhaAplicacao";

        public Log()
        {
            if (!EventLog.SourceExists(SOURCE))
                EventLog.CreateEventSource(SOURCE, NOME_LOG);
        }

        public void EscreverEntrada(string entrada, EventLogEntryType tipoEvento)
        {
            EventLog.WriteEntry(SOURCE, entrada, tipoEvento);
        }

        public void EscreverEntrada(string entrada)
        {
            EscreverEntrada(entrada, EventLogEntryType.Information);
        }

        public void EscreverEntrada(Exception ex)
        {
            EscreverEntrada(ex.Message, EventLogEntryType.Error);
        }
    }

    public class LogSimples
    {
        public LogSimples()
        {
            
        }

        public void escreverLog()
        { }

        internal void escreverLog(string texto)
        {
            string CaminhoNome = "c:\\Arquivo\\Log.txt";
            if (!File.Exists(CaminhoNome))
                File.Create(CaminhoNome).Close();

            File.AppendAllText(CaminhoNome, "[" + DateTime.Now + "] " + texto + "\r\n");
        }
    }
}