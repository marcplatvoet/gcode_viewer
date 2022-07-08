namespace gcode_viewer
{
    partial class gcode
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
            this.txtGcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtGcode
            // 
            this.txtGcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGcode.Location = new System.Drawing.Point(0, 0);
            this.txtGcode.Multiline = true;
            this.txtGcode.Name = "txtGcode";
            this.txtGcode.Size = new System.Drawing.Size(800, 450);
            this.txtGcode.TabIndex = 0;
            // 
            // gcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtGcode);
            this.Name = "gcode";
            this.Text = "gcode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtGcode;
    }
}