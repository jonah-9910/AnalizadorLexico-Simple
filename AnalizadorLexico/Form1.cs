using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorLexico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String texto = txtEntrada.Text;
            AnalizadorLexico analisis = new AnalizadorLexico();

            LinkedList<Tokens> tokens = analisis.Escaner(texto);
            analisis.imprimirTokens(tokens);
        }
    }
}
