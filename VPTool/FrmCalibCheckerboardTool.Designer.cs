namespace VPTool
{
    partial class FrmCalibCheckerboardTool
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
            this.cogCalibCheckerboardEditV21 = new Cognex.VisionPro.CalibFix.CogCalibCheckerboardEditV2();
            this.btnOpenImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibCheckerboardEditV21)).BeginInit();
            this.SuspendLayout();
            // 
            // cogCalibCheckerboardEditV21
            // 
            this.cogCalibCheckerboardEditV21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogCalibCheckerboardEditV21.Location = new System.Drawing.Point(0, 0);
            this.cogCalibCheckerboardEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogCalibCheckerboardEditV21.Name = "cogCalibCheckerboardEditV21";
            this.cogCalibCheckerboardEditV21.Size = new System.Drawing.Size(784, 561);
            this.cogCalibCheckerboardEditV21.SuspendElectricRuns = false;
            this.cogCalibCheckerboardEditV21.TabIndex = 0;
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(278, 3);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(75, 23);
            this.btnOpenImage.TabIndex = 1;
            this.btnOpenImage.Text = "打开图像";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // FrmCalibCheckerboardTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.cogCalibCheckerboardEditV21);
            this.Name = "FrmCalibCheckerboardTool";
            this.Text = "FrmCalibCheckerboardTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCalibCheckerboardTool_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibCheckerboardEditV21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CalibFix.CogCalibCheckerboardEditV2 cogCalibCheckerboardEditV21;
        private System.Windows.Forms.Button btnOpenImage;
    }
}