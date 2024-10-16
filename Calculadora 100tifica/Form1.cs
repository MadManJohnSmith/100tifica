using operCos;
using operDivi;
using operExp;
using operExp2;
using operExp3;
using operExpX;
using operLog;
using operMulti;
using operPerc;
using operPi;
using operPow10;
using operRaiz2;
using operRaiz3;
using operRaizX;
using operResta;
using operSin;
using operSuma;
using operTan;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Calculadora_100tifica
{
    public partial class Form1 : Form
    {
        double resultado = 0;
        string operador = "";
        bool operadorPresionado = false;
        double ultimoNumero = 0;
        bool nuevaOperacion = false;
        public Form1()
        {
            InitializeComponent();
            labResultado.TextChanged += labResultado_TextChanged;
        }
        private void btn1_Click(object sender, EventArgs e) => AgregarDigito("1");
        private void btn2_Click(object sender, EventArgs e) => AgregarDigito("2");
        private void btn3_Click(object sender, EventArgs e) => AgregarDigito("3");
        private void btn4_Click(object sender, EventArgs e) => AgregarDigito("4");
        private void btn5_Click(object sender, EventArgs e) => AgregarDigito("5");
        private void btn6_Click(object sender, EventArgs e) => AgregarDigito("6");
        private void btn7_Click(object sender, EventArgs e) => AgregarDigito("7");
        private void btn8_Click(object sender, EventArgs e) => AgregarDigito("8");
        private void btn9_Click(object sender, EventArgs e) => AgregarDigito("9");
        private void btn0_Click(object sender, EventArgs e) => AgregarDigito("0");
        private void btnPunto_Click(object sender, EventArgs e) => AgregarDigito(".");

        private void AgregarDigito(string digito)
        {
            if (digito == "." && labResultado.Text.Contains("."))
            {
                return;
            }
            else
            if (operadorPresionado || labResultado.Text == "0")
            {
                labResultado.Text = digito;
                operadorPresionado = false;
            }
            else
            {
                labResultado.Text += digito;
            }
        }
        private void btnSigno_Click(object sender, EventArgs e)
        {
            labResultado.Text = (-1 * Double.Parse(labResultado.Text)).ToString();
        }
        private void btnCE_Click(object sender, EventArgs e)
        {
            labResultado.Text = "0";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            labResultado.Text = "0";
            labOper.Text = "";
            resultado = 0;
            operador = "";
            operadorPresionado = false;
            nuevaOperacion = false;
        }
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (labResultado.Text.Length > 1)
            {
                labResultado.Text = labResultado.Text.Remove(labResultado.Text.Length - 1, 1);
            }
            else
            {
                labResultado.Text = "0";
            }
        }
        private void btnResultado_Click(object sender, EventArgs e)
        {
            if (!nuevaOperacion)
            {
                ultimoNumero = Double.Parse(labResultado.Text);
                labOper.Text += $"{labResultado.Text} =";
                EjecutarOperacion();
                nuevaOperacion = true;
            }
            else
            {
                // Repetir la operación actual
                labOper.Text = $"{resultado} {operador} {ultimoNumero} =";
                RepetirOperacion();
            }
        }
        private void btnSuma_Click(object sender, EventArgs e) => EstablecerOperador("+");
        private void btnResta_Click(object sender, EventArgs e) => EstablecerOperador("-");
        private void btnMulti_Click(object sender, EventArgs e) => EstablecerOperador("*");
        private void btnDivi_Click(object sender, EventArgs e) => EstablecerOperador("/");
        private void EstablecerOperador(string op)
        {
            if (!operadorPresionado)
            {
                operadorPresionado = true;
                operador = op;
                labOper.Text = $"{labResultado.Text} {operador} ";
                resultado = Double.Parse(labResultado.Text);
                nuevaOperacion = false;
            }
            else
            {
                labOper.Text = labOper.Text.TrimEnd() + $" {operador} ";
                operador = op;
                resultado = Double.Parse(labResultado.Text);
            }
        }

        private void RealizarOperacion(string operacion)
        {
            switch (operacion)
            {
                case "+":
                    resultado = Class_Suma.oper_suma(resultado, ultimoNumero);
                    break;
                case "-":
                    resultado = Class_Resta.oper_resta(resultado, ultimoNumero);
                    break;
                case "*":
                    resultado = Class_Multi.oper_multi(resultado, ultimoNumero);
                    break;
                case "/":
                    if (ultimoNumero != 0)
                    {
                        resultado = Class_Divi.oper_divi(resultado, ultimoNumero);
                    }
                    else
                    {
                        labResultado.Text = "Error";
                        return;
                    }
                    break;
                default:
                    resultado = ultimoNumero;
                    break;
            }
            labResultado.Text = resultado.ToString();
        }


        private void EjecutarOperacion()
        {
            RealizarOperacion(operador);
        }

        private void RepetirOperacion()
        {
            RealizarOperacion(operador);
        }

        private void labResultado_TextChanged(object sender, EventArgs e)
        {
            int labelWidth = 284;   // Ancho del label
            int labelHeight = 62;   // Altura del label
            float originalFontSize = 36f;   // Tamaño inicial de la fuente

            Font font = new Font("Product Sans", originalFontSize, FontStyle.Regular);
            labResultado.Font = font;

            SizeF textSize = TextRenderer.MeasureText(labResultado.Text, labResultado.Font);

            while ((textSize.Width > labelWidth || textSize.Height > labelHeight) && font.Size > 8f)
            {
                font = new Font(font.FontFamily, font.Size - 1, font.Style);
                textSize = TextRenderer.MeasureText(labResultado.Text, font);
            }

            labResultado.Font = font;
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            double input = Double.Parse(labResultado.Text);
            double resultado = Class_Exp2.operExp2(input);
            labResultado.Text = resultado.ToString();
        }

        private void btnCubo_Click(object sender, EventArgs e)
        {
            double input = Double.Parse(labResultado.Text);
            double resultado = Class_Exp3.operExp3(input);
            labResultado.Text = resultado.ToString();
        }

        private void btnPot_Click(object sender, EventArgs e)
        {
            double res = Class_ExpX.oper_ExpX(resultado, double.Parse(labResultado.Text));
            labResultado.Text = res.ToString();
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            double input = Double.Parse(labResultado.Text);
            double resultado = Class_Raiz2.operRaiz2(input);
            labResultado.Text = resultado.ToString();
        }

        private void btnRaiz3_Click(object sender, EventArgs e)
        {
            double input = Double.Parse(labResultado.Text);
            double resultado = Class_Raiz3.oper_Raiz3(input);
            labResultado.Text = resultado.ToString();
        }

        private void btnRaizX_Click(object sender, EventArgs e)
        {
            double input = Double.Parse(labResultado.Text);
            double res = Class_RaizX.oper_RaizX(resultado, double.Parse(labResultado.Text));
            labResultado.Text = res.ToString();
        }

        private void btnExp_Click(object sender, EventArgs e)
        {
            double res = Class_Exp.oper_Exp(resultado, double.Parse(labResultado.Text));
            labResultado.Text = res.ToString();
        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {
            double res = Class_Per.oper_Per(resultado, double.Parse(labResultado.Text));
            labResultado.Text = res.ToString();
        }

        private void btnPi_Click(object sender, EventArgs e)
        {
            double resultado = Class_Pi.oper_Pi();
            labResultado.Text = resultado.ToString();
        }

        private void btnSin_Click(object sender, EventArgs e)
        {
            double radianes = Double.Parse(labResultado.Text);
            double resultado = Class_Sin.oper_Sin(radianes);
            labResultado.Text = resultado.ToString();
        }

        private void btnCos_Click(object sender, EventArgs e)
        {
            double radianes = Double.Parse(labResultado.Text);
            double resultado = Class_Cos.oper_Cos(radianes);
            labResultado.Text = resultado.ToString();
        }

        private void btnTan_Click(object sender, EventArgs e)
        {
            double radianes = Double.Parse(labResultado.Text);
            double resultado = Class_Tan.oper_Tan(radianes);
            labResultado.Text = resultado.ToString();
        }

        private void btn10x_Click(object sender, EventArgs e)
        {
            double exponente = Double.Parse(labResultado.Text);
            double resultado = Class_Pow10.oper_Pow10(exponente);
            labResultado.Text = resultado.ToString();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            double numero = Double.Parse(labResultado.Text);
            double resultado = Class_Log.oper_Log(numero);
            labResultado.Text = resultado.ToString();
        }


        private void btnSobreX_Click(object sender, EventArgs e)
        {
            double num = Double.Parse(labResultado.Text);
            if (num != 0)
            {
                labOper.Text = $"1/({num})";
                labResultado.Text = (1 / num).ToString();
            }
            else
            {
                labResultado.Text = "Error";
            }
        }
    }
}
