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
        private CancellationTokenSource cts1, cts2, cts3, cts4;
        private Stopwatch time1, time2, time3, time4;

        public integral__Form()
        {
            InitializeComponent();
        }

        private async void DoAsync()
        {
            time1 = new Stopwatch();
            time2 = new Stopwatch();
            time3 = new Stopwatch();
            time4 = new Stopwatch();
            cts1 = new CancellationTokenSource();
            cts2 = new CancellationTokenSource();
            cts3 = new CancellationTokenSource();
            cts4 = new CancellationTokenSource();

            await Task<double>.Factory.StartNew(() => Trap(cts1.Token, time1)).ContinueWith(task => {

                if (task.IsFaulted)
                {
                    Trap_out.Text = "ошибка";
                }
                else if (task.IsCanceled || cts1.Token.IsCancellationRequested)
                {
                    Trap_out.Text = "Отменен";
                }
                else
                {
                    Trap_out.Text = Convert.ToString(task.Result);
                    eTrap.Text = Convert.ToString(time1.Elapsed);
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());

            await Task<double>.Factory.StartNew(() => Sims(cts2.Token, time2)).ContinueWith(task => {

                if (task.IsFaulted)
                {
                    Sims_out.Text = "ошибка";
                }
                else if (task.IsCanceled || cts2.Token.IsCancellationRequested)
                {
                    Sims_out.Text = "Отменен";
                }
                else
                {
                    Sims_out.Text = Convert.ToString(task.Result);
                    eSims.Text = Convert.ToString(time2.Elapsed);
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());


            await Task<double>.Factory.StartNew(() => pTrap(cts3.Token, time3)).ContinueWith(task => {

                if (task.IsFaulted)
                {
                    pTrap_out.Text = "ошибка";
                }
                else if (task.IsCanceled || cts3.Token.IsCancellationRequested)
                {
                    pTrap_out.Text = "Отменен";
                }
                else
                {
                    pTrap_out.Text = Convert.ToString(task.Result);
                    epTrap.Text = Convert.ToString(time3.Elapsed);
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());

            await Task<double>.Factory.StartNew(() => pSims(cts4.Token, time4)).ContinueWith(task => {

                if (task.IsFaulted)
                {
                    pSims_out.Text = "ошибка";
                }
                else if (task.IsCanceled || cts4.Token.IsCancellationRequested)
                {
                    pSims_out.Text = "Отменен";
                }
                else
                {
                    pSims_out.Text = Convert.ToString(task.Result);
                    epSims.Text = Convert.ToString(time4.Elapsed);
                }

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private double Trap(CancellationToken token, Stopwatch time)
        {
            Progress<int> progress = new Progress<int>();

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

                    res = Math.Round(p.Trap(num1, num2, num3, token, progress, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double Sims(CancellationToken token, Stopwatch time)
        {
            Progress<int> progress = new Progress<int>();

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

                    res = Math.Round(q.Sims(num1, num2, num3, token, progress, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double pTrap(CancellationToken token, Stopwatch time)
        {
            Progress<int> progress = new Progress<int>();

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

                    res = Math.Round(p.pTrap(num1, num2, num3, token, progress, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double pSims(CancellationToken token, Stopwatch time)
        {
            Progress<int> progress = new Progress<int>();

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

                    res = Math.Round(q.pSims(num1, num2, num3, token, progress, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

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

        private void cancel_Sims_Click(object sender, EventArgs e)
        {
            if (cts2 != null)
            {
                cts2.Cancel();
            }
        }
        private void cancel_Trap_Click(object sender, EventArgs e)
        {
            if (cts1 != null)
            {
                cts1.Cancel();
            }
        }
        private void cancel_pSims_Click(object sender, EventArgs e)
        {
            if (cts4 != null)
            {
                cts4.Cancel();
            }
        }
        private void cancel_pTrap_Click(object sender, EventArgs e)
        {
            if (cts3 != null)
            {
                cts3.Cancel();
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            if ((cts1 != null) && (cts2 != null) && (cts3 != null) && (cts4 != null))
            {
                cts1.Cancel();
                cts2.Cancel();
                cts3.Cancel();
                cts4.Cancel();
            }
        }

        private void integral__Form_Load(object sender, EventArgs e)
        {

        }
    }
}
