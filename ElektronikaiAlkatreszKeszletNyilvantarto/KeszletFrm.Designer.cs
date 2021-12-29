
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlkatreszKeszletFrm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fajlTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ujTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.alkatreszTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.projektTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.megnyitasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.mentesTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.infoTSMI = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.kategoriaTSCBX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.projektPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.projektFul1 = new ElektronikaiAlkatreszKeszletNyilvantarto.ProjektFul();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.beállításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adatbázisKarbantartásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.projektPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fajlTSMI,
            this.beállításokToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1101, 24);
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
            this.alkatreszTSMI.Click += new System.EventHandler(this.AlkatreszTSMI_Click);
            // 
            // projektTSMI
            // 
            this.projektTSMI.Name = "projektTSMI";
            this.projektTSMI.Size = new System.Drawing.Size(180, 22);
            this.projektTSMI.Text = "Projekt";
            this.projektTSMI.Click += new System.EventHandler(this.projektTSMI_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoTSMI});
            this.statusStrip1.Location = new System.Drawing.Point(0, 521);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1101, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // infoTSMI
            // 
            this.infoTSMI.Name = "infoTSMI";
            this.infoTSMI.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kategoriaTSCBX,
            this.toolStripTextBox1,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1101, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // kategoriaTSCBX
            // 
            this.kategoriaTSCBX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kategoriaTSCBX.Name = "kategoriaTSCBX";
            this.kategoriaTSCBX.Size = new System.Drawing.Size(121, 25);
            this.kategoriaTSCBX.SelectedIndexChanged += new System.EventHandler(this.kategoriaTSCBX_SelectedIndexChanged);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.Text = "Alkatrész keresése";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.AllowDrop = true;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 49);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.DarkGray;
            this.splitContainer2.Panel1.Controls.Add(this.projektPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1101, 472);
            this.splitContainer2.SplitterDistance = 253;
            this.splitContainer2.TabIndex = 5;
            // 
            // projektPanel
            // 
            this.projektPanel.Controls.Add(this.projektFul1);
            this.projektPanel.Location = new System.Drawing.Point(3, 3);
            this.projektPanel.Name = "projektPanel";
            this.projektPanel.Size = new System.Drawing.Size(248, 466);
            this.projektPanel.TabIndex = 0;
            // 
            // projektFul1
            // 
            this.projektFul1.AllowDrop = true;
            this.projektFul1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.projektFul1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projektFul1.HatterSzinMH = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.projektFul1.HatterSzinMO = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.projektFul1.Ikon = null;
            this.projektFul1.Leiras = "gdsfgf";
            this.projektFul1.Location = new System.Drawing.Point(3, 3);
            this.projektFul1.Megnevezes = "sdfsdf";
            this.projektFul1.Name = "projektFul1";
            this.projektFul1.Size = new System.Drawing.Size(252, 38);
            this.projektFul1.TabIndex = 0;
            this.projektFul1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.projektFul1_MouseClick);
            this.projektFul1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.projektFul1_MouseDown);
            this.projektFul1.MouseLeave += new System.EventHandler(this.projektFul1_MouseLeave);
            this.projektFul1.MouseHover += new System.EventHandler(this.projektFul1_MouseHover);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(844, 472);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(1, 1);
            this.listView1.Margin = new System.Windows.Forms.Padding(1);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(842, 218);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(1, 1);
            this.listView2.Margin = new System.Windows.Forms.Padding(1);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(842, 246);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // beállításokToolStripMenuItem
            // 
            this.beállításokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adatbázisKarbantartásToolStripMenuItem});
            this.beállításokToolStripMenuItem.Name = "beállításokToolStripMenuItem";
            this.beállításokToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.beállításokToolStripMenuItem.Text = "Beállítások";
            // 
            // adatbázisKarbantartásToolStripMenuItem
            // 
            this.adatbázisKarbantartásToolStripMenuItem.Name = "adatbázisKarbantartásToolStripMenuItem";
            this.adatbázisKarbantartásToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.adatbázisKarbantartásToolStripMenuItem.Text = "Adatbázis karbantartás";
            // 
            // AlkatreszKeszletFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1101, 543);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AlkatreszKeszletFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elektro Készlet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlkatreszKeszletFrm_FormClosing);
            this.Load += new System.EventHandler(this.AlkatreszKeszletFrm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.projektPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fajlTSMI;
        private System.Windows.Forms.ToolStripMenuItem ujTSMI;
        private System.Windows.Forms.ToolStripMenuItem alkatreszTSMI;
        private System.Windows.Forms.ToolStripMenuItem projektTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem megnyitasTSMI;
        private System.Windows.Forms.ToolStripMenuItem mentesTSMI;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel infoTSMI;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox kategoriaTSCBX;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel projektPanel;
        private ProjektFul projektFul1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ToolStripMenuItem beállításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adatbázisKarbantartásToolStripMenuItem;
    }
}

