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

            Progress<int> progress1 = new Progress<int>();
            Progress<int> progress2 = new Progress<int>();
            Progress<int> progress3 = new Progress<int>();
            Progress<int> progress4 = new Progress<int>();

            progress1.ProgressChanged += (sender, e) => { pgb1.Value = e; };
            progress2.ProgressChanged += (sender, e) => { pgb2.Value = e; };
            progress3.ProgressChanged += (sender, e) => { pgb3.Value = e; };
            progress4.ProgressChanged += (sender, e) => { pgb4.Value = e; };

            var res = 0.0;

            try
            {
                res = await Task<double>.Factory.StartNew(() => Trap(cts1.Token, progress1, time1));
            }
            catch (OperationCanceledException)
            {
                Trap_out.Text = "Отмена";
            }
            finally
            {
                Trap_out.Text = Convert.ToString(res);
                eTrap.Text = Convert.ToString(time1.Elapsed);
            }

            try
            {
                res = await Task<double>.Factory.StartNew(() => Trap(cts2.Token, progress2, time2));
            }
            catch (OperationCanceledException)
            {
                Sims_out.Text = "Отмена";
            }
            finally
            {
                Sims_out.Text = Convert.ToString(res);
                eSims.Text = Convert.ToString(time2.Elapsed);
            }

            try
            {
                res = await Task<double>.Factory.StartNew(() => Trap(cts3.Token, progress3, time3));
            }
            catch (OperationCanceledException)
            {
                pTrap_out.Text = "Отмена";
            }
            finally
            {
                pTrap_out.Text = Convert.ToString(res);
                epTrap.Text = Convert.ToString(time3.Elapsed);
            }

            try
            {
                res = await Task<double>.Factory.StartNew(() => Trap(cts4.Token, progress4, time4));
            }
            catch (OperationCanceledException)
            {
                pSims_out.Text = "Отмена";
            }
            finally
            {
                pSims_out.Text = Convert.ToString(res);
                epSims.Text = Convert.ToString(time4.Elapsed);
            }
        }

        private double Trap(CancellationToken token, IProgress<int> progress, Stopwatch time)
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

                    res = Math.Round(p.Trap(num1, num2, num3, token, progress, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double Sims(CancellationToken token, IProgress<int> progress, Stopwatch time)
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

                    res = Math.Round(q.Sims(num1, num2, num3, token, progress, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double pTrap(CancellationToken token, IProgress<int> progress, Stopwatch time)
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

                    res = Math.Round(p.pTrap(num1, num2, num3, token, progress, x => 2.0 * x - Math.Log(2.0 * x) + 234.0), 3);

                    time.Stop();
                }
            }

            return res;
        }

        private double pSims(CancellationToken token, IProgress<int> progress, Stopwatch time)
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
