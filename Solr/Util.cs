using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solr
{
    public static class Util
    {
        public static string removerAcentos(string texto)
        {
            string semAcento = texto;
            foreach (char letra in texto)
            {
                if (letra == 'Á' || letra == 'À' || letra == 'Ã' || letra == 'Â')
                    semAcento.Replace(letra, 'A');
                else if (letra == 'á' || letra == 'à' || letra == 'ã' || letra == 'â')
                    semAcento.Replace(letra, 'a');

                else if (letra == 'É' || letra == 'È' || letra == 'Ê')
                    semAcento.Replace(letra, 'E');
                else if (letra == 'é' || letra == 'è' || letra == 'ê') 
                    semAcento.Replace(letra, 'e');

                else if (letra == 'Í' || letra == 'Ì' || letra == 'Î')
                    semAcento.Replace(letra, 'I');
                else if (letra == 'í' || letra == 'ì' || letra == 'î')
                    semAcento.Replace(letra, 'i');

                else if (letra == 'Ó' || letra == 'Ò' || letra == 'Õ' || letra == 'Ô')
                    semAcento.Replace(letra, 'O');
                else if (letra == 'ó' || letra == 'ò' || letra == 'õ' || letra == 'ô')
                    semAcento.Replace(letra, 'o');

                else if (letra == 'Ú' || letra == 'Ù' || letra == 'Û')
                    semAcento.Replace(letra, 'U');
                else if (letra == 'ú' || letra == 'ù' || letra == 'û')
                    semAcento.Replace(letra, 'u');

                else if (letra == 'Ç' || letra == 'ç')
                    semAcento.Replace(letra, 'c');
            }


            return semAcento;
        }

        public static bool ehTermoDefinido(string termo)
        {
            if (!string.IsNullOrEmpty(termo) && (termo.Equals("educacao especial") || termo.Equals("educacao permanente")
                || termo.Equals("educacao pre escolar") || termo.Equals("sociologia da educacao")))
            {
                return true;
            }
            else
                return false;
        }
    }
}