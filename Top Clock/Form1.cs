using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Top_Clock {
    public partial class Form1 : Form {
        bool     mouseEntered   = false;
        Color    savedColor     = Color.Silver;
        Timer    timer          = new Timer();
        DataEnum dataType       = DataEnum.Time;

        public Form1() {
            InitializeComponent();

            // Some initalizations
            //
            savedColor = topClock.Foreground;
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += onTick;
        }

        // Check to see if first run 
        // 
        private bool isFirstRun() {
            RegistryKey key;

            foreach (string keyName in Registry.CurrentUser.GetSubKeyNames())
                if (keyName == "TopClock") return false;

            key = Registry.CurrentUser.CreateSubKey("TopClock");
            key.SetValue("FirstRun", "false");
            key.Close();

            return true;
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
            topClock.Opacity = 255;
            this.Opacity = 1D;
            mouseEntered = true;
        }

        // Turn down opacity
        //
        private void onMouseLeave(object sender, EventArgs e) {
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
            if (this.FormBorderStyle == FormBorderStyle.SizableToolWindow) {
                this.FormBorderStyle = FormBorderStyle.None;
            } else {
                this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            }
        }

        // Window Border Stuff
        //
        private void onDeactivate(object sender, EventArgs e) {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void onLoad(object sender, EventArgs e) {
            if (isFirstRun())
                MessageBox.Show("Welcome to TopClock!\n\nThis message will only display ONCE!\n\n" +
                                "To show the window border doubleclick on the text.\n" +
                                "To hide the border simply click on a different window.\n" +
                                "To cycle random colors for visibility, hover over the window\n" +
                                "To change text size resize the window (Turn on borders first)", "Top Clock: First Run Message");
        }
    }
}
