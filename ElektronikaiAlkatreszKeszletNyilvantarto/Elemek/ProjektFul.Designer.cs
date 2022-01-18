
namespace EKNyilvantarto
{
    partial class ProjektFul
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ikonBox = new System.Windows.Forms.PictureBox();
            this.prjNev = new System.Windows.Forms.Label();
            this.prjLeiras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ikonBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ikonBox
            // 
            this.ikonBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ikonBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ikonBox.Location = new System.Drawing.Point(0, 0);
            this.ikonBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.ikonBox.Name = "ikonBox";
            this.ikonBox.Size = new System.Drawing.Size(55, 38);
            this.ikonBox.TabIndex = 0;
            this.ikonBox.TabStop = false;
            // 
            // prjNev
            // 
            this.prjNev.AutoSize = true;
            this.prjNev.BackColor = System.Drawing.SystemColors.Control;
            this.prjNev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prjNev.Location = new System.Drawing.Point(58, 0);
            this.prjNev.Name = "prjNev";
            this.prjNev.Size = new System.Drawing.Size(98, 20);
            this.prjNev.TabIndex = 1;
            this.prjNev.Text = "Projekt Neve";
            // 
            // prjLeiras
            // 
            this.prjLeiras.AutoSize = true;
            this.prjLeiras.Location = new System.Drawing.Point(59, 20);
            this.prjLeiras.Name = "prjLeiras";
            this.prjLeiras.Size = new System.Drawing.Size(37, 13);
            this.prjLeiras.TabIndex = 2;
            this.prjLeiras.Text = "Leírás";
            // 
            // ProjektFul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.prjLeiras);
            this.Controls.Add(this.prjNev);
            this.Controls.Add(this.ikonBox);
            this.Name = "ProjektFul";
            this.Size = new System.Drawing.Size(242, 38);
            this.Leave += new System.EventHandler(this.ProjektFul_MouseLeave);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProjektFul_MouseClick);
            this.MouseHover += new System.EventHandler(this.ProjektFul_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.ikonBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ikonBox;
        private System.Windows.Forms.Label prjNev;
        private System.Windows.Forms.Label prjLeiras;
    }
}
