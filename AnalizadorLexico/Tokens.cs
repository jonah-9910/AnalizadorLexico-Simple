using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico
{
    class Tokens
    {
        public enum Tipo
        {
            NUMERO_ENTERO,
            NUMERO_REAL,
            SIGNO_MAS,
            SIGNO_MENOS,
            SIGNO_POR,
            SIGNO_DIV,
            SIGNO_POW,
            PARENTESIS_IZQ,
            PARENTESIS_DER
        }

        private Tipo tipoToken;
        private String valorToken;

        public Tokens(Tipo tipTokens, String valTokens)
        {
            this.tipoToken = tipTokens;
            this.valorToken = valTokens;
        }

        public String getValorTok()
        {
            return valorToken;
        }

        public String getTipoTok()
        {
            switch (tipoToken)
            {
                case Tipo.NUMERO_ENTERO:
                    return "Numero Entero";
                case Tipo.NUMERO_REAL:
                    return "Numero Real";
                case Tipo.SIGNO_MAS:
                    return "Signo +";
                case Tipo.SIGNO_MENOS:
                    return "Signo -";
                case Tipo.SIGNO_POR:
                    return "Signo *";
                case Tipo.SIGNO_DIV:
                    return "Signo /";
                case Tipo.SIGNO_POW:
                    return "Signo ^";
                case Tipo.PARENTESIS_IZQ:
                    return "Parentesis (";
                case Tipo.PARENTESIS_DER:
                    return "Parentesis )";
                default:
                    return "Desconocido";
            }
        }
    }
}
