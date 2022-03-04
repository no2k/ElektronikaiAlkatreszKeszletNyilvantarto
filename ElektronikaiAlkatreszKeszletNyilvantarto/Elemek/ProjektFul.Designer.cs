
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
            this.components = new System.ComponentModel.Container();
            this.prjNev = new System.Windows.Forms.Label();
            this.prjLeiras = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // prjNev
            // 
            this.prjNev.AutoSize = true;
            this.prjNev.BackColor = System.Drawing.Color.Transparent;
            this.prjNev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prjNev.Location = new System.Drawing.Point(3, 0);
            this.prjNev.MaximumSize = new System.Drawing.Size(178, 20);
            this.prjNev.MinimumSize = new System.Drawing.Size(0, 20);
            this.prjNev.Name = "prjNev";
            this.prjNev.Size = new System.Drawing.Size(110, 20);
            this.prjNev.TabIndex = 1;
            this.prjNev.Text = "Projekt Neve";
            this.prjNev.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProjektFul_MouseClick);
            this.prjNev.MouseEnter += new System.EventHandler(this.ProjektFul_MouseEnter);
            this.prjNev.MouseLeave += new System.EventHandler(this.ProjektFul_MouseLeave);
            // 
            // prjLeiras
            // 
            this.prjLeiras.AutoSize = true;
            this.prjLeiras.BackColor = System.Drawing.Color.Transparent;
            this.prjLeiras.Location = new System.Drawing.Point(4, 20);
            this.prjLeiras.MaximumSize = new System.Drawing.Size(120, 13);
            this.prjLeiras.MinimumSize = new System.Drawing.Size(0, 13);
            this.prjLeiras.Name = "prjLeiras";
            this.prjLeiras.Size = new System.Drawing.Size(37, 13);
            this.prjLeiras.TabIndex = 2;
            this.prjLeiras.Text = "Leírás";
            this.prjLeiras.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProjektFul_MouseClick);
            this.prjLeiras.MouseEnter += new System.EventHandler(this.ProjektFul_MouseEnter);
            this.prjLeiras.MouseLeave += new System.EventHandler(this.ProjektFul_MouseLeave);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 1000;
            this.toolTip1.AutoPopDelay = 1000;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 500;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Image = global::EKNyilvantarto.Properties.Resources.preferences_icon_16px;
            this.button1.Location = new System.Drawing.Point(193, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.ProjektFul_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.ProjektFul_MouseLeave);
            // 
            // ProjektFul
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.prjLeiras);
            this.Controls.Add(this.prjNev);
            this.Name = "ProjektFul";
            this.Size = new System.Drawing.Size(220, 38);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProjektFul_MouseClick);
            this.MouseEnter += new System.EventHandler(this.ProjektFul_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ProjektFul_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label prjNev;
        private System.Windows.Forms.Label prjLeiras;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button button1;
    }
}
