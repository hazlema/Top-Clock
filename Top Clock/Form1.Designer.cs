namespace Top_Clock {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.topClock = new Top_Clock.TopClock();
            ((System.ComponentModel.ISupportInitialize)(this.topClock)).BeginInit();
            this.SuspendLayout();
            // 
            // topClock
            // 
            this.topClock.BackColor = System.Drawing.Color.Transparent;
            this.topClock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topClock.FontFamily = "Microsoft YaHei Light";
            this.topClock.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.topClock.Image = ((System.Drawing.Image)(resources.GetObject("topClock.Image")));
            this.topClock.Location = new System.Drawing.Point(0, 0);
            this.topClock.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.topClock.Name = "topClock";
            this.topClock.Opacity = 125;
            this.topClock.Size = new System.Drawing.Size(200, 50);
            this.topClock.TabIndex = 1;
            this.topClock.TabStop = false;
            this.topClock.Text = "Loading";
            this.topClock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.topClock_MouseClick);
            this.topClock.MouseEnter += new System.EventHandler(this.onMouseEnter);
            this.topClock.MouseLeave += new System.EventHandler(this.onMouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(200, 50);
            this.Controls.Add(this.topClock);
            this.Font = new System.Drawing.Font("Adobe Arabic", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MinimumSize = new System.Drawing.Size(200, 50);
            this.Name = "Form1";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Top Clock";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.onFormDeactivate);
            this.Load += new System.EventHandler(this.onLoad);
            this.MouseHover += new System.EventHandler(this.onToggleBorder);
            this.Resize += new System.EventHandler(this.onResize);
            ((System.ComponentModel.ISupportInitialize)(this.topClock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TopClock topClock;
    }
}

