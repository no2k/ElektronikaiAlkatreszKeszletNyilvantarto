
namespace Tranzisztor
{
    partial class Form1
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
            this.kondenzatorGbx = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.uzemFeszNUD = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tolearnciaNUD = new System.Windows.Forms.NumericUpDown();
            this.alkatreszTipusCbx = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.uzemhoMaxNUD = new System.Windows.Forms.NumericUpDown();
            this.uzemHoMinNUD = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.mertekEgysegCbx = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.AlkatreszErtekNUD = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.raszterMeretNUD = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.szerelRBtn2 = new System.Windows.Forms.RadioButton();
            this.tokozasCbx = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.szerelRBtn1 = new System.Windows.Forms.RadioButton();
            this.kondenzatorGbx.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uzemFeszNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tolearnciaNUD)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uzemhoMaxNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uzemHoMinNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlkatreszErtekNUD)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raszterMeretNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // kondenzatorGbx
            // 
            this.kondenzatorGbx.BackColor = System.Drawing.Color.LightGray;
            this.kondenzatorGbx.Controls.Add(this.groupBox7);
            this.kondenzatorGbx.Controls.Add(this.groupBox5);
            this.kondenzatorGbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kondenzatorGbx.Location = new System.Drawing.Point(1, 1);
            this.kondenzatorGbx.Name = "kondenzatorGbx";
            this.kondenzatorGbx.Size = new System.Drawing.Size(426, 343);
            this.kondenzatorGbx.TabIndex = 4;
            this.kondenzatorGbx.TabStop = false;
            this.kondenzatorGbx.Text = "Alkatrész paraméterek";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.uzemFeszNUD);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.tolearnciaNUD);
            this.groupBox7.Controls.Add(this.alkatreszTipusCbx);
            this.groupBox7.Controls.Add(this.groupBox3);
            this.groupBox7.Controls.Add(this.mertekEgysegCbx);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.AlkatreszErtekNUD);
            this.groupBox7.Controls.Add(this.label8);
            this.groupBox7.Location = new System.Drawing.Point(6, 147);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(410, 148);
            this.groupBox7.TabIndex = 26;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Egyedi paraméterek";
            // 
            // uzemFeszNUD
            // 
            this.uzemFeszNUD.DecimalPlaces = 2;
            this.uzemFeszNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.uzemFeszNUD.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uzemFeszNUD.Location = new System.Drawing.Point(122, 87);
            this.uzemFeszNUD.Name = "uzemFeszNUD";
            this.uzemFeszNUD.Size = new System.Drawing.Size(56, 24);
            this.uzemFeszNUD.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Feszültség (V):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Alkatrész típusa:";
            // 
            // tolearnciaNUD
            // 
            this.tolearnciaNUD.DecimalPlaces = 1;
            this.tolearnciaNUD.Location = new System.Drawing.Point(117, 116);
            this.tolearnciaNUD.Name = "tolearnciaNUD";
            this.tolearnciaNUD.Size = new System.Drawing.Size(85, 23);
            this.tolearnciaNUD.TabIndex = 20;
            // 
            // alkatreszTipusCbx
            // 
            this.alkatreszTipusCbx.FormattingEnabled = true;
            this.alkatreszTipusCbx.Location = new System.Drawing.Point(124, 26);
            this.alkatreszTipusCbx.Name = "alkatreszTipusCbx";
            this.alkatreszTipusCbx.Size = new System.Drawing.Size(133, 24);
            this.alkatreszTipusCbx.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.uzemhoMaxNUD);
            this.groupBox3.Controls.Add(this.uzemHoMinNUD);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(263, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(138, 88);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Üzemi hőm. (°C)";
            // 
            // uzemhoMaxNUD
            // 
            this.uzemhoMaxNUD.Location = new System.Drawing.Point(79, 56);
            this.uzemhoMaxNUD.Name = "uzemhoMaxNUD";
            this.uzemhoMaxNUD.Size = new System.Drawing.Size(47, 23);
            this.uzemhoMaxNUD.TabIndex = 13;
            // 
            // uzemHoMinNUD
            // 
            this.uzemHoMinNUD.Location = new System.Drawing.Point(79, 27);
            this.uzemHoMinNUD.Name = "uzemHoMinNUD";
            this.uzemHoMinNUD.Size = new System.Drawing.Size(47, 23);
            this.uzemHoMinNUD.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Minimum:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 17);
            this.label12.TabIndex = 11;
            this.label12.Text = "Maximum:";
            // 
            // mertekEgysegCbx
            // 
            this.mertekEgysegCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mertekEgysegCbx.FormattingEnabled = true;
            this.mertekEgysegCbx.Location = new System.Drawing.Point(184, 54);
            this.mertekEgysegCbx.Name = "mertekEgysegCbx";
            this.mertekEgysegCbx.Size = new System.Drawing.Size(73, 24);
            this.mertekEgysegCbx.TabIndex = 24;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(114, 17);
            this.label21.TabIndex = 6;
            this.label21.Text = "Alkatrész értéke:";
            // 
            // AlkatreszErtekNUD
            // 
            this.AlkatreszErtekNUD.DecimalPlaces = 2;
            this.AlkatreszErtekNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AlkatreszErtekNUD.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.AlkatreszErtekNUD.Location = new System.Drawing.Point(122, 54);
            this.AlkatreszErtekNUD.Name = "AlkatreszErtekNUD";
            this.AlkatreszErtekNUD.Size = new System.Drawing.Size(56, 24);
            this.AlkatreszErtekNUD.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Tolerancia (%):";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.raszterMeretNUD);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.szerelRBtn2);
            this.groupBox5.Controls.Add(this.tokozasCbx);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.szerelRBtn1);
            this.groupBox5.Location = new System.Drawing.Point(6, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(244, 123);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Alkatrész tokozás";
            // 
            // raszterMeretNUD
            // 
            this.raszterMeretNUD.DecimalPlaces = 2;
            this.raszterMeretNUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.raszterMeretNUD.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.raszterMeretNUD.Location = new System.Drawing.Point(149, 87);
            this.raszterMeretNUD.Name = "raszterMeretNUD";
            this.raszterMeretNUD.Size = new System.Drawing.Size(85, 23);
            this.raszterMeretNUD.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tokozás:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Szerelés típusa:";
            // 
            // szerelRBtn2
            // 
            this.szerelRBtn2.AutoSize = true;
            this.szerelRBtn2.Location = new System.Drawing.Point(178, 28);
            this.szerelRBtn2.Name = "szerelRBtn2";
            this.szerelRBtn2.Size = new System.Drawing.Size(56, 21);
            this.szerelRBtn2.TabIndex = 5;
            this.szerelRBtn2.Text = "SMD";
            this.szerelRBtn2.UseVisualStyleBackColor = true;
            // 
            // tokozasCbx
            // 
            this.tokozasCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tokozasCbx.FormattingEnabled = true;
            this.tokozasCbx.Location = new System.Drawing.Point(113, 52);
            this.tokozasCbx.Name = "tokozasCbx";
            this.tokozasCbx.Size = new System.Drawing.Size(121, 24);
            this.tokozasCbx.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Raszterméret (mm):";
            // 
            // szerelRBtn1
            // 
            this.szerelRBtn1.AutoSize = true;
            this.szerelRBtn1.Checked = true;
            this.szerelRBtn1.Location = new System.Drawing.Point(118, 28);
            this.szerelRBtn1.Name = "szerelRBtn1";
            this.szerelRBtn1.Size = new System.Drawing.Size(54, 21);
            this.szerelRBtn1.TabIndex = 4;
            this.szerelRBtn1.TabStop = true;
            this.szerelRBtn1.Text = "THT";
            this.szerelRBtn1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 446);
            this.Controls.Add(this.kondenzatorGbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.kondenzatorGbx.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uzemFeszNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tolearnciaNUD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uzemhoMaxNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uzemHoMinNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlkatreszErtekNUD)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.raszterMeretNUD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox kondenzatorGbx;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown uzemFeszNUD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tolearnciaNUD;
        private System.Windows.Forms.ComboBox alkatreszTipusCbx;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown uzemhoMaxNUD;
        private System.Windows.Forms.NumericUpDown uzemHoMinNUD;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox mertekEgysegCbx;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown AlkatreszErtekNUD;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown raszterMeretNUD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton szerelRBtn2;
        private System.Windows.Forms.ComboBox tokozasCbx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton szerelRBtn1;
    }
}