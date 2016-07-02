using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace Top_Clock {
    public partial class Form1 : Form {
        bool        mouseEntered   = false;
        Color       savedColor     = Color.Silver;
        Timer       timer          = new Timer();
        Timer       hoverUnlock    = new Timer();
        DataEnum    dataType       = DataEnum.Time;

        public Form1() {
            InitializeComponent();

            // Some initalizations
            //
            savedColor = topClock.Foreground;

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += onTick;

            hoverUnlock.Enabled = false;
            hoverUnlock.Interval = 2000;
            hoverUnlock.Tick += borderOn;
        }

        private bool keyExists(RegistryKey root, string name) {
            foreach (string look in root.GetSubKeyNames()) {
                if (name == look) return true;
            }

            return false;
        }

        private void regSaveValues() {
            RegistryKey Software = Registry.CurrentUser.OpenSubKey("Software", true);

            if (!keyExists(Software, "TopClock"))
                Software.CreateSubKey("TopClock");

            RegistryKey appkey = Software.OpenSubKey("TopClock", true);

            appkey.SetValue("FirstRun", "false");
            appkey.SetValue("Font", topClock.FontFamily);
            appkey.SetValue("Width", this.Width);
            appkey.SetValue("Hight", this.Height);
            appkey.SetValue("X", this.Location.X);
            appkey.SetValue("Y", this.Location.Y);

            appkey.Close();
            Software.Close();
        }

        private void regLoadValues() {
            RegistryKey Software = Registry.CurrentUser.OpenSubKey("Software");

            if (keyExists(Software, "TopClock")) {
                RegistryKey appkey = Software.OpenSubKey("TopClock", true);
                topClock.FontFamily = appkey.GetValue("Font").ToString();
                this.Width = (int)appkey.GetValue("Width");
                this.Height = (int)appkey.GetValue("Hight");
                this.Location = new Point((int)appkey.GetValue("X"), (int)appkey.GetValue("Y"));
                appkey.Close();
            }

            Software.Close();
        }

        // Check to see if first run 
        // 
        private bool isFirstRun() {
            RegistryKey Software = Registry.CurrentUser.OpenSubKey("Software");
            return !keyExists(Software, "TopClock");
        }

        // Update the displayed data
        //
        private void formatData() {
            if (dataType == DataEnum.Time) {
                string[] display = DateTime.Now.ToLongTimeString().Split(' ');
                string[] time = display[0].Split(':');

                topClock.Text = $"{time[0]}:{time[1]} {display[1].ToLower()}";
            } else {
                topClock.Text = $"{DateTime.Now.ToLongDateString()}";
            }
        }

        // Update the displayed data and cycle colors if mouseEntered
        //
        private void onTick(object sender, EventArgs e) {
            Random rnd = new Random();

            if (mouseEntered) 
                topClock.Foreground = Color.FromArgb(rnd.Next(125, 255), rnd.Next(125, 255), rnd.Next(125, 255));
            else 
                topClock.Foreground = savedColor;
            
            formatData();
        }

        // Visual Effects, fadeout, change data then fadein
        //
        private void onClick(object sender, EventArgs e) {
            timer.Stop();
            topClock.fadeOut();

            if (dataType == DataEnum.Time)
                dataType = DataEnum.Date;
            else
                dataType = DataEnum.Time;

            formatData();

            topClock.fadeIn(125);
            timer.Start();
        }

        // Turn up opacity
        //
        private void onMouseEnter(object sender, EventArgs e) {
            if (!hoverUnlock.Enabled) hoverUnlock.Enabled = true;
            topClock.Opacity = 255;
            this.Opacity = 1D;
            mouseEntered = true;
        }

        // Turn down opacity
        //
        private void onMouseLeave(object sender, EventArgs e) {
            hoverUnlock.Enabled = false;
            topClock.Opacity = 125;
            mouseEntered = false;
            this.Opacity = .50D;
        }

        // Rerender
        //
        private void onResize(object sender, EventArgs e) {
            topClock.render();
        }

        // Window Border Stuff
        //
        private void onToggleBorder(object sender, EventArgs e) {
            if (this.FormBorderStyle == FormBorderStyle.Sizable) {
                this.FormBorderStyle = FormBorderStyle.None;
            } else {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        // Window Border Stuff
        //
        private void onFormDeactivate(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.None;
            regSaveValues();
        }

        private void borderOn(object sender, EventArgs e) {
            hoverUnlock.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void onLoad(object sender, EventArgs e) {
            if (isFirstRun()) {
                regSaveValues();
                MessageBox.Show("Welcome to TopClock!\n\nThis message will only display ONCE!\n\n" +
                                "To show the window border hover over the time\n" +
                                "To hide the border click on a different window\n" +
                                "To cycle random colors for visibility, hover over the window\n" +
                                "To change text size, resize the window (Turn on borders first)", "Top Clock: First Run Message");
            } else {
                regLoadValues();
            }
        }

        private void topClock_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                topClock.setFont(DirectionEnum.Next);
                regSaveValues();
            } else if (e.Button == MouseButtons.Left)
                onClick(sender, e);
            else if (e.Button == MouseButtons.Middle)
                onToggleBorder(sender, e);
        }
    }
}
