
namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    partial class AlkatreszKeszletFrm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fajlTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ujTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.alkatreszTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.projektTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.megnyitasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.mentesTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fajlTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fajlTSMI
            // 
            this.fajlTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ujTSMI,
            this.toolStripMenuItem2,
            this.megnyitasTSMI,
            this.mentesTSMI});
            this.fajlTSMI.Name = "fajlTSMI";
            this.fajlTSMI.Size = new System.Drawing.Size(37, 20);
            this.fajlTSMI.Text = "Fájl";
            // 
            // ujTSMI
            // 
            this.ujTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alkatreszTSMI,
            this.projektTSMI});
            this.ujTSMI.Name = "ujTSMI";
            this.ujTSMI.Size = new System.Drawing.Size(180, 22);
            this.ujTSMI.Text = "Új...";
            // 
            // alkatreszTSMI
            // 
            this.alkatreszTSMI.Name = "alkatreszTSMI";
            this.alkatreszTSMI.Size = new System.Drawing.Size(180, 22);
            this.alkatreszTSMI.Text = "Alkatrész";
            this.alkatreszTSMI.Click += new System.EventHandler(this.alkatreszTSMI_Click);
            // 
            // projektTSMI
            // 
            this.projektTSMI.Name = "projektTSMI";
            this.projektTSMI.Size = new System.Drawing.Size(180, 22);
            this.projektTSMI.Text = "Projekt";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // megnyitasTSMI
            // 
            this.megnyitasTSMI.Name = "megnyitasTSMI";
            this.megnyitasTSMI.Size = new System.Drawing.Size(180, 22);
            this.megnyitasTSMI.Text = "Megnyitás";
            // 
            // mentesTSMI
            // 
            this.mentesTSMI.Name = "mentesTSMI";
            this.mentesTSMI.Size = new System.Drawing.Size(180, 22);
            this.mentesTSMI.Text = "Mentés";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlkatreszKeszletFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AlkatreszKeszletFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elektro Készlet";
            this.Load += new System.EventHandler(this.AlkatreszKeszletFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fajlTSMI;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem ujTSMI;
        private System.Windows.Forms.ToolStripMenuItem alkatreszTSMI;
        private System.Windows.Forms.ToolStripMenuItem projektTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem megnyitasTSMI;
        private System.Windows.Forms.ToolStripMenuItem mentesTSMI;
    }
}

