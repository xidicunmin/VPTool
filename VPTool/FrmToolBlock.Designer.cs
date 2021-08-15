namespace VPTool
{
    partial class FrmToolBlock
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
            this.cogToolBlockEditV21 = new Cognex.VisionPro.ToolBlock.CogToolBlockEditV2();
            this.grpTestModule = new System.Windows.Forms.GroupBox();
            this.pnlNextImage = new System.Windows.Forms.Panel();
            this.btnNextImage = new System.Windows.Forms.Button();
            this.pnlLastImage = new System.Windows.Forms.Panel();
            this.btnLastImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudAutoRunTime = new System.Windows.Forms.NumericUpDown();
            this.chkAutoRun = new System.Windows.Forms.CheckBox();
            this.lblImageCount = new System.Windows.Forms.Label();
            this.btnInputImages = new System.Windows.Forms.Button();
            this.btnInputImage = new System.Windows.Forms.Button();
            this.chkCheckerboardTool = new System.Windows.Forms.CheckBox();
            this.chkNPointToNPointTool = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).BeginInit();
            this.grpTestModule.SuspendLayout();
            this.pnlNextImage.SuspendLayout();
            this.pnlLastImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoRunTime)).BeginInit();
            this.SuspendLayout();
            // 
            // cogToolBlockEditV21
            // 
            this.cogToolBlockEditV21.AllowDrop = true;
            this.cogToolBlockEditV21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cogToolBlockEditV21.ContextMenuCustomizer = null;
            this.cogToolBlockEditV21.Location = new System.Drawing.Point(12, 83);
            this.cogToolBlockEditV21.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogToolBlockEditV21.Name = "cogToolBlockEditV21";
            this.cogToolBlockEditV21.ShowNodeToolTips = true;
            this.cogToolBlockEditV21.Size = new System.Drawing.Size(760, 466);
            this.cogToolBlockEditV21.SuspendElectricRuns = false;
            this.cogToolBlockEditV21.TabIndex = 0;
            // 
            // grpTestModule
            // 
            this.grpTestModule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTestModule.Controls.Add(this.chkNPointToNPointTool);
            this.grpTestModule.Controls.Add(this.chkCheckerboardTool);
            this.grpTestModule.Controls.Add(this.pnlNextImage);
            this.grpTestModule.Controls.Add(this.pnlLastImage);
            this.grpTestModule.Controls.Add(this.label1);
            this.grpTestModule.Controls.Add(this.nudAutoRunTime);
            this.grpTestModule.Controls.Add(this.chkAutoRun);
            this.grpTestModule.Controls.Add(this.lblImageCount);
            this.grpTestModule.Controls.Add(this.btnInputImages);
            this.grpTestModule.Controls.Add(this.btnInputImage);
            this.grpTestModule.Location = new System.Drawing.Point(12, 11);
            this.grpTestModule.Name = "grpTestModule";
            this.grpTestModule.Size = new System.Drawing.Size(760, 66);
            this.grpTestModule.TabIndex = 1;
            this.grpTestModule.TabStop = false;
            this.grpTestModule.Text = "调试功能";
            // 
            // pnlNextImage
            // 
            this.pnlNextImage.Controls.Add(this.btnNextImage);
            this.pnlNextImage.Location = new System.Drawing.Point(247, 15);
            this.pnlNextImage.Name = "pnlNextImage";
            this.pnlNextImage.Size = new System.Drawing.Size(80, 26);
            this.pnlNextImage.TabIndex = 9;
            // 
            // btnNextImage
            // 
            this.btnNextImage.Enabled = false;
            this.btnNextImage.Location = new System.Drawing.Point(2, 3);
            this.btnNextImage.Name = "btnNextImage";
            this.btnNextImage.Size = new System.Drawing.Size(75, 21);
            this.btnNextImage.TabIndex = 3;
            this.btnNextImage.Text = "下一张";
            this.btnNextImage.UseVisualStyleBackColor = true;
            this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
            // 
            // pnlLastImage
            // 
            this.pnlLastImage.Controls.Add(this.btnLastImage);
            this.pnlLastImage.Location = new System.Drawing.Point(165, 15);
            this.pnlLastImage.Name = "pnlLastImage";
            this.pnlLastImage.Size = new System.Drawing.Size(80, 26);
            this.pnlLastImage.TabIndex = 8;
            // 
            // btnLastImage
            // 
            this.btnLastImage.Enabled = false;
            this.btnLastImage.Location = new System.Drawing.Point(3, 3);
            this.btnLastImage.Name = "btnLastImage";
            this.btnLastImage.Size = new System.Drawing.Size(75, 21);
            this.btnLastImage.TabIndex = 2;
            this.btnLastImage.Text = "上一张";
            this.btnLastImage.UseVisualStyleBackColor = true;
            this.btnLastImage.Click += new System.EventHandler(this.btnLastImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "ms自动运行";
            // 
            // nudAutoRunTime
            // 
            this.nudAutoRunTime.Location = new System.Drawing.Point(60, 42);
            this.nudAutoRunTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudAutoRunTime.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAutoRunTime.Name = "nudAutoRunTime";
            this.nudAutoRunTime.Size = new System.Drawing.Size(60, 21);
            this.nudAutoRunTime.TabIndex = 6;
            this.nudAutoRunTime.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // chkAutoRun
            // 
            this.chkAutoRun.AutoSize = true;
            this.chkAutoRun.Location = new System.Drawing.Point(6, 45);
            this.chkAutoRun.Name = "chkAutoRun";
            this.chkAutoRun.Size = new System.Drawing.Size(48, 16);
            this.chkAutoRun.TabIndex = 5;
            this.chkAutoRun.Text = "间隔";
            this.chkAutoRun.UseVisualStyleBackColor = true;
            // 
            // lblImageCount
            // 
            this.lblImageCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageCount.Location = new System.Drawing.Point(574, 22);
            this.lblImageCount.Name = "lblImageCount";
            this.lblImageCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblImageCount.Size = new System.Drawing.Size(180, 21);
            this.lblImageCount.TabIndex = 4;
            this.lblImageCount.Text = "当前图像：（0/0）";
            this.lblImageCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnInputImages
            // 
            this.btnInputImages.Location = new System.Drawing.Point(87, 18);
            this.btnInputImages.Name = "btnInputImages";
            this.btnInputImages.Size = new System.Drawing.Size(75, 21);
            this.btnInputImages.TabIndex = 1;
            this.btnInputImages.Text = "导入多张";
            this.btnInputImages.UseVisualStyleBackColor = true;
            this.btnInputImages.Click += new System.EventHandler(this.btnInputImages_Click);
            // 
            // btnInputImage
            // 
            this.btnInputImage.Location = new System.Drawing.Point(6, 18);
            this.btnInputImage.Name = "btnInputImage";
            this.btnInputImage.Size = new System.Drawing.Size(75, 21);
            this.btnInputImage.TabIndex = 0;
            this.btnInputImage.Text = "导入单张";
            this.btnInputImage.UseVisualStyleBackColor = true;
            this.btnInputImage.Click += new System.EventHandler(this.btnInputImage_Click);
            // 
            // chkCheckerboardTool
            // 
            this.chkCheckerboardTool.AutoSize = true;
            this.chkCheckerboardTool.Location = new System.Drawing.Point(197, 45);
            this.chkCheckerboardTool.Name = "chkCheckerboardTool";
            this.chkCheckerboardTool.Size = new System.Drawing.Size(84, 16);
            this.chkCheckerboardTool.TabIndex = 10;
            this.chkCheckerboardTool.Text = "棋盘格矫正";
            this.chkCheckerboardTool.UseVisualStyleBackColor = true;
            // 
            // chkNPointToNPointTool
            // 
            this.chkNPointToNPointTool.AutoSize = true;
            this.chkNPointToNPointTool.Location = new System.Drawing.Point(287, 45);
            this.chkNPointToNPointTool.Name = "chkNPointToNPointTool";
            this.chkNPointToNPointTool.Size = new System.Drawing.Size(84, 16);
            this.chkNPointToNPointTool.TabIndex = 11;
            this.chkNPointToNPointTool.Text = "坐标系转换";
            this.chkNPointToNPointTool.UseVisualStyleBackColor = true;
            // 
            // FrmToolBlock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.grpTestModule);
            this.Controls.Add(this.cogToolBlockEditV21);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "FrmToolBlock";
            this.Text = "工具编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCogFitCircleTool_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cogToolBlockEditV21)).EndInit();
            this.grpTestModule.ResumeLayout(false);
            this.grpTestModule.PerformLayout();
            this.pnlNextImage.ResumeLayout(false);
            this.pnlLastImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudAutoRunTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.ToolBlock.CogToolBlockEditV2 cogToolBlockEditV21;
        private System.Windows.Forms.GroupBox grpTestModule;
        private System.Windows.Forms.Label lblImageCount;
        private System.Windows.Forms.Button btnNextImage;
        private System.Windows.Forms.Button btnLastImage;
        private System.Windows.Forms.Button btnInputImages;
        private System.Windows.Forms.Button btnInputImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudAutoRunTime;
        private System.Windows.Forms.CheckBox chkAutoRun;
        private System.Windows.Forms.Panel pnlLastImage;
        private System.Windows.Forms.Panel pnlNextImage;
        private System.Windows.Forms.CheckBox chkNPointToNPointTool;
        private System.Windows.Forms.CheckBox chkCheckerboardTool;
    }
}