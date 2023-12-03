using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
namespace KursachBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void D1Method1_CheckedChanged(object sender, EventArgs e)
        {
            D1Method1GroupBox.Visible = true;
            D1Method2GroupBox.Visible = false;
            D1Method3GroupBox.Visible = false;
            ThicknessTextBox.Text = "";
        }
        private void D1Method2_CheckedChanged(object sender, EventArgs e)
        {
            D1Method1GroupBox.Visible = false;
            D1Method2GroupBox.Visible = true;
            D1Method3GroupBox.Visible = false;
            ThicknessTextBox.Text = "";
        }
        private void D1Method3_CheckedChanged(object sender, EventArgs e)
        {
            D1Method1GroupBox.Visible = false;
            D1Method2GroupBox.Visible = false;
            D1Method3GroupBox.Visible = true;
            ThicknessTextBox.Text = "";
        }

        private void calcD1Method1()
        {
            if (D1Method1NTextBox.Text.Length == 0 || D1Method1n1TextBox.Text.Length == 0)
            {
                D1Method1D1TextBox.Text = "";
            }
            else
            {
                double D1 = 0;
                double N = 0;
                double n1 = 0;
                if (Double.TryParse(D1Method1NTextBox.Text, out N) && Double.TryParse(D1Method1n1TextBox.Text, out n1))
                {
                    D1 = 110 * Math.Pow((N * 1000 / n1), 1.0 / 3);
                    this.D1Method1D1TextBox.Text = Convert.ToString(D1);
                }

            }
        }

        private void D1Method1Button_Click(object sender, EventArgs e)
        {
            calcD1Method1();
        }

        private void D1Method2Button_Click(object sender, EventArgs e)
        {
            calcD1Method2();
        }
        private void calcD1Method2()
        {
            if (D1Method2vTextBox.Text.Length == 0 || D1Method2n1TextBox.Text.Length == 0)
            {
                D1Method2D1TextBox.Text = "";
            }
            else
            {
                double D1 = 0;
                double v = 0;
                double n1 = 0;
                if (Double.TryParse(D1Method2vTextBox.Text, out v) && Double.TryParse(D1Method2n1TextBox.Text, out n1))
                {
                    D1 = (v / n1) * 60000;
                    this.D1Method2D1TextBox.Text = Convert.ToString(D1);
                }

            }
        }

        private void DminBetaMaterialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DminBetaMaterialComboBox.SelectedIndex)
            {
                case 0:
                    {
                        DminBetaValueTextBox.Text = "40";
                        break;
                    }
                case 1:
                    {
                        DminBetaValueTextBox.Text = "130";
                        break;
                    }
            }
        }

        private void ThicknessButton_Click(object sender, EventArgs e)
        {
            double D1 = 0;
            double DminBeta = 0;
            double beta = 0;
            if (DminBetaValueTextBox.Text.Length != 0 && Double.TryParse(DminBetaValueTextBox.Text, out DminBeta))
            {
                if (D1Method1.Checked)
                {
                    if (D1Method1D1TextBox.Text.Length != 0 && Double.TryParse(D1Method1D1TextBox.Text, out D1))
                    {
                        beta = D1 / DminBeta;
                        ThicknessTextBox.Text = Convert.ToString(beta);
                    }
                    else
                    {
                        ThicknessTextBox.Text = "";
                    }
                }
                else if (D1Method2.Checked)
                {
                    if (D1Method2D1TextBox.Text.Length != 0 && Double.TryParse(D1Method2D1TextBox.Text, out D1))
                    {
                        beta = D1 / DminBeta;
                        ThicknessTextBox.Text = Convert.ToString(beta);
                    }
                    else
                    {
                        ThicknessTextBox.Text = "";
                    }
                }
                else if (D1Method3.Checked)
                {
                    if (D1Method3D1TextBox.Text.Length != 0 && Double.TryParse(D1Method3D1TextBox.Text, out D1))
                    {

                        beta = D1 / DminBeta;
                        ThicknessTextBox.Text = Convert.ToString(beta);
                    }
                    else
                    {
                        ThicknessTextBox.Text = "";
                    }
                }
            }
            else
            {
                ThicknessTextBox.Text = "";
            }
        }
        private void CalcF()
        {
            double Nv;
            double F;
            if (NvTextBox.Text.Length != 0 && Double.TryParse(NvTextBox.Text, out Nv))
            {
                F = Nv * 1000;
                FTextBox.Text = Convert.ToString(F);
            }
            else
            {
                FTextBox.Text = "";
            }
        }
        private void CalcNV()
        {
            double N;
            double v;
            double Nv;
            if (NTextBox.Text.Length != 0 && Double.TryParse(NTextBox.Text, out N) && vTextBox.Text.Length != 0 && Double.TryParse(vTextBox.Text, out v))
            {
                Nv = N / v;
                NvTextBox.Text = Convert.ToString(Nv);
            }
            else
            {
                NvTextBox.Text = "";
                FTextBox.Text = "";
            }
        }
        private void FButton_Click(object sender, EventArgs e)
        {
            CalcF();
        }

        private void NTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcNV();
        }

        private void vTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcNV();
        }

        private void D2Button_Click(object sender, EventArgs e)
        {
            double Koef = 0;
            double u = 0;
            double D2 = 0;
            double D1 = 0;

            if (Double.TryParse(KoefComboBox.Text, out Koef) && Double.TryParse(utextBox.Text, out u))
            {
                if (D1Method1.Checked)
                {
                    Double.TryParse(D1Method1D1TextBox.Text, out D1);
                }
                else if (D1Method2.Checked)
                {
                    Double.TryParse(D1Method2D1TextBox.Text, out D1);
                }
                else if (D1Method3.Checked)
                {
                    Double.TryParse(D1Method3D1TextBox.Text, out D1);
                }
                if (D1 != 0)
                {
                    if (D2Method1.Checked)
                    {
                        D2 = D1 * (1 - Koef) * u;
                        D2TextBox.Text = Convert.ToString(D2);
                    }
                    else if (D2Method2.Checked)
                    {
                        D2 = D1 * u / (1 - Koef);
                        D2TextBox.Text = Convert.ToString(D2);
                    }
                    else
                    {
                        D2TextBox.Text = "";
                    }
                }
                else
                {
                    D2TextBox.Text = "";
                }
            }
        }
        private void alphaButton_Click(object sender, EventArgs e)
        {
            double D1 = 0;
            double D2 = 0;
            double alpha = 0;
            if (D1Method1.Checked)
            {
                Double.TryParse(D1Method1D1TextBox.Text, out D1);
            }
            else if (D1Method2.Checked)
            {
                Double.TryParse(D1Method2D1TextBox.Text, out D1);
            }
            else if (D1Method3.Checked)
            {
                Double.TryParse(D1Method3D1TextBox.Text, out D1);
            }
            if (D1 != 0)
            {
                if(Double.TryParse(D2TextBox.Text, out D2))
                {
                    alpha= (D1+D2)*1.5;
                    alphaTextBox.Text = Convert.ToString(alpha);
                }
                else
                {
                    alphaTextBox.Text = "";
                }
            }
            else
            {
                alphaTextBox.Text = "";
            }
        }
        private void calcu()
        {
            double n1;
            double n2;
            double u;
            if (n1TextBox.Text.Length != 0 && Double.TryParse(n1TextBox.Text, out n1) && n2textBox.Text.Length != 0 && Double.TryParse(n2textBox.Text, out n2))
            {
                u = n1 / n2;
                utextBox.Text = Convert.ToString(u);
            }
            else
            {
                utextBox.Text = "";
            }
        }
        private void n1TextBox_TextChanged(object sender, EventArgs e)
        {
            calcu();
        }

        private void n2textBox_TextChanged(object sender, EventArgs e)
        {
            calcu();
        }

        private void sigmaF0Button_Click(object sender, EventArgs e)
        {
            double A = 0;
            double W = 0;
            double beta = 0;
            double D1 = 0;
            double betaD1 = 0;
            double sigmaF0 = 0;
            switch (DminBetaMaterialComboBox.SelectedIndex)
            {

                case 0: //Ткань
                    {
                        switch (sigma0ComboBox.SelectedIndex)
                        {
                            case 0: //1,6
                                {
                                    A = 2.3;
                                    W = 9;
                                    break;
                                }
                            case 1: //1,8
                                {
                                    A = 2.5;
                                    W = 10;
                                    break;
                                }
                            case 2: //2
                                {
                                    A = 2.7;
                                    W = 11;
                                    break;
                                }
                            case 3: //2.4
                                {
                                    A = 3.05;
                                    W = 13.5;
                                    break;
                                }
                        }
                        break;
                    }
                case 1: //Синтетика
                    {
                        switch (sigma0ComboBox.SelectedIndex)
                        {
                            case 0: //1,6
                                {
                                    A = 5.75;
                                    W = 176;
                                    break;
                                }
                            case 1: //1,8
                                {
                                    A = 7;
                                    W = 220;
                                    break;
                                }
                            case 2: //2
                                {
                                    A = 9.6;
                                    W = 330;
                                    break;
                                }
                            case 3: //2.4
                                {
                                    A = 11.6;
                                    W = 440;
                                    break;
                                }
                        }
                        break;
                    }
            }
            if (D1Method1.Checked)
            {
                Double.TryParse(D1Method1D1TextBox.Text, out D1);
            }
            else if (D1Method2.Checked)
            {
                Double.TryParse(D1Method2D1TextBox.Text, out D1);
            }
            else if (D1Method3.Checked)
            {
                Double.TryParse(D1Method3D1TextBox.Text, out D1);
            }
            if (D1 != 0)
            {
                if (Double.TryParse(ThicknessTextBox.Text, out beta))
                {
                    betaD1 = beta / D1;
                    sigmaF0 = A - W * betaD1;
                    sigmaF0TextBox.Text = Convert.ToString(sigmaF0);
                    ATextBox.Text = Convert.ToString(A);
                    WTextBox.Text = Convert.ToString(W);
                    betaD1TextBox.Text = Convert.ToString(betaD1);
                }
            }

        }

        private void altushka2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (altushka2ComboBox.SelectedIndex)
            {
                case 0:
                    {
                        Altushka3ComboBox.Visible = false;
                        Altushka3Label.Visible = false;
                        C0TextBox.Text = "1";
                        break;
                    }
                case 1:
                    {
                        Altushka3ComboBox.Visible = false;
                        Altushka3Label.Visible = false;
                        C0TextBox.Text = "1";
                        break;
                    }
                case 2:
                    {
                        Altushka3ComboBox.Visible = true;
                        Altushka3Label.Visible = true;
                        C0TextBox.Text = "";
                        break;
                    }
            }
        }

        private void Altushka3ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (Altushka3ComboBox.SelectedIndex)
            {
                case 0:
                    {
                        C0TextBox.Text = "1";
                        break;
                    }
                case 1:
                    {
                        C0TextBox.Text = "0,9";
                        break;
                    }
                case 2:
                    {
                        C0TextBox.Text = "0,8";
                        break;
                    }
            }
        }

        private void C1Button_Click(object sender, EventArgs e)
        {
            double D2 = 0;
            double D1 = 0;
            double alpha = 0;
            double alpha1 = 0;
            if (D1Method1.Checked)
            {
                Double.TryParse(D1Method1D1TextBox.Text, out D1);
            }
            else if (D1Method2.Checked)
            {
                Double.TryParse(D1Method2D1TextBox.Text, out D1);
            }
            else if (D1Method3.Checked)
            {
                Double.TryParse(D1Method3D1TextBox.Text, out D1);
            }
            if (D1 != 0)
            {
                if(Double.TryParse(D2TextBox.Text, out D2))
                {
                    if(Double.TryParse(alphaTextBox.Text, out alpha))
                    {
                        alpha1 = 180 - ((D2 - D1) / alpha) * 57;
                        alpha1TextBox.Text=Convert.ToString(alpha1);
                    }
                    else
                    {
                        alpha1TextBox.Text = "";
                    }
                }
                else
                {
                    alpha1TextBox.Text = "";
                }
            }
            else
            {
                alpha1TextBox.Text = "";
            }
            if (alpha1<110)
            {
                C1TextBox.Text = "0,79";
            }
            else if (alpha1<120)
            {
                C1TextBox.Text = "0,82";
            }
            else if (alpha1 < 130)
            {
                C1TextBox.Text = "0,85";
            }
            else if (alpha1 < 140)
            {
                C1TextBox.Text = "0,88";
            }
            else if (alpha1 < 150)
            {
                C1TextBox.Text = "0,91";
            }
            else if (alpha1 < 160)
            {
                C1TextBox.Text = "0,94";
            }
            else if (alpha1 < 170)
            {
                C1TextBox.Text = "0,97";
            }
            else
            {
                C1TextBox.Text = "1";
            }

        }

        private void C2Button_Click(object sender, EventArgs e)
        {

            double D1 = 0;
            double n1 = 0;
            double v = 0;
            double pi = 3.1415926535;
            if (D1Method1.Checked)
            {
                Double.TryParse(D1Method1D1TextBox.Text, out D1);
            }
            else if (D1Method2.Checked)
            {
                Double.TryParse(D1Method2D1TextBox.Text, out D1);
            }
            else if (D1Method3.Checked)
            {
                Double.TryParse(D1Method3D1TextBox.Text, out D1);
            }
            if (D1 != 0)
            {
                if (Double.TryParse(n1TextBox.Text, out n1))
                {
                    v = pi * D1 * n1 / 60000;
                    C2vTextBox.Text=Convert.ToString(v);
                }
                else
                {
                    C2vTextBox.Text = "";
                }
            }
            else
            {
                C2vTextBox.Text = "";
            }

            if (v == 0)
            {
                C2TextBox.Text = "";
            }
            else
            {
                switch(DminBetaMaterialComboBox.SelectedIndex) 
                {
                    case 0:
                        {
                            if(v<10)
                            {
                                C2TextBox.Text = "1,03";
                            }
                            else if (v<15)
                            {
                                C2TextBox.Text = "1,00";
                            }
                            else if (v < 20)
                            {
                                C2TextBox.Text = "0,95";
                            }
                            else if (v < 25)
                            {
                                C2TextBox.Text = "0,88";
                            }
                            else if (v < 30)
                            {
                                C2TextBox.Text = "0,79";
                            }
                            else if (v < 35)
                            {
                                C2TextBox.Text = "0,68";
                            }
                            else
                            {
                                C2TextBox.Text = "-";
                            }
                            break;
                        }
                    case 1: 
                        {
                            if (v < 10)
                            {
                                C2TextBox.Text = "1,01";
                            }
                            else if (v < 15)
                            {
                                C2TextBox.Text = "1,00";
                            }
                            else if (v < 20)
                            {
                                C2TextBox.Text = "0,99";
                            }
                            else if (v < 25)
                            {
                                C2TextBox.Text = "0,97";
                            }
                            else if (v < 30)
                            {
                                C2TextBox.Text = "0,95";
                            }
                            else if (v < 35)
                            {
                                C2TextBox.Text = "0,92";
                            }
                            else if (v < 40)
                            {
                                C2TextBox.Text = "0,89";
                            }
                            else if (v < 50)
                            {
                                C2TextBox.Text = "0,85";
                            }
                            else if (v < 70)
                            {
                                C2TextBox.Text = "0,76";
                            }
                            else if (v < 80)
                            {
                                C2TextBox.Text = "0,52";
                            }
                            else 
                            {
                                C2TextBox.Text = "-";
                            }
                            break;
                        }
                }
            }
        }
        private void calcC3()
        {
            switch(HARAKTERComboBox.SelectedIndex) 
            {
                case 0:
                    {
                        switch(DVIGATELComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    C3TextBox.Text = "1";
                                    break;
                                }
                            case 1:
                                {
                                    C3TextBox.Text = "0,9";
                                    break;
                                }
                        }
                        break;
                    }
                    case 1:
                    {
                        switch (DVIGATELComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    C3TextBox.Text = "0,9";
                                    break;
                                }
                            case 1:
                                {
                                    C3TextBox.Text = "0,8";
                                    break;
                                }
                        }
                        break;
                    }
                    case 2: 
                    {
                        switch (DVIGATELComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    C3TextBox.Text = "0,8";
                                    break;
                                }
                            case 1:
                                {
                                    C3TextBox.Text = "0,7";
                                    break;
                                }
                        }
                        break;
                    }
                    case 3:
                    {
                        switch (DVIGATELComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    C3TextBox.Text = "0,7";
                                    break;
                                }
                            case 1:
                                {
                                    C3TextBox.Text = "0,6";
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        private void HARAKTERComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcC3();
        }

        private void DVIGATELComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calcC3();
        }

        private void sigmaFButton_Click(object sender, EventArgs e)
        {
            double sigmaF0 = 0;
            double C0 = 0;
            double C1 = 0;
            double C2 = 0;
            double C3 = 0;
            if (Double.TryParse(sigmaF0TextBox.Text, out sigmaF0) && 
                Double.TryParse(C0TextBox.Text, out C0) && Double.TryParse(C1TextBox.Text, out C1) && 
                Double.TryParse(C2TextBox.Text, out C2) &&
                Double.TryParse(C3TextBox.Text, out C3)) 
            {
                double sigmaF = sigmaF0 * C0 * C1 * C2 * C3;
                sigmaFTextBox.Text=Convert.ToString(sigmaF);
            }
            else
            {
                sigmaFTextBox.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double beta = 0;
            double F = 0;
            double sigmaF = 0;
            double b = 0;
            if (Double.TryParse(ThicknessTextBox.Text,out beta)&&Double.TryParse(FTextBox.Text,out F)&&Double.TryParse(sigmaFTextBox.Text,out sigmaF))
            {
                b = F / (beta * sigmaF);
                bTextBox.Text=Convert.ToString(b);
                DateTime currentDate = DateTime.Now;
                string formattedDate = currentDate.ToString("yyyy-MM-dd HH:mm:ss");

                // Создаем строку, которую мы хотим записать в файл
                string lineToWrite = $"{formattedDate}: b = {b}";

                // Указываем путь к файлу result.txt
                string filePath = "C:/Users/V/desktop/result.txt";

                // Записываем строку в файл, используя StreamWriter
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(lineToWrite);
                }
            }
            else
            {
                bTextBox.Text = "";
            }
        }
    }
}
