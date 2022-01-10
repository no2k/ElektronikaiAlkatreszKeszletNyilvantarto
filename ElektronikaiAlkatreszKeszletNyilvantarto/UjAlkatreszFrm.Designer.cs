
namespace EKNyilvantarto
{
    partial class UjAlkatreszFrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.infoTSMI = new System.Windows.Forms.ToolStripStatusLabel();
            this.labLecLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kategoriaCbx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.megnevezTxB = new System.Windows.Forms.TextBox();
            this.darabArNud = new System.Windows.Forms.NumericUpDown();
            this.keszletNud = new System.Windows.Forms.NumericUpDown();
            this.megjegyzesTbx = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bezarTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.kategoriaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.button6 = new System.Windows.Forms.Button();
            this.lv1 = new System.Windows.Forms.ListView();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darabArNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.keszletNud)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(232, 284);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Listához ad";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoTSMI,
            this.labLecLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(688, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip";
            // 
            // infoTSMI
            // 
            this.infoTSMI.Name = "infoTSMI";
            this.infoTSMI.Size = new System.Drawing.Size(0, 17);
            // 
            // labLecLbl
            // 
            this.labLecLbl.Name = "labLecLbl";
            this.labLecLbl.Size = new System.Drawing.Size(0, 17);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.kategoriaCbx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 38);
            this.panel1.TabIndex = 4;
            // 
            // kategoriaCbx
            // 
            this.kategoriaCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kategoriaCbx.FormattingEnabled = true;
            this.kategoriaCbx.Location = new System.Drawing.Point(95, 7);
            this.kategoriaCbx.Name = "kategoriaCbx";
            this.kategoriaCbx.Size = new System.Drawing.Size(237, 24);
            this.kategoriaCbx.TabIndex = 1;
            this.kategoriaCbx.SelectedIndexChanged += new System.EventHandler(this.KategoriaCbx_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kategória:";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.megnevezTxB);
            this.groupBox1.Controls.Add(this.darabArNud);
            this.groupBox1.Controls.Add(this.keszletNud);
            this.groupBox1.Controls.Add(this.megjegyzesTbx);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(5, 74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 203);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alap adatok";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Megnevezés:";
            // 
            // megnevezTxB
            // 
            this.megnevezTxB.Location = new System.Drawing.Point(105, 22);
            this.megnevezTxB.Name = "megnevezTxB";
            this.megnevezTxB.Size = new System.Drawing.Size(227, 23);
            this.megnevezTxB.TabIndex = 7;
            // 
            // darabArNud
            // 
            this.darabArNud.DecimalPlaces = 2;
            this.darabArNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.darabArNud.Location = new System.Drawing.Point(270, 58);
            this.darabArNud.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.darabArNud.Name = "darabArNud";
            this.darabArNud.Size = new System.Drawing.Size(62, 26);
            this.darabArNud.TabIndex = 5;
            // 
            // keszletNud
            // 
            this.keszletNud.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.keszletNud.Location = new System.Drawing.Point(95, 58);
            this.keszletNud.Maximum = new decimal(new int[] {
            200000,
            0,
            0,
            0});
            this.keszletNud.Name = "keszletNud";
            this.keszletNud.Size = new System.Drawing.Size(59, 26);
            this.keszletNud.TabIndex = 4;
            // 
            // megjegyzesTbx
            // 
            this.megjegyzesTbx.Location = new System.Drawing.Point(3, 116);
            this.megjegyzesTbx.Multiline = true;
            this.megjegyzesTbx.Name = "megjegyzesTbx";
            this.megjegyzesTbx.Size = new System.Drawing.Size(329, 81);
            this.megjegyzesTbx.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Megjegyzés:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(5, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Készleten:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(160, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Darab ár (Ft):";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(488, 284);
            this.button2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 41);
            this.button2.TabIndex = 7;
            this.button2.Text = "Ok";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(591, 284);
            this.button3.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 41);
            this.button3.TabIndex = 8;
            this.button3.Text = "Mégsem";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LemonChiffon;
            this.button5.Location = new System.Drawing.Point(110, 285);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(101, 41);
            this.button5.TabIndex = 12;
            this.button5.Text = "Törlés";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.AutoScrollMargin = new System.Drawing.Size(25, 10);
            this.panel2.AutoScrollMinSize = new System.Drawing.Size(25, 10);
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(357, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 247);
            this.panel2.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bezarTSMI,
            this.kategoriaTSMI,
            this.parameterTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(688, 27);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bezarTSMI
            // 
            this.bezarTSMI.Name = "bezarTSMI";
            this.bezarTSMI.Size = new System.Drawing.Size(73, 23);
            this.bezarTSMI.Text = "Bezárás";
            this.bezarTSMI.Click += new System.EventHandler(this.bezarTSMI_Click);
            // 
            // kategoriaTSMI
            // 
            this.kategoriaTSMI.Name = "kategoriaTSMI";
            this.kategoriaTSMI.Size = new System.Drawing.Size(161, 23);
            this.kategoriaTSMI.Text = "Kategória hozzáadás";
            this.kategoriaTSMI.Click += new System.EventHandler(this.kategoriaTSMI_Click);
            // 
            // parameterTSMI
            // 
            this.parameterTSMI.Name = "parameterTSMI";
            this.parameterTSMI.Size = new System.Drawing.Size(121, 23);
            this.parameterTSMI.Text = "Paraméterezés";
            this.parameterTSMI.Click += new System.EventHandler(this.parameterTSMI_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LemonChiffon;
            this.button6.Location = new System.Drawing.Point(5, 285);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(99, 41);
            this.button6.TabIndex = 16;
            this.button6.Text = "Új alkatrész";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // lv1
            // 
            this.lv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lv1.GridLines = true;
            this.lv1.HideSelection = false;
            this.lv1.Location = new System.Drawing.Point(5, 333);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(677, 181);
            this.lv1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lv1.TabIndex = 17;
            this.lv1.UseCompatibleStateImageBehavior = false;
            this.lv1.View = System.Windows.Forms.View.Details;
            // 
            // UjAlkatreszFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 539);
            this.Controls.Add(this.lv1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "UjAlkatreszFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Új alkatrész megadása";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.darabArNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.keszletNud)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox kategoriaCbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown darabArNud;
        private System.Windows.Forms.NumericUpDown keszletNud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel infoTSMI;
        private System.Windows.Forms.TextBox megjegyzesTbx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel labLecLbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bezarTSMI;
        private System.Windows.Forms.ToolStripMenuItem kategoriaTSMI;
        private System.Windows.Forms.ToolStripMenuItem parameterTSMI;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox megnevezTxB;
        private System.Windows.Forms.ListView lv1;
    }
}