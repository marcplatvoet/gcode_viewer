namespace gcode_viewer
{
    partial class DXF_to_Gcode
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenFile_AX1 = new System.Windows.Forms.Button();
            this.txtFilename_AX1 = new System.Windows.Forms.TextBox();
            this.pictureBox_AX1 = new System.Windows.Forms.PictureBox();
            this.chkFlipX = new System.Windows.Forms.CheckBox();
            this.chkFlipY = new System.Windows.Forms.CheckBox();
            this.pictureBox_AX2 = new System.Windows.Forms.PictureBox();
            this.txtFilename_AX2 = new System.Windows.Forms.TextBox();
            this.btnOpenFile_AX2 = new System.Windows.Forms.Button();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.lblPoints = new System.Windows.Forms.Label();
            this.pictureBoxSimulate = new System.Windows.Forms.PictureBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.btnGcode = new System.Windows.Forms.Button();
            this.txtCuttingSpeed = new System.Windows.Forms.TextBox();
            this.lblCuttingSpeed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimulate)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnOpenFile_AX1
            // 
            this.btnOpenFile_AX1.Location = new System.Drawing.Point(382, 250);
            this.btnOpenFile_AX1.Name = "btnOpenFile_AX1";
            this.btnOpenFile_AX1.Size = new System.Drawing.Size(24, 20);
            this.btnOpenFile_AX1.TabIndex = 2;
            this.btnOpenFile_AX1.Text = "..";
            this.btnOpenFile_AX1.UseVisualStyleBackColor = true;
            this.btnOpenFile_AX1.Click += new System.EventHandler(this.btnOpenFile_AX1_Click);
            // 
            // txtFilename_AX1
            // 
            this.txtFilename_AX1.Location = new System.Drawing.Point(12, 250);
            this.txtFilename_AX1.Name = "txtFilename_AX1";
            this.txtFilename_AX1.Size = new System.Drawing.Size(364, 20);
            this.txtFilename_AX1.TabIndex = 3;
            // 
            // pictureBox_AX1
            // 
            this.pictureBox_AX1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_AX1.Name = "pictureBox_AX1";
            this.pictureBox_AX1.Size = new System.Drawing.Size(662, 232);
            this.pictureBox_AX1.TabIndex = 5;
            this.pictureBox_AX1.TabStop = false;
            // 
            // chkFlipX
            // 
            this.chkFlipX.AutoSize = true;
            this.chkFlipX.Location = new System.Drawing.Point(707, 15);
            this.chkFlipX.Name = "chkFlipX";
            this.chkFlipX.Size = new System.Drawing.Size(52, 17);
            this.chkFlipX.TabIndex = 6;
            this.chkFlipX.Text = "Flip X";
            this.chkFlipX.UseVisualStyleBackColor = true;
            this.chkFlipX.CheckedChanged += new System.EventHandler(this.chkFlipX_CheckedChanged);
            // 
            // chkFlipY
            // 
            this.chkFlipY.AutoSize = true;
            this.chkFlipY.Location = new System.Drawing.Point(707, 38);
            this.chkFlipY.Name = "chkFlipY";
            this.chkFlipY.Size = new System.Drawing.Size(52, 17);
            this.chkFlipY.TabIndex = 7;
            this.chkFlipY.Text = "Flip Y";
            this.chkFlipY.UseVisualStyleBackColor = true;
            this.chkFlipY.CheckedChanged += new System.EventHandler(this.chkFlipY_CheckedChanged);
            // 
            // pictureBox_AX2
            // 
            this.pictureBox_AX2.Location = new System.Drawing.Point(12, 276);
            this.pictureBox_AX2.Name = "pictureBox_AX2";
            this.pictureBox_AX2.Size = new System.Drawing.Size(662, 247);
            this.pictureBox_AX2.TabIndex = 8;
            this.pictureBox_AX2.TabStop = false;
            // 
            // txtFilename_AX2
            // 
            this.txtFilename_AX2.Location = new System.Drawing.Point(12, 529);
            this.txtFilename_AX2.Name = "txtFilename_AX2";
            this.txtFilename_AX2.Size = new System.Drawing.Size(364, 20);
            this.txtFilename_AX2.TabIndex = 9;
            // 
            // btnOpenFile_AX2
            // 
            this.btnOpenFile_AX2.Location = new System.Drawing.Point(382, 529);
            this.btnOpenFile_AX2.Name = "btnOpenFile_AX2";
            this.btnOpenFile_AX2.Size = new System.Drawing.Size(24, 20);
            this.btnOpenFile_AX2.TabIndex = 10;
            this.btnOpenFile_AX2.Text = "..";
            this.btnOpenFile_AX2.UseVisualStyleBackColor = true;
            this.btnOpenFile_AX2.Click += new System.EventHandler(this.btnOpenFile_AX2_Click);
            // 
            // txtPoints
            // 
            this.txtPoints.Location = new System.Drawing.Point(950, 12);
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(37, 20);
            this.txtPoints.TabIndex = 13;
            this.txtPoints.Text = "500";
            // 
            // lblPoints
            // 
            this.lblPoints.AutoSize = true;
            this.lblPoints.Location = new System.Drawing.Point(908, 15);
            this.lblPoints.Name = "lblPoints";
            this.lblPoints.Size = new System.Drawing.Size(36, 13);
            this.lblPoints.TabIndex = 14;
            this.lblPoints.Text = "Points";
            // 
            // pictureBoxSimulate
            // 
            this.pictureBoxSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSimulate.Location = new System.Drawing.Point(765, 38);
            this.pictureBoxSimulate.Name = "pictureBoxSimulate";
            this.pictureBoxSimulate.Size = new System.Drawing.Size(578, 485);
            this.pictureBoxSimulate.TabIndex = 15;
            this.pictureBoxSimulate.TabStop = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(684, 276);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 16;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSimulate
            // 
            this.btnSimulate.Location = new System.Drawing.Point(684, 305);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(75, 23);
            this.btnSimulate.TabIndex = 17;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.btnSimulate_Click);
            // 
            // btnGcode
            // 
            this.btnGcode.Location = new System.Drawing.Point(684, 334);
            this.btnGcode.Name = "btnGcode";
            this.btnGcode.Size = new System.Drawing.Size(75, 23);
            this.btnGcode.TabIndex = 18;
            this.btnGcode.Text = "Gcode";
            this.btnGcode.UseVisualStyleBackColor = true;
            this.btnGcode.Click += new System.EventHandler(this.btnGcode_Click);
            // 
            // txtCuttingSpeed
            // 
            this.txtCuttingSpeed.Location = new System.Drawing.Point(493, 564);
            this.txtCuttingSpeed.Name = "txtCuttingSpeed";
            this.txtCuttingSpeed.Size = new System.Drawing.Size(35, 20);
            this.txtCuttingSpeed.TabIndex = 19;
            this.txtCuttingSpeed.Text = "75";
            this.txtCuttingSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCuttingSpeed
            // 
            this.lblCuttingSpeed.AutoSize = true;
            this.lblCuttingSpeed.Location = new System.Drawing.Point(415, 567);
            this.lblCuttingSpeed.Name = "lblCuttingSpeed";
            this.lblCuttingSpeed.Size = new System.Drawing.Size(72, 13);
            this.lblCuttingSpeed.TabIndex = 20;
            this.lblCuttingSpeed.Text = "Cutting speed";
            // 
            // DXF_to_Gcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 639);
            this.Controls.Add(this.lblCuttingSpeed);
            this.Controls.Add(this.txtCuttingSpeed);
            this.Controls.Add(this.btnGcode);
            this.Controls.Add(this.btnSimulate);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.pictureBoxSimulate);
            this.Controls.Add(this.lblPoints);
            this.Controls.Add(this.txtPoints);
            this.Controls.Add(this.btnOpenFile_AX2);
            this.Controls.Add(this.txtFilename_AX2);
            this.Controls.Add(this.pictureBox_AX2);
            this.Controls.Add(this.chkFlipY);
            this.Controls.Add(this.chkFlipX);
            this.Controls.Add(this.pictureBox_AX1);
            this.Controls.Add(this.txtFilename_AX1);
            this.Controls.Add(this.btnOpenFile_AX1);
            this.Name = "DXF_to_Gcode";
            this.Text = "DXF to Gcode";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSimulate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenFile_AX1;
        private System.Windows.Forms.TextBox txtFilename_AX1;
        private System.Windows.Forms.PictureBox pictureBox_AX1;
        private System.Windows.Forms.CheckBox chkFlipX;
        private System.Windows.Forms.CheckBox chkFlipY;
        private System.Windows.Forms.PictureBox pictureBox_AX2;
        private System.Windows.Forms.TextBox txtFilename_AX2;
        private System.Windows.Forms.Button btnOpenFile_AX2;
        private System.Windows.Forms.TextBox txtPoints;
        private System.Windows.Forms.Label lblPoints;
        private System.Windows.Forms.PictureBox pictureBoxSimulate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.Button btnGcode;
        private System.Windows.Forms.TextBox txtCuttingSpeed;
        private System.Windows.Forms.Label lblCuttingSpeed;
    }
}

