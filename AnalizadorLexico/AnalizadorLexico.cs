using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorLexico
{
    class AnalizadorLexico
    {
        private LinkedList<Tokens> Salida;
        private int estado;
        private String auxLex;

        public LinkedList<Tokens> Escaner(String Entrada)
        {
            Entrada = Entrada + "#";
            Salida = new LinkedList<Tokens>();
            estado = 0;
            auxLex = "";
            Char c;

            for (int i = 0; i < Entrada.Length-1; i++)
            {
                c = Entrada.ElementAt(i);
                switch (estado)
                {
                    case 0:
                        if (char.IsDigit(c))
                        {
                            estado = 1;
                            auxLex += c;
                        }
                        else if (c.CompareTo('+')==0)
                        {
                            auxLex += c;
                            agregarToken(Tokens.Tipo.SIGNO_MAS);
                        }
                        else if (c.CompareTo('-') == 0)
                        {
                            auxLex += c;
                            agregarToken(Tokens.Tipo.SIGNO_MENOS);
                        }
                        else if (c.CompareTo('*') == 0)
                        {
                            auxLex += c;
                            agregarToken(Tokens.Tipo.SIGNO_POR);
                        }
                        else if (c.CompareTo('^') == 0)
                        {
                            auxLex += c;
                            agregarToken(Tokens.Tipo.SIGNO_POW);
                        }
                        else if (c.CompareTo('/') == 0)
                        {
                            auxLex += c;
                            agregarToken(Tokens.Tipo.SIGNO_DIV);
                        }
                        else if (c.CompareTo('(') == 0)
                        {
                            auxLex += c;
                            agregarToken(Tokens.Tipo.PARENTESIS_IZQ);
                        }
                        else if (c.CompareTo(')') == 0)
                        {
                            auxLex += c;
                            agregarToken(Tokens.Tipo.PARENTESIS_DER);
                        }
                        else
                        {
                            if (c.CompareTo('#') == 0 && i == Entrada.Length-1)
                            {
                                Console.WriteLine("Hemos concluido el análisis con éxito");
                            }
                            else
                            {
                                Console.WriteLine("Error lexico encontrado en " + c);
                                estado = 0;
                            }
                        }
                        break;
                    case 1:
                        if (char.IsDigit(c))
                        {
                            estado = 1;
                            auxLex += c;
                        }
                        else if (c.CompareTo('.') == 0)
                        {
                            estado = 2;
                            auxLex += c;
                        }
                        else
                        {
                            agregarToken(Tokens.Tipo.NUMERO_ENTERO);
                            i -= 1;
                        }
                        break;
                    case 2:
                        if (char.IsDigit(c))
                        {
                            estado = 3;
                            auxLex += c;
                        }
                        else
                        {
                            Console.WriteLine("Error lexico encontrado en " + c + " despues del punto se esperaban numeros");
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (char.IsDigit(c))
                        {
                            estado = 3;
                            auxLex += c;
                        }
                        else
                        {
                            agregarToken(Tokens.Tipo.NUMERO_REAL);
                            i -= 1;
                        }
                        break;
                }
            }
            return Salida;
        }

        public void agregarToken(Tokens.Tipo tipo)
        {
            Salida.AddLast(new Tokens(tipo, auxLex));
            auxLex = "";
            estado = 0;
        }

        public void imprimirTokens(LinkedList<Tokens> list)
        {
            foreach (Tokens item in list)
            {
                Console.WriteLine(item.getTipoTok() + " <--> " + item.getValorTok());
            }
        }
    }
}
