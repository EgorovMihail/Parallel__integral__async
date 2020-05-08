using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace integral
{
    public partial class integral__Form : Form
    {
        public integral__Form()
        {
            InitializeComponent();
        }

       

    private void Trap()
    {
            //Progress<int> progress = new Progress<int>();
            //progress.ProgressChanged += (sender, e) => { pgb.Value = e; };
            //bool answerReady = true;

            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                IntegralMath p = new IntegralMath();
                double num1, num2, num3;

                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool HisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (HisNum) && (num1 <= num2) && (num3 >= 0.0) && (num1 > 0.0))
                {
                    Stopwatch t1 = Stopwatch.StartNew();

                    Trap_out.Text = Convert.ToString(Math.Round(p.Trap(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3));

                    t1.Stop();

                    eTrap.Text = Convert.ToString(t1.Elapsed);

                    hints.Text = "работаем...";
                }
                else
                {
                    hints.Text = "Проверьте корректность введенных данных";
                } 
            }
            else
            {
                hints.Text = "Введите параметры интегрирования";
            }
        }

        private void Sims()
        {       
            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                IntegralMath q = new IntegralMath();
                double num1, num2, num3;

                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool MisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (MisNum) && (num1 <= num2) && (num3 > 0) && (num1 > 0.0))
                {
                    Stopwatch t1 = Stopwatch.StartNew();

                    Sims_out.Text = Convert.ToString(Math.Round(q.Sims(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3));

                    t1.Stop();

                    eSims.Text = Convert.ToString(t1.Elapsed);

                    hints.Text = "работаем...";
                }
                else {
                    hints.Text = "Проверьте корректность введенных данных";
                }
            }
            else
            {
                hints.Text = "Введите параметры интегрирования";
            }
        }


        private void pTrap()
        {
            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                IntegralMath p = new IntegralMath();
                double num1, num2, num3;

                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool HisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (HisNum) && (num1 <= num2) && (num3 >= 0.0) && (num1 > 0.0))
                {
                    Stopwatch t1 = Stopwatch.StartNew();

                    pTrap_out.Text = Convert.ToString(Math.Round(p.pTrap(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3));

                    t1.Stop();

                    epTrap.Text = Convert.ToString(t1.Elapsed);

                    hints.Text = "работаем...";
                }
                else
                {
                    hints.Text = "Проверьте корректность введенных данных";
                }
            }
            else
            {
                hints.Text = "Введите параметры интегрирования";
            }
        }

      
        private void pSims()
        {
            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                IntegralMath q = new IntegralMath();
                double num1, num2, num3;

                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool MisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (MisNum) && (num1 <= num2) && (num3 > 0) && (num1 > 0.0))
                {
                    Stopwatch t1 = Stopwatch.StartNew();

                    pSims_out.Text = Convert.ToString(Math.Round(q.pSims(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3));

                    t1.Stop();

                    epSims.Text = Convert.ToString(t1.Elapsed);

                    hints.Text = "работаем...";
                }
                else
                {
                    hints.Text = "Проверьте корректность введенных данных";
                }
            }
        }


        private void border__b_TextChanged(object sender, EventArgs e)
        {
            Trap();
            Sims();
            pTrap();
            pSims();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            Trap();
            Sims();
            pTrap();
            pSims();
        }

        private void border__a_TextChanged_1(object sender, EventArgs e)
        {
            Trap();
            Sims();
            pTrap();
            pSims();
        }

        private void integral__Form_Load(object sender, EventArgs e)
        {

        }
    }
}
