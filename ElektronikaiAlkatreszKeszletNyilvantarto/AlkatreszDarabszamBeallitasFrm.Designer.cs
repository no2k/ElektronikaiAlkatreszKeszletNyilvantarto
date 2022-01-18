
namespace EKNyilvantarto
{
    partial class AlkatreszDarabszamBeallitasFrm
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
            this.darabSzamGbx = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.alkatreszekGbx = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.darabSzamGbx.SuspendLayout();
            this.alkatreszekGbx.SuspendLayout();
            this.SuspendLayout();
            // 
            // darabSzamGbx
            // 
            this.darabSzamGbx.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.darabSzamGbx.Controls.Add(this.panel1);
            this.darabSzamGbx.Location = new System.Drawing.Point(12, 12);
            this.darabSzamGbx.Name = "darabSzamGbx";
            this.darabSzamGbx.Size = new System.Drawing.Size(101, 165);
            this.darabSzamGbx.TabIndex = 0;
            this.darabSzamGbx.TabStop = false;
            this.darabSzamGbx.Text = "Darabszám";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(0, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(101, 146);
            this.panel1.TabIndex = 0;
            this.panel1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel1_Scroll);
            // 
            // alkatreszekGbx
            // 
            this.alkatreszekGbx.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.alkatreszekGbx.Controls.Add(this.panel2);
            this.alkatreszekGbx.Location = new System.Drawing.Point(119, 13);
            this.alkatreszekGbx.Name = "alkatreszekGbx";
            this.alkatreszekGbx.Size = new System.Drawing.Size(403, 164);
            this.alkatreszekGbx.TabIndex = 1;
            this.alkatreszekGbx.TabStop = false;
            this.alkatreszekGbx.Text = "Alkatrészek";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Location = new System.Drawing.Point(0, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 146);
            this.panel2.TabIndex = 0;
            this.panel2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel2_Scroll);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(12, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(295, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Darabszám(ok) rögzítése";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(313, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Mégsem";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AlkatreszDarabszamBeallitasFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(534, 227);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.alkatreszekGbx);
            this.Controls.Add(this.darabSzamGbx);
            this.Name = "AlkatreszDarabszamBeallitasFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Darabszám beállítás";
            this.darabSzamGbx.ResumeLayout(false);
            this.alkatreszekGbx.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox darabSzamGbx;
        private System.Windows.Forms.GroupBox alkatreszekGbx;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}