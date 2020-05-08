using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace integral
{
    public partial class integral__Form : Form
    {
        private CancellationTokenSource cts;
        private Stopwatch time1, time2, time3, time4;

        public integral__Form()
        {
            InitializeComponent();
        }

<<<<<<< HEAD

    private void Trap()
    {
            pbg.Value = 0;

            Progress<double> progress = new Progress<double>();
           
=======
        private async void DoAsync()
        {
            time1 = new Stopwatch();
            time2 = new Stopwatch();
            time3 = new Stopwatch();
            time4 = new Stopwatch();
            cts = new CancellationTokenSource();

            await Task<double>.Factory.StartNew(() => Trap(time1)).ContinueWith(task => {

                Trap_out.Text = Convert.ToString(task.Result);
                eTrap.Text = Convert.ToString(time1.Elapsed);

            }, TaskScheduler.FromCurrentSynchronizationContext());

            await Task<double>.Factory.StartNew(() => Sims(time2)).ContinueWith(task => {

                Sims_out.Text = Convert.ToString(task.Result);
                eSims.Text = Convert.ToString(time2.Elapsed);

            }, TaskScheduler.FromCurrentSynchronizationContext());

            await Task<double>.Factory.StartNew(() => pTrap(time3)).ContinueWith(task => {

                pTrap_out.Text = Convert.ToString(task.Result);
                epTrap.Text = Convert.ToString(time3.Elapsed);

            }, TaskScheduler.FromCurrentSynchronizationContext());

            await Task<double>.Factory.StartNew(() => pSims(time4)).ContinueWith(task => {

                pSims_out.Text = Convert.ToString(task.Result);
                epSims.Text = Convert.ToString(time4.Elapsed);

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private double Trap(Stopwatch time)
        {
            //Progress<int> progress = new Progress<int>();
            //progress.ProgressChanged += (sender, e) => { pgb.Value = e; };
            //bool answerReady = true;
>>>>>>> 059225ab0f241d31f894fc5e7349d9f8ffa4bc9d

            IntegralMath p = new IntegralMath();
            double num1, num2, num3, res = 0.0;

            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool HisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (HisNum) && (num1 <= num2) && (num3 >= 0.0) && (num1 > 0.0))
                {
                    time.Start();

                    res = Math.Round(p.Trap(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

<<<<<<< HEAD
        private void Sims()
        {
=======
        private double Sims(Stopwatch time)
        {
            IntegralMath q = new IntegralMath();
            double num1, num2, num3, res = 0.0;

>>>>>>> 059225ab0f241d31f894fc5e7349d9f8ffa4bc9d
            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool MisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (MisNum) && (num1 <= num2) && (num3 > 0) && (num1 > 0.0))
                {
                    time.Start();

                    res = Math.Round(q.Sims(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double pTrap(Stopwatch time)
        {
            IntegralMath p = new IntegralMath();
            double num1, num2, num3, res = 0.0;

            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool HisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (HisNum) && (num1 <= num2) && (num3 >= 0.0) && (num1 > 0.0))
                {
                    time.Start();

                    res = Math.Round(p.pTrap(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double pSims(Stopwatch time)
        {
            IntegralMath q = new IntegralMath();
            double num1, num2, num3, res = 0.0;

            if ((border__a.Text != "") && (border__b.Text != "") && (step_in.Text != ""))
            {
                string a = border__a.Text;
                string b = border__b.Text;
                string h = step_in.Text;

                bool AisNum = double.TryParse(a, out num1);
                bool BisNum = double.TryParse(b, out num2);
                bool MisNum = double.TryParse(h, out num3);

                if ((AisNum) && (BisNum) && (MisNum) && (num1 <= num2) && (num3 > 0) && (num1 > 0.0))
                {
                    time.Start();

                    res = Math.Round(q.pSims(num1, num2, num3, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private void border__b_TextChanged(object sender, EventArgs e)
        {
            DoAsync();
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            DoAsync();
        }

        private void border__a_TextChanged_1(object sender, EventArgs e)
        {
            DoAsync();
        }

        private void integral__Form_Load(object sender, EventArgs e)
        {

        }
    }
}
