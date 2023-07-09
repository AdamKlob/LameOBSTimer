using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LameOBSTimer
{
    public partial class LameObsTimerWindow : Form
    {
        public LameObsTimerWindow()
        {
            InitializeComponent();
        }

        public void Render()
        {
            this.pictureBox1.Image = lt.Render();
        }

        public LameTimer lt = new LameTimer();

        private void LameObsTimerWindow_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = lt.Render();
            lt.Text = "00:00";

            this.lt.Width = this.pictureBox1.Width;
            this.lt.Height = this.pictureBox1.Height;

        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            this.lt.Width = this.pictureBox1.Width;
            this.lt.Height = this.pictureBox1.Height;

            this.Render();
        }
    }
}
