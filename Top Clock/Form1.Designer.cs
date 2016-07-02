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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.topClock = new Top_Clock.TopClock();
            ((System.ComponentModel.ISupportInitialize)(this.topClock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 54);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(164, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(5, 54);
            this.panel2.TabIndex = 3;
            // 
            // topClock
            // 
            this.topClock.BackColor = System.Drawing.Color.Transparent;
            this.topClock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.topClock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topClock.Foreground = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.topClock.Image = ((System.Drawing.Image)(resources.GetObject("topClock.Image")));
            this.topClock.Location = new System.Drawing.Point(5, 0);
            this.topClock.Margin = new System.Windows.Forms.Padding(2);
            this.topClock.Name = "topClock";
            this.topClock.Opacity = 125;
            this.topClock.Size = new System.Drawing.Size(159, 54);
            this.topClock.TabIndex = 1;
            this.topClock.TabStop = false;
            this.topClock.Text = "Loading";
            this.topClock.Click += new System.EventHandler(this.onClick);
            this.topClock.DoubleClick += new System.EventHandler(this.onToggleBorder);
            this.topClock.MouseEnter += new System.EventHandler(this.onMouseEnter);
            this.topClock.MouseLeave += new System.EventHandler(this.onMouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(3F, 8F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(169, 54);
            this.Controls.Add(this.topClock);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Adobe Arabic", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(112, 54);
            this.Name = "Form1";
            this.Opacity = 0.5D;
            this.Text = "Top Clock";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.onDeactivate);
            this.Load += new System.EventHandler(this.onLoad);
            this.MouseHover += new System.EventHandler(this.onToggleBorder);
            this.Resize += new System.EventHandler(this.onResize);
            ((System.ComponentModel.ISupportInitialize)(this.topClock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private TopClock topClock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

