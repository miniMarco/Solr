using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Solr
{
    public class Log
    {
        string arquivoExcel = "c:\\Arquivo\\log.xlsx";
        OleDbConnection conn;
        OleDbCommand cmd;


        public Log()
        {
        }

        private void prepararConexao()
        {
            conn = new OleDbConnection(getConnectionString());
            cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
        }

        private void abrirConexao()
        {
            prepararConexao();
            conn.Open();
        }

        private void fecharConexao()
        {
            if (cmd != null)
            {
                cmd.Parameters.Clear();
                cmd.Dispose();
            }
            cmd = null;

            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                conn.Dispose();
            }
            conn = null;
        }

        public void inserirLog(string pesquisa, string core, string precision, string recall, string medidaF, TimeSpan tempoPesquisa)
        {
            abrirConexao();

            string sql = "";

            if(Util.ehTermoDefinido(pesquisa))
                sql += "insert into [Plan1$] ";
            else
                sql += "insert into [Plan2$] ";

            sql += "([Pesquisa], [Core], [Precision], [Recall], [Medida-F], [Tempo], [Hora]) ";
            sql += "values ";
            sql += "(@pesquisa, @core, @precision, @recall, @medidaF, @tempoPesquisa, @hora)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@pesquisa", OleDbType.VarChar, 255).Value = pesquisa;
            cmd.Parameters.Add("@core", OleDbType.VarChar, 255).Value = core;
            cmd.Parameters.Add("@precision", OleDbType.VarChar, 255).Value = string.IsNullOrEmpty(precision) ? string.Empty : precision;
            cmd.Parameters.Add("@recall", OleDbType.VarChar, 255).Value = string.IsNullOrEmpty(recall) ? string.Empty : recall;
            cmd.Parameters.Add("@medidaF", OleDbType.VarChar, 255).Value = string.IsNullOrEmpty(medidaF) ? string.Empty : medidaF;
            cmd.Parameters.Add("@tempoPesquisa", OleDbType.VarChar, 255).Value = tempoPesquisa.ToString();
            cmd.Parameters.Add("@hora", OleDbType.Date).Value = DateTime.Now;

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            fecharConexao();
        }

        private string getConnectionString()
        {
            string Ext = Path.GetExtension(arquivoExcel);

            if (Ext == ".xlsx")
                return "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + arquivoExcel + ";Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            else
                return "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + arquivoExcel + ";Extended Properties = 'Excel 8.0;HDR=YES'";

        }
    }
}