using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace LameOBSTimer
{
    public partial class LameOBSTimer : Form
    {
        public LameOBSTimer()
        {
            InitializeComponent();
        }

        LameObsTimerWindow lotw = new LameObsTimerWindow();
        IEnumerable<SixLabors.Fonts.FontFamily> fams = SixLabors.Fonts.SystemFonts.Families;

        bool loading = false;

        private void LameOBSTimer_Load(object sender, EventArgs e)
        {
            loading = true;
            foreach (SixLabors.Fonts.FontFamily fam in fams)
            {
                {
                    cbFont.Items.Add(fam);
                }
            }
            cbFont.SelectedIndex = 0;

            lotw.Show();

            LoadConfig();

            ts = new TimeSpan(0, (int)nudMinutes.Value, (int)nudSeconds.Value);
            lotw.lt.Text = ts.ToString(@"mm\:ss");

            lotw.Render();


            loading = false;
        }

        private void cbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            lotw.lt.FontName = ((SixLabors.Fonts.FontFamily)(cbFont.SelectedItem)).Name;
            lotw.Render();

            SaveConfig();
        }

        private void bFontColor_Click(object sender, EventArgs e)
        {
            if (cdFontColor.ShowDialog() == DialogResult.OK)
            {
                this.bFontColor.BackColor = cdFontColor.Color;

                SaveConfig();
            }
        }

        private void bFontColor_BackColorChanged(object sender, EventArgs e)
        {
            lotw.lt.FontColor = bFontColor.BackColor;
            lotw.Render();

            SaveConfig();
        }

        private void nudFont_ValueChanged(object sender, EventArgs e)
        {
            lotw.lt.FontSize = (int)nudFont.Value;
            lotw.Render();

            SaveConfig();
        }

        private void cbBold_CheckedChanged(object sender, EventArgs e)
        {
            lotw.lt.FontBold = cbBold.Checked;
            lotw.Render();

            SaveConfig();
        }

        private void cbItalic_CheckedChanged(object sender, EventArgs e)
        {
            lotw.lt.FontItalic = cbItalic.Checked;
            lotw.Render();

            SaveConfig();
        }

        private void nudOutline_ValueChanged(object sender, EventArgs e)
        {
            lotw.lt.Outline = (int)nudOutline.Value;
            lotw.Render();

            SaveConfig();
        }

        private void bOutlineColor_Click(object sender, EventArgs e)
        {
            if (cdOutlineColor.ShowDialog() == DialogResult.OK)
            {
                this.bOutlineColor.BackColor = cdOutlineColor.Color;
            }
        }

        private void bOutlineColor_BackColorChanged(object sender, EventArgs e)
        {
            lotw.lt.OutlineColor = this.bOutlineColor.BackColor;
            lotw.Render();

            SaveConfig();
        }

        private void bBackgroundColor_Click(object sender, EventArgs e)
        {
            if (cdBackgroundColor.ShowDialog() == DialogResult.OK)
            {
                this.bBackgroundColor.BackColor = cdBackgroundColor.Color;
            }
        }

        private void bBackgroundColor_BackColorChanged(object sender, EventArgs e)
        {
            lotw.lt.BackgroundColor = this.bBackgroundColor.BackColor;
            lotw.Render();

            SaveConfig();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            ts = new TimeSpan(0, (int)nudMinutes.Value, (int)nudSeconds.Value);
            this.bStart.Enabled = false;
            this.bPause.Enabled = true;
            this.bStop.Enabled = true;
            this.bEndAt.Enabled = false;
            timerWorker.RunWorkerAsync();
        }

        TimeSpan ts = new TimeSpan();

        bool pause = false;

        private void timerWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            do
            {
                if (!pause)
                {
                    lotw.lt.Text = ts.ToString(@"mm\:ss");
                    ts = ts.Add(new TimeSpan(0, 0, -1));

                    lotw.Render();
                }

                Thread.Sleep(1000);
            }
            while (ts.TotalSeconds > -1 && !timerWorker.CancellationPending);
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            this.pause = !this.pause;
            if (this.pause)
            {
                bPause.Text = "Unpause";
            }
            else
            {
                bPause.Text = "Pause";
            }
        }

        private void bStop_Click(object sender, EventArgs e)
        {
            timerWorker.CancelAsync();
            this.bStart.Enabled = true;
            this.bPause.Enabled = false;
            this.bPause.Text = "Pause";
            this.pause = false;
            this.bStop.Enabled = false;
            this.bEndAt.Enabled = true;

            ts = new TimeSpan(0, (int)nudMinutes.Value, (int)nudSeconds.Value);
            lotw.lt.Text = ts.ToString(@"mm\:ss");

            lotw.Render();
        }

        private void bEndAt_Click(object sender, EventArgs e)
        {
            bEndAt.Enabled = true;

            ts = dtpEndAt.Value - DateTime.Now;

            this.bStart.Enabled = false;
            this.bPause.Enabled = true;
            this.bStop.Enabled = true;
            this.bEndAt.Enabled = false;
            timerWorker.RunWorkerAsync();
        }

        const string KONFIG_V1 = "KONFIG_V1";
        const string KONFIG_FILENAME = "konfig.lot";

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(KONFIG_FILENAME))
                {
                    using (TextReader tr = new StreamReader(KONFIG_FILENAME))
                    {
                        if (tr.ReadLine() != KONFIG_V1)
                        {
                            throw new Exception("FILE FORMAT ERROR");
                            tr.Close();
                        }

                        TimeSpan ts = TimeSpan.Parse(tr.ReadLine());
                        nudMinutes.Value = ts.Minutes;
                        nudSeconds.Value = ts.Seconds;
                        cbFont.SelectedItem = LoadFont(tr.ReadLine());
                        bFontColor.BackColor = this.ToWFColor(LoadColor(tr.ReadLine()));
                        nudFont.Value = LoadDecimal(tr.ReadLine());
                        cbBold.Checked = LoadBool(tr.ReadLine());
                        cbItalic.Checked = LoadBool(tr.ReadLine());
                        nudOutline.Value = LoadDecimal(tr.ReadLine());
                        bOutlineColor.BackColor = this.ToWFColor(LoadColor(tr.ReadLine()));
                        bBackgroundColor.BackColor = this.ToWFColor(LoadColor(tr.ReadLine()));

                        tr.Close();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Configuration file loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private SixLabors.Fonts.FontFamily LoadFont(string s)
        {
            foreach (SixLabors.Fonts.FontFamily fam in fams)
            {
                if (fam.Name == s)
                {
                    return fam;
                }
            }

            return fams.First();
        }

        private SixLabors.ImageSharp.Color LoadColor(string s)
        {
            try
            {
                return SixLabors.ImageSharp.Color.ParseHex(s);
            }
            catch
            {
            }

            return SixLabors.ImageSharp.Color.Black;
        }

        private decimal LoadDecimal(string s)
        {
            decimal d = 0;

            if (s.Contains("."))
            {
                s = s.Substring(0, s.IndexOf("."));
            }

            if (s.Contains(","))
            {
                s = s.Substring(0, s.IndexOf(","));
            }

            if (Decimal.TryParse(s, out d))
            {
                return d;
            }

            return 0;
        }

        private bool LoadBool(string s)
        {
            bool b = false;
            if (bool.TryParse(s, out b))
            {
                return b;
            }

            return false;
        }

        public System.Drawing.Color ToWFColor(SixLabors.ImageSharp.Color c)
        {
            Vector4 v = (Vector4)c;

            return System.Drawing.Color.FromArgb(c.ToPixel<Rgb24>().R, c.ToPixel<Rgb24>().G, c.ToPixel<Rgb24>().B);
        }

        public SixLabors.ImageSharp.Color ToSLColor(System.Drawing.Color c)
        {
            return SixLabors.ImageSharp.Color.FromRgb(c.R, c.G, c.B);
        }
        private void SaveConfig()
        {
            if (loading) return;

            using (TextWriter tw = new StreamWriter(KONFIG_FILENAME))
            {
                tw.WriteLine(KONFIG_V1);

                TimeSpan ts = new TimeSpan(0, (int)nudMinutes.Value, (int)nudSeconds.Value);

                tw.WriteLine(ts.ToString());
                tw.WriteLine(cbFont.SelectedItem.ToString());
                tw.WriteLine(this.ToSLColor(bFontColor.BackColor).ToHex());
                tw.WriteLine(nudFont.Value.ToString());
                tw.WriteLine(cbBold.Checked.ToString());
                tw.WriteLine(cbItalic.Checked.ToString());
                tw.WriteLine(nudOutline.Value.ToString());
                tw.WriteLine(this.ToSLColor(bOutlineColor.BackColor).ToHex());
                tw.WriteLine(this.ToSLColor(bBackgroundColor.BackColor).ToHex());

                tw.Close();
            }
        }
    }
}