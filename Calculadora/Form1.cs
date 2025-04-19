using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1: Form
    {
        private double valor1 = 0;   
        private double valor2 = 0;   
        private string operador = string.Empty;
        private bool novoNumero = true;
        private string expressao = "";
        public Form1()
        {
            InitializeComponent();
            // Eventos os botoes numericos
            btn0.Click += btnNumero_Click;
            btn1.Click += btnNumero_Click;
            btn2.Click += btnNumero_Click;
            btn3.Click += btnNumero_Click;
            btn4.Click += btnNumero_Click;
            btn5.Click += btnNumero_Click;
            btn6.Click += btnNumero_Click;
            btn7.Click += btnNumero_Click;
            btn8.Click += btnNumero_Click;
            btn9.Click += btnNumero_Click;
            //Eventos dos botões de operações
            btnSum.Click += btnOperation_Click;
            btnSub.Click += btnOperation_Click;
            btnMult.Click += btnOperation_Click;
            btnDiv.Click += btnOperation_Click;

            // Eventos dos outros botões
            btnIgual.Click += btnIgual_Click;
            btnAC.Click += btnAC_Click;
            btnPonto.Click += btnPonto_Click;
            btnRaiz.Click += btnRaiz_Click;
            btnCubo.Click += btnCubo_Click;
        }
        //Aqui está as funções da calculadora
        private void Calcular()
        {
            //Priorizando as operacoes
            if (operador == "^")
            {
                valor1 = Math.Pow(valor1, valor2);
            }
            else if (operador=="*" || operador == "/")
            {
                switch (operador)
                {
                    case "*":
                        valor2 *= valor2;
                        break;
                    case "/":
                        if(valor2 != 0)
                        {
                            valor1 /= valor2;
                        }
                        else
                        {
                            MostrarNaTela("Erro!");
                            return;
                        }
                        break;
                }
            }
                else if (operador=="+" || operador == "-")
                {
                    switch (operador)
                    {
                        case "+":
                            valor1 += valor2;
                            break;
                        case "-":
                            valor1 -= valor2;
                            break;
                    }
                }
        }
         private void btnRaiz_Click(object sender, EventArgs e)
        {
            if (double.TryParse(TxtDefault.Text, out valor2))
            {
                if (valor2 < 0)
                {
                    MostrarNaTela("Erro!");
                    return;
                }

                valor1 = Math.Sqrt(valor2);
                MostrarNaTela(valor1.ToString());
                operador = string.Empty;
                novoNumero = true;
            }
        }

        private void btnCubo_Click(object sender, EventArgs e)
        {
            if (double.TryParse(TxtDefault.Text, out valor2))
            {
                valor1 = Math.Pow(valor2, 3);
                MostrarNaTela(valor1.ToString());
                operador = string.Empty;
                novoNumero = true;
            }
        }
        private void MostrarNaTela(string texto)
        {
            TxtDefault.Clear();
            TxtDefault.Text = texto;
        }
        //Parte da calculadora
        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (TxtDefault.Text == "Erro!")
            {
                expressao = "";
            }
            if (novoNumero)
            {
                TxtDefault.Clear();
                novoNumero = false;
            }


            TxtDefault.Text += btn.Text;
            expressao += btn.Text;
        }

        private void btnOperation_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            string op = btn.Text;

            if (TxtDefault.Text == "Erro!") expressao = "";

            TxtDefault.Text += op;
            expressao += op;
            novoNumero = false;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = new DataTable().Compute(expressao, null);
                MostrarNaTela(resultado.ToString());
                expressao = resultado.ToString(); // permite continuar a conta com o resultado
                novoNumero = true;
            }
            catch
            {
                MostrarNaTela("Erro!");
                expressao = "";
                novoNumero = true;
            }
        }

        private void btnAC_Click(object sender, EventArgs e)
        {
            TxtDefault.Text = "0";
            expressao = "";
            novoNumero = true;
        }

        private void btnPonto_Click(object sender, EventArgs e)
        {
            TxtDefault.Text += ".";
            expressao += ".";
        }



        //Parte da aba 'Sobre'
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn9_Click(object sender, EventArgs e)
        {

        }
    }
}
