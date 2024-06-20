namespace LameOBSTimer
{
    partial class LameOBSTimer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            nudMinutes = new NumericUpDown();
            nudSeconds = new NumericUpDown();
            bFontColor = new Button();
            nudOutline = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            bOutlineColor = new Button();
            cdFontColor = new ColorDialog();
            cdOutlineColor = new ColorDialog();
            colorDialog1 = new ColorDialog();
            colorDialog2 = new ColorDialog();
            colorDialog3 = new ColorDialog();
            cdBackgroundColor = new ColorDialog();
            bBackgroundColor = new Button();
            label4 = new Label();
            cbFont = new ComboBox();
            nudFont = new NumericUpDown();
            cbBold = new CheckBox();
            cbItalic = new CheckBox();
            bStart = new Button();
            timerWorker = new System.ComponentModel.BackgroundWorker();
            bPause = new Button();
            bStop = new Button();
            bEndAt = new Button();
            dtpEndAt = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)nudMinutes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSeconds).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudOutline).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFont).BeginInit();
            SuspendLayout();
            // 
            // nudMinutes
            // 
            nudMinutes.Location = new System.Drawing.Point(124, 12);
            nudMinutes.Name = "nudMinutes";
            nudMinutes.Size = new System.Drawing.Size(38, 23);
            nudMinutes.TabIndex = 0;
            nudMinutes.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // nudSeconds
            // 
            nudSeconds.Location = new System.Drawing.Point(168, 12);
            nudSeconds.Maximum = new decimal(new int[] { 59, 0, 0, 0 });
            nudSeconds.Name = "nudSeconds";
            nudSeconds.Size = new System.Drawing.Size(38, 23);
            nudSeconds.TabIndex = 1;
            // 
            // bFontColor
            // 
            bFontColor.BackColor = System.Drawing.Color.White;
            bFontColor.Location = new System.Drawing.Point(205, 41);
            bFontColor.Name = "bFontColor";
            bFontColor.Size = new System.Drawing.Size(23, 23);
            bFontColor.TabIndex = 3;
            bFontColor.UseVisualStyleBackColor = false;
            bFontColor.BackColorChanged += bFontColor_BackColorChanged;
            bFontColor.Click += bFontColor_Click;
            // 
            // nudOutline
            // 
            nudOutline.Location = new System.Drawing.Point(455, 41);
            nudOutline.Name = "nudOutline";
            nudOutline.Size = new System.Drawing.Size(38, 23);
            nudOutline.TabIndex = 5;
            nudOutline.ValueChanged += nudOutline_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(65, 15);
            label1.TabIndex = 6;
            label1.Text = "Start value:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 45);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(34, 15);
            label2.TabIndex = 7;
            label2.Text = "Font:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(404, 45);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(49, 15);
            label3.TabIndex = 8;
            label3.Text = "Outline:";
            // 
            // bOutlineColor
            // 
            bOutlineColor.BackColor = System.Drawing.Color.White;
            bOutlineColor.Location = new System.Drawing.Point(499, 41);
            bOutlineColor.Name = "bOutlineColor";
            bOutlineColor.Size = new System.Drawing.Size(23, 23);
            bOutlineColor.TabIndex = 9;
            bOutlineColor.UseVisualStyleBackColor = false;
            bOutlineColor.BackColorChanged += bOutlineColor_BackColorChanged;
            bOutlineColor.Click += bOutlineColor_Click;
            // 
            // bBackgroundColor
            // 
            bBackgroundColor.BackColor = System.Drawing.Color.Black;
            bBackgroundColor.Location = new System.Drawing.Point(124, 70);
            bBackgroundColor.Name = "bBackgroundColor";
            bBackgroundColor.Size = new System.Drawing.Size(23, 23);
            bBackgroundColor.TabIndex = 10;
            bBackgroundColor.UseVisualStyleBackColor = false;
            bBackgroundColor.BackColorChanged += bBackgroundColor_BackColorChanged;
            bBackgroundColor.Click += bBackgroundColor_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(12, 74);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(74, 15);
            label4.TabIndex = 11;
            label4.Text = "Background:";
            // 
            // cbFont
            // 
            cbFont.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFont.FormattingEnabled = true;
            cbFont.Location = new System.Drawing.Point(78, 41);
            cbFont.Name = "cbFont";
            cbFont.Size = new System.Drawing.Size(121, 23);
            cbFont.TabIndex = 12;
            cbFont.SelectedIndexChanged += cbFont_SelectedIndexChanged;
            // 
            // nudFont
            // 
            nudFont.Location = new System.Drawing.Point(234, 41);
            nudFont.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudFont.Name = "nudFont";
            nudFont.Size = new System.Drawing.Size(51, 23);
            nudFont.TabIndex = 13;
            nudFont.Value = new decimal(new int[] { 72, 0, 0, 0 });
            nudFont.ValueChanged += nudFont_ValueChanged;
            // 
            // cbBold
            // 
            cbBold.AutoSize = true;
            cbBold.Location = new System.Drawing.Point(291, 44);
            cbBold.Name = "cbBold";
            cbBold.Size = new System.Drawing.Size(50, 19);
            cbBold.TabIndex = 14;
            cbBold.Text = "bold";
            cbBold.UseVisualStyleBackColor = true;
            cbBold.CheckedChanged += cbBold_CheckedChanged;
            // 
            // cbItalic
            // 
            cbItalic.AutoSize = true;
            cbItalic.Location = new System.Drawing.Point(347, 44);
            cbItalic.Name = "cbItalic";
            cbItalic.Size = new System.Drawing.Size(51, 19);
            cbItalic.TabIndex = 15;
            cbItalic.Text = "italic";
            cbItalic.UseVisualStyleBackColor = true;
            cbItalic.CheckedChanged += cbItalic_CheckedChanged;
            // 
            // bStart
            // 
            bStart.Location = new System.Drawing.Point(12, 112);
            bStart.Name = "bStart";
            bStart.Size = new System.Drawing.Size(75, 23);
            bStart.TabIndex = 16;
            bStart.Text = "Start";
            bStart.UseVisualStyleBackColor = true;
            bStart.Click += bStart_Click;
            // 
            // timerWorker
            // 
            timerWorker.WorkerSupportsCancellation = true;
            timerWorker.DoWork += timerWorker_DoWork;
            // 
            // bPause
            // 
            bPause.Enabled = false;
            bPause.Location = new System.Drawing.Point(93, 112);
            bPause.Name = "bPause";
            bPause.Size = new System.Drawing.Size(75, 23);
            bPause.TabIndex = 17;
            bPause.Text = "Pause";
            bPause.UseVisualStyleBackColor = true;
            bPause.Click += bPause_Click;
            // 
            // bStop
            // 
            bStop.Enabled = false;
            bStop.Location = new System.Drawing.Point(174, 112);
            bStop.Name = "bStop";
            bStop.Size = new System.Drawing.Size(75, 23);
            bStop.TabIndex = 18;
            bStop.Text = "Stop";
            bStop.UseVisualStyleBackColor = true;
            bStop.Click += bStop_Click;
            // 
            // bEndAt
            // 
            bEndAt.Location = new System.Drawing.Point(276, 112);
            bEndAt.Name = "bEndAt";
            bEndAt.Size = new System.Drawing.Size(75, 23);
            bEndAt.TabIndex = 19;
            bEndAt.Text = "End at:";
            bEndAt.UseVisualStyleBackColor = true;
            bEndAt.Click += bEndAt_Click;
            // 
            // dtpEndAt
            // 
            dtpEndAt.CustomFormat = "HH:mm";
            dtpEndAt.Format = DateTimePickerFormat.Custom;
            dtpEndAt.Location = new System.Drawing.Point(357, 112);
            dtpEndAt.Name = "dtpEndAt";
            dtpEndAt.Size = new System.Drawing.Size(62, 23);
            dtpEndAt.TabIndex = 20;
            // 
            // LameOBSTimer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1318, 415);
            Controls.Add(dtpEndAt);
            Controls.Add(bEndAt);
            Controls.Add(bStop);
            Controls.Add(bPause);
            Controls.Add(bStart);
            Controls.Add(cbItalic);
            Controls.Add(cbBold);
            Controls.Add(nudFont);
            Controls.Add(cbFont);
            Controls.Add(label4);
            Controls.Add(bBackgroundColor);
            Controls.Add(bOutlineColor);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nudOutline);
            Controls.Add(bFontColor);
            Controls.Add(nudSeconds);
            Controls.Add(nudMinutes);
            Name = "LameOBSTimer";
            Text = "LameObsTimer";
            Load += LameOBSTimer_Load;
            ((System.ComponentModel.ISupportInitialize)nudMinutes).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSeconds).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudOutline).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFont).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown nudMinutes;
        private NumericUpDown nudSeconds;
        private Button bFontColor;
        private NumericUpDown nudOutline;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button bOutlineColor;
        private ColorDialog cdFontColor;
        private ColorDialog cdOutlineColor;
        private ColorDialog colorDialog1;
        private ColorDialog colorDialog2;
        private ColorDialog colorDialog3;
        private ColorDialog cdBackgroundColor;
        private Button bBackgroundColor;
        private Label label4;
        private ComboBox cbFont;
        private NumericUpDown nudFont;
        private CheckBox cbBold;
        private CheckBox cbItalic;
        private Button bStart;
        private System.ComponentModel.BackgroundWorker timerWorker;
        private Button bPause;
        private Button bStop;
        private Button bEndAt;
        private DateTimePicker dtpEndAt;
    }
}