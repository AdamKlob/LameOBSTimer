using SixLabors.ImageSharp;
using SixLabors.Fonts;
using SixLabors.Fonts.Tables.TrueType.Glyphs;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Net.Sockets;
using System.Windows.Forms;

namespace LameOBSTimer
{
    public class LameTimer
    {
        private SixLabors.ImageSharp.Image sImage = new SixLabors.ImageSharp.Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(1, 1);

        public System.Drawing.Color FontColor
        {
            set
            {
                this.fontColor = SixLabors.ImageSharp.Color.FromRgb(value.R, value.G, value.B);
            }
        }
        private SixLabors.ImageSharp.Color fontColor = SixLabors.ImageSharp.Color.White;

        public System.Drawing.Color BackgroundColor
        {
            set
            {
                this.backgroundColor = SixLabors.ImageSharp.Color.FromRgb(value.R, value.G, value.B);
            }
        }
        private SixLabors.ImageSharp.Color backgroundColor = SixLabors.ImageSharp.Color.Black;

        public string Text
        {
            set
            {
                this.text = value;
            }
        }
        private string text = "00:00";

        public int Height
        {
            set
            {
                if (value > 0)
                {
                    sImage = new SixLabors.ImageSharp.Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(this.Width, value);
                }
            }
            get
            {
                return this.sImage.Height;
            }
        }

        public int Width
        {
            set
            {
                if (value > 0)
                {
                    sImage = new SixLabors.ImageSharp.Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(value, this.Height);
                }
            }
            get
            {
                return this.sImage.Width;
            }
        }

        public System.Drawing.Color OutlineColor
        {
            set
            {
                this.outlineColor = SixLabors.ImageSharp.Color.FromRgb(value.R, value.G, value.B);
            }
        }
        private SixLabors.ImageSharp.Color outlineColor = SixLabors.ImageSharp.Color.White;

        public Decimal Outline { set; get; } = new Decimal(0);

        public string FontName
        {
            get { return fontName; }
            set
            {
                this.fontName = value;
                this.FontChange();
            }
        }
        private string fontName = "Arial";

        public int FontSize
        {
            get { return fontSize; }
            set {
                this.fontSize = value;
                this.FontChange();
            }
        }
        private int fontSize = 72;

        public bool FontBold 
        {
            get { return this.fontBold; }
            set 
            {
                this.fontBold = value;
                this.FontChange();
            }
        }
        private bool fontBold = false;

        public bool FontItalic
        {
            get { return this.fontItalic; }
            set
            {
                this.fontItalic = value;
                this.FontChange();
            }
        }
        private bool fontItalic = false;

        private SixLabors.Fonts.Font font;
        private void FontChange()
        {
            SixLabors.Fonts.FontStyle fs = SixLabors.Fonts.FontStyle.Regular;
            if (this.fontBold)
            {
                fs |= SixLabors.Fonts.FontStyle.Bold;
            }
            if (this.fontItalic)
            {
                fs |= SixLabors.Fonts.FontStyle.Italic;
            }

            this.font = SixLabors.Fonts.SystemFonts.CreateFont(this.fontName, this.fontSize, fs);
        }

        public System.Drawing.Image Render()
        {
            SixLabors.ImageSharp.Rectangle square = new SixLabors.ImageSharp.Rectangle(0, 0, this.Width, this.Height);

            sImage.Mutate(x => x.Fill(this.backgroundColor, square));

            if (this.font != null)
            {
                SixLabors.Fonts.FontRectangle rect = TextMeasurer.Measure(this.text, new TextOptions(font));

                float width = ((float)this.Width - rect.Width) / 2;
                float height = ((float)this.Height - rect.Height) / 2;

                if (this.Outline != 0)
                {
                    sImage.Mutate(x => x.DrawText(this.text, this.font, SixLabors.ImageSharp.Drawing.Processing.Brushes.Solid(this.fontColor), SixLabors.ImageSharp.Drawing.Processing.Pens.Solid(this.outlineColor, (float)this.Outline), new SixLabors.ImageSharp.PointF(width, height)));
                }
                else
                {
                    sImage.Mutate(x => x.DrawText(this.text, this.font, this.fontColor, new SixLabors.ImageSharp.PointF(width, height)));
                }
            }

            var stream = new System.IO.MemoryStream();
            sImage.SaveAsBmp(stream);
            return System.Drawing.Image.FromStream(stream);
        }

        TcpListener server = new TcpListener(5000);
        Socket mysocket;
        public LameTimer()
        {
            server.Start();
        }
    }
}
