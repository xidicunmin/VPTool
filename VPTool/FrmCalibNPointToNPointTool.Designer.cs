namespace VPTool
{
    partial class FrmCalibNPointToNPointTool
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
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.cogCalibNPointToNPointEditV21 = new Cognex.VisionPro.CalibFix.CogCalibNPointToNPointEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibNPointToNPointEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(248, 3);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenImage.TabIndex = 1;
            this.btnOpenImage.Text = "打开图像";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // cogCalibNPointToNPointEditV21
            // 
            this.cogCalibNPointToNPointEditV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogCalibNPointToNPointEditV21.Location = new System.Drawing.Point(0, 0);
            this.cogCalibNPointToNPointEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogCalibNPointToNPointEditV21.Name = "cogCalibNPointToNPointEditV21";
            this.cogCalibNPointToNPointEditV21.Size = new System.Drawing.Size(784, 561);
            this.cogCalibNPointToNPointEditV21.SuspendElectricRuns = false;
            this.cogCalibNPointToNPointEditV21.TabIndex = 2;
            // 
            // FrmCalibNPointToNPointTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.cogCalibNPointToNPointEditV21);
            this.Name = "FrmCalibNPointToNPointTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCalibCheckerboardTool_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibNPointToNPointEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenImage;
        private Cognex.VisionPro.CalibFix.CogCalibNPointToNPointEditV2 cogCalibNPointToNPointEditV21;
    }
}