﻿
namespace ElektronikaiAlkatreszKeszletNyilvantarto
{
    partial class UjProjektFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.megnevetTxb = new System.Windows.Forms.TextBox();
            this.leirasTxb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Az új projekt megnevezése:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "A projekt rövid leírása:";
            // 
            // megnevetTxb
            // 
            this.megnevetTxb.Location = new System.Drawing.Point(17, 36);
            this.megnevetTxb.Name = "megnevetTxb";
            this.megnevetTxb.Size = new System.Drawing.Size(217, 26);
            this.megnevetTxb.TabIndex = 2;
            // 
            // leirasTxb
            // 
            this.leirasTxb.Location = new System.Drawing.Point(17, 89);
            this.leirasTxb.Multiline = true;
            this.leirasTxb.Name = "leirasTxb";
            this.leirasTxb.Size = new System.Drawing.Size(217, 46);
            this.leirasTxb.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(17, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "Felvétel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
            this.button2.Location = new System.Drawing.Point(142, 141);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 27);
            this.button2.TabIndex = 5;
            this.button2.Text = "Mégsem";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // UjProjektFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 190);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.leirasTxb);
            this.Controls.Add(this.megnevetTxb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UjProjektFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Új projekt hozzáadása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox megnevetTxb;
        private System.Windows.Forms.TextBox leirasTxb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}