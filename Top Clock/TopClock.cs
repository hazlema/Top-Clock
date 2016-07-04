using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.ComponentModel;
using System.Drawing.Text;
using System.Diagnostics;

namespace Top_Clock {
    public class TopClock : PictureBox {

        public TopClock() {
            this.BackColor = Color.Transparent;
            this.BorderStyle = BorderStyle.None;
        }

        public void setFont(DirectionEnum direction) {
            int fntIndex = 0;
            int prevNDX  = 0;
            int nextNDX  = 0;

            using (InstalledFontCollection fonts = new InstalledFontCollection()) {
                // Find Current Index
                //
                for (int fntCount = 0; fntCount <= fonts.Families.Length - 1; fntCount++) {
                    if (fonts.Families[fntCount].Name == FontFamily)
                        fntIndex = fntCount;
                }

                // Get Next / Prev
                //
                prevNDX = fntIndex - 1;
                nextNDX = fntIndex + 1;

                if (prevNDX < 0) prevNDX = fonts.Families.Length - 1;
                if (nextNDX > fonts.Families.Length - 1) nextNDX = 0;

                if (direction == DirectionEnum.Next)
                    FontFamily = fonts.Families[nextNDX].Name;
                else
                    FontFamily = fonts.Families[prevNDX].Name;
            }

            Debug.WriteLine($"FontFamily: {this.FontFamily}");
            render();
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
            fnt = new Font(FontFamily, fntSize);
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
            renderFont(Text, FontFamily, new SolidBrush(Color.FromArgb(Opacity, Foreground.R, Foreground.G, Foreground.B)));
            this.Refresh();
        }

        // Private properties
        //
        private string text = "";

        // Returns a valid font from the list if none found returns Verdana
        //
        private string fnt = FontHelper.findValidFont(new string[] {
            "Microsoft YaHei Light",
            "Myriad Pro Light",
            "Miriam",
            "Segoe UI Emoji",
            "Sitka Banner",
            "Nirmala UI"
        });

        private Color foreground = Color.FromArgb(125, 125, 125, 125);
        private int opacity = 125;

        // Public properties
        //
        [Browsable(false)]
        public string FontFamily {
            get {
                return fnt;
            }
            set {
                fnt = value;
                render();
            }
        }
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