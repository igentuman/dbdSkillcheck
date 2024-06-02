namespace ScreenCaptureTest
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.r_ring = new System.Windows.Forms.TextBox();
            this.g_ring = new System.Windows.Forms.TextBox();
            this.b_ring = new System.Windows.Forms.TextBox();
            this.r = new System.Windows.Forms.TextBox();
            this.g = new System.Windows.Forms.TextBox();
            this.b = new System.Windows.Forms.TextBox();
            this.skillcheck_bind = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.indicator = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 32;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(28, -119);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(140, 140);
            this.pictureBox8.TabIndex = 12;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 467);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.r_ring);
            this.groupBox1.Controls.Add(this.g_ring);
            this.groupBox1.Controls.Add(this.b_ring);
            this.groupBox1.Controls.Add(this.r);
            this.groupBox1.Controls.Add(this.g);
            this.groupBox1.Controls.Add(this.b);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(150, 83);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(140, 122);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors";
            this.groupBox1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "B";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "R";
            // 
            // r_ring
            // 
            this.r_ring.Location = new System.Drawing.Point(13, 39);
            this.r_ring.Name = "r_ring";
            this.r_ring.Size = new System.Drawing.Size(40, 20);
            this.r_ring.TabIndex = 32;
            this.r_ring.Text = "200";
            // 
            // g_ring
            // 
            this.g_ring.Location = new System.Drawing.Point(14, 65);
            this.g_ring.Name = "g_ring";
            this.g_ring.Size = new System.Drawing.Size(39, 20);
            this.g_ring.TabIndex = 31;
            this.g_ring.Text = "200";
            // 
            // b_ring
            // 
            this.b_ring.Location = new System.Drawing.Point(14, 91);
            this.b_ring.Name = "b_ring";
            this.b_ring.Size = new System.Drawing.Size(39, 20);
            this.b_ring.TabIndex = 30;
            this.b_ring.Text = "200";
            // 
            // r
            // 
            this.r.Location = new System.Drawing.Point(88, 39);
            this.r.Name = "r";
            this.r.Size = new System.Drawing.Size(41, 20);
            this.r.TabIndex = 29;
            this.r.Text = "220";
            // 
            // g
            // 
            this.g.Location = new System.Drawing.Point(88, 65);
            this.g.Name = "g";
            this.g.Size = new System.Drawing.Size(41, 20);
            this.g.TabIndex = 28;
            this.g.Text = "50";
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(88, 91);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(41, 20);
            this.b.TabIndex = 27;
            this.b.Text = "20";
            // 
            // skillcheck_bind
            // 
            this.skillcheck_bind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skillcheck_bind.Items.AddRange(new object[] {
            "Mouse1",
            "Mouse2",
            "Mouse Middle",
            "Space",
            "Tab",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "Y",
            "V",
            "W",
            "X",
            "Y",
            "Z"});
            this.skillcheck_bind.Location = new System.Drawing.Point(13, 44);
            this.skillcheck_bind.Name = "skillcheck_bind";
            this.skillcheck_bind.Size = new System.Drawing.Size(140, 21);
            this.skillcheck_bind.TabIndex = 28;
            this.skillcheck_bind.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(12, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Skillcheck bind";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(15, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "CTRL+SHIFT+E - Minimize";
            // 
            // indicator
            // 
            this.indicator.BackColor = System.Drawing.Color.Lime;
            this.indicator.Location = new System.Drawing.Point(2, 2);
            this.indicator.Name = "indicator";
            this.indicator.Size = new System.Drawing.Size(12, 12);
            this.indicator.TabIndex = 32;
            this.indicator.TabStop = false;
            this.indicator.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Control;
            this.label8.Location = new System.Drawing.Point(12, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "CTRL+SHIFT+Q - On/Off";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(165, 138);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.indicator);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.skillcheck_bind);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Opacity = 0.5D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DBD";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox r_ring;
        private System.Windows.Forms.TextBox g_ring;
        private System.Windows.Forms.TextBox b_ring;
        private System.Windows.Forms.TextBox r;
        private System.Windows.Forms.TextBox g;
        private System.Windows.Forms.TextBox b;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox skillcheck_bind;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox indicator;
        private System.Windows.Forms.Label label8;
    }
}

