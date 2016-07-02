using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;

namespace Top_Clock {
    public class TopClock : PictureBox {

        public TopClock() {
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
        }

        // Find the proper font size and update the control
        //
        public void renderFont(string Text, string FontName, Brush brush) {
            Font  fnt     = new Font(FontName, 8);
            int   fntSize = 8;
            SizeF sze;

            this.Image = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
            Graphics gfx = Graphics.FromImage(this.Image);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Measure String
            //
            for (int tmp = 8; tmp <= this.Width; tmp++) {
                sze = gfx.MeasureString(Text, fnt);

                if (sze.Width <= this.Width && sze.Height <= this.Height) {
                    fntSize = tmp;
                    fnt = new Font(FontName, fntSize);
                }
            }

            // Render String
            //
            fnt = new Font(FontName, fntSize);
            sze = gfx.MeasureString(Text, fnt);
            int offsetX = (this.Width - (int)sze.Width) / 2;
            int offsetY = (this.Height - (int)sze.Height) / 2;

            gfx.Clear(Color.Transparent);
            gfx.DrawString(Text, fnt, brush, new PointF(offsetX, offsetY));

            // Clean Up
            //
            gfx.Dispose();
            fnt.Dispose();
        }

        // Visual Effect: FadeOut
        //
        public void fadeOut() {
            for (int fadeOut = this.Opacity; this.Opacity >= 5; fadeOut--) {
                this.Opacity -= 1;
                Thread.Sleep(1);
            }
        }

        // Visual Effect: FadeIn
        //
        public void fadeIn(int EndOpacity) {
            for (int fadeOut = 5; fadeOut <= EndOpacity; fadeOut++) {
                this.Opacity += 1;
                Thread.Sleep(1);
            }
        }

        // Rerender control
        //
        public void render() {
            renderFont(Text, "Microsoft NeoGothic", new SolidBrush(Color.FromArgb(Opacity, Foreground.R, Foreground.G, Foreground.B)));
            this.Refresh();
        }

        // Private properties
        //
        private string text = "";
        private Color foreground = Color.FromArgb(125, 125, 125, 125);
        private int opacity = 125;

        // Public properties
        //
        [Browsable(true)]
        public override string Text {
            get {
                return text;
            }
            set {
                text = value;
                render();
            }
        }
        [Browsable(true)]
        public Color Foreground {
            get {
                return foreground;
            }
            set {
                foreground = value;
                render();
            }
        }
        [Browsable(true)]
        public int Opacity {
            get {
                return opacity;
            }
            set {
                opacity = value;
                render();
            }
        }
    }
}