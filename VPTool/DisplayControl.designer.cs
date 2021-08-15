namespace VPTool
{
    partial class DisplayControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplayControl));
            this.crdImage = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisplayStatusBarV21 = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.btnOpenMenu = new System.Windows.Forms.Button();
            this.btnCameraLiveMode = new System.Windows.Forms.Button();
            this.btnInputImage = new System.Windows.Forms.Button();
            this.btnEditTool = new System.Windows.Forms.Button();
            this.btnTriggerOnce = new System.Windows.Forms.Button();
            this.btnTriggerContinue = new System.Windows.Forms.Button();
            this.btnControlSizeChange = new System.Windows.Forms.Button();
            this.lblStationName = new System.Windows.Forms.Label();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.btnEditCamera = new System.Windows.Forms.Button();
            this.pnlHLine = new System.Windows.Forms.Panel();
            this.pnlSLine = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.crdImage)).BeginInit();
            this.SuspendLayout();
            // 
            // crdImage
            // 
            this.crdImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crdImage.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.crdImage.ColorMapLowerRoiLimit = 0D;
            this.crdImage.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.crdImage.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.crdImage.ColorMapUpperRoiLimit = 1D;
            this.crdImage.DoubleTapZoomCycleLength = 2;
            this.crdImage.DoubleTapZoomSensitivity = 2.5D;
            this.crdImage.Location = new System.Drawing.Point(0, 0);
            this.crdImage.Margin = new System.Windows.Forms.Padding(0);
            this.crdImage.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.crdImage.MouseWheelSensitivity = 1D;
            this.crdImage.Name = "crdImage";
            this.crdImage.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("crdImage.OcxState")));
            this.crdImage.Size = new System.Drawing.Size(515, 468);
            this.crdImage.TabIndex = 0;
            // 
            // cogDisplayStatusBarV21
            // 
            this.cogDisplayStatusBarV21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cogDisplayStatusBarV21.BackColor = System.Drawing.SystemColors.Control;
            this.cogDisplayStatusBarV21.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarV21.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarV21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cogDisplayStatusBarV21.Location = new System.Drawing.Point(3, 471);
            this.cogDisplayStatusBarV21.Name = "cogDisplayStatusBarV21";
            this.cogDisplayStatusBarV21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarV21.Size = new System.Drawing.Size(515, 22);
            this.cogDisplayStatusBarV21.TabIndex = 1;
            this.cogDisplayStatusBarV21.Use3DCoordinateSpaceTree = false;
            // 
            // btnOpenMenu
            // 
            this.btnOpenMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenMenu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOpenMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenMenu.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenMenu.ForeColor = System.Drawing.Color.White;
            this.btnOpenMenu.Location = new System.Drawing.Point(425, 0);
            this.btnOpenMenu.Margin = new System.Windows.Forms.Padding(0);
            this.btnOpenMenu.Name = "btnOpenMenu";
            this.btnOpenMenu.Size = new System.Drawing.Size(90, 30);
            this.btnOpenMenu.TabIndex = 2;
            this.btnOpenMenu.Tag = "UserControl";
            this.btnOpenMenu.Text = "展开菜单";
            this.btnOpenMenu.UseVisualStyleBackColor = false;
            this.btnOpenMenu.Visible = false;
            this.btnOpenMenu.Click += new System.EventHandler(this.btnOpenMenu_Click);
            // 
            // btnCameraLiveMode
            // 
            this.btnCameraLiveMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCameraLiveMode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCameraLiveMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCameraLiveMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCameraLiveMode.ForeColor = System.Drawing.Color.White;
            this.btnCameraLiveMode.Location = new System.Drawing.Point(425, 30);
            this.btnCameraLiveMode.Margin = new System.Windows.Forms.Padding(0);
            this.btnCameraLiveMode.Name = "btnCameraLiveMode";
            this.btnCameraLiveMode.Size = new System.Drawing.Size(90, 30);
            this.btnCameraLiveMode.TabIndex = 3;
            this.btnCameraLiveMode.Tag = "UserControl";
            this.btnCameraLiveMode.Text = "打开实时";
            this.btnCameraLiveMode.UseVisualStyleBackColor = false;
            this.btnCameraLiveMode.Visible = false;
            this.btnCameraLiveMode.Click += new System.EventHandler(this.btnCameraLiveMode_Click);
            // 
            // btnInputImage
            // 
            this.btnInputImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInputImage.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnInputImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInputImage.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnInputImage.ForeColor = System.Drawing.Color.White;
            this.btnInputImage.Location = new System.Drawing.Point(425, 60);
            this.btnInputImage.Margin = new System.Windows.Forms.Padding(0);
            this.btnInputImage.Name = "btnInputImage";
            this.btnInputImage.Size = new System.Drawing.Size(90, 30);
            this.btnInputImage.TabIndex = 4;
            this.btnInputImage.Tag = "UserControl";
            this.btnInputImage.Text = "导入图片";
            this.btnInputImage.UseVisualStyleBackColor = false;
            this.btnInputImage.Visible = false;
            this.btnInputImage.Click += new System.EventHandler(this.btnInputImage_Click);
            // 
            // btnEditTool
            // 
            this.btnEditTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTool.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEditTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTool.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditTool.ForeColor = System.Drawing.Color.White;
            this.btnEditTool.Location = new System.Drawing.Point(425, 120);
            this.btnEditTool.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditTool.Name = "btnEditTool";
            this.btnEditTool.Size = new System.Drawing.Size(90, 30);
            this.btnEditTool.TabIndex = 5;
            this.btnEditTool.Tag = "UserControl";
            this.btnEditTool.Text = "工具编辑";
            this.btnEditTool.UseVisualStyleBackColor = false;
            this.btnEditTool.Visible = false;
            this.btnEditTool.Click += new System.EventHandler(this.btnEditTool_Click);
            // 
            // btnTriggerOnce
            // 
            this.btnTriggerOnce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTriggerOnce.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTriggerOnce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriggerOnce.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTriggerOnce.ForeColor = System.Drawing.Color.White;
            this.btnTriggerOnce.Location = new System.Drawing.Point(425, 150);
            this.btnTriggerOnce.Margin = new System.Windows.Forms.Padding(0);
            this.btnTriggerOnce.Name = "btnTriggerOnce";
            this.btnTriggerOnce.Size = new System.Drawing.Size(90, 30);
            this.btnTriggerOnce.TabIndex = 6;
            this.btnTriggerOnce.Tag = "UserControl";
            this.btnTriggerOnce.Text = "单次触发";
            this.btnTriggerOnce.UseVisualStyleBackColor = false;
            this.btnTriggerOnce.Visible = false;
            this.btnTriggerOnce.Click += new System.EventHandler(this.btnTriggerOnce_Click);
            // 
            // btnTriggerContinue
            // 
            this.btnTriggerContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTriggerContinue.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTriggerContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTriggerContinue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTriggerContinue.ForeColor = System.Drawing.Color.White;
            this.btnTriggerContinue.Location = new System.Drawing.Point(425, 180);
            this.btnTriggerContinue.Margin = new System.Windows.Forms.Padding(0);
            this.btnTriggerContinue.Name = "btnTriggerContinue";
            this.btnTriggerContinue.Size = new System.Drawing.Size(90, 30);
            this.btnTriggerContinue.TabIndex = 7;
            this.btnTriggerContinue.Tag = "UserControl";
            this.btnTriggerContinue.Text = "连续触发";
            this.btnTriggerContinue.UseVisualStyleBackColor = false;
            this.btnTriggerContinue.Visible = false;
            this.btnTriggerContinue.Click += new System.EventHandler(this.btnTriggerContinue_Click);
            // 
            // btnControlSizeChange
            // 
            this.btnControlSizeChange.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnControlSizeChange.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnControlSizeChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnControlSizeChange.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnControlSizeChange.ForeColor = System.Drawing.Color.White;
            this.btnControlSizeChange.Location = new System.Drawing.Point(425, 210);
            this.btnControlSizeChange.Margin = new System.Windows.Forms.Padding(0);
            this.btnControlSizeChange.Name = "btnControlSizeChange";
            this.btnControlSizeChange.Size = new System.Drawing.Size(90, 30);
            this.btnControlSizeChange.TabIndex = 10;
            this.btnControlSizeChange.Tag = "UserControl";
            this.btnControlSizeChange.Text = "放大显示";
            this.btnControlSizeChange.UseVisualStyleBackColor = false;
            this.btnControlSizeChange.Visible = false;
            this.btnControlSizeChange.Click += new System.EventHandler(this.btnControlSizeChange_Click);
            // 
            // lblStationName
            // 
            this.lblStationName.AutoSize = true;
            this.lblStationName.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lblStationName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStationName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStationName.ForeColor = System.Drawing.Color.White;
            this.lblStationName.Location = new System.Drawing.Point(0, 0);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(72, 16);
            this.lblStationName.TabIndex = 11;
            this.lblStationName.Text = "工位名称";
            this.lblStationName.DoubleClick += new System.EventHandler(this.lblStationName_DoubleClick);
            // 
            // txtStationName
            // 
            this.txtStationName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtStationName.Location = new System.Drawing.Point(0, 0);
            this.txtStationName.Margin = new System.Windows.Forms.Padding(0);
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(90, 26);
            this.txtStationName.TabIndex = 13;
            this.txtStationName.Visible = false;
            this.txtStationName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStationName_KeyDown);
            this.txtStationName.Leave += new System.EventHandler(this.txtStationName_Leave);
            // 
            // btnEditCamera
            // 
            this.btnEditCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditCamera.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEditCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCamera.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEditCamera.ForeColor = System.Drawing.Color.White;
            this.btnEditCamera.Location = new System.Drawing.Point(425, 90);
            this.btnEditCamera.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditCamera.Name = "btnEditCamera";
            this.btnEditCamera.Size = new System.Drawing.Size(90, 30);
            this.btnEditCamera.TabIndex = 14;
            this.btnEditCamera.Tag = "UserControl";
            this.btnEditCamera.Text = "相机编辑";
            this.btnEditCamera.UseVisualStyleBackColor = false;
            this.btnEditCamera.Visible = false;
            this.btnEditCamera.Click += new System.EventHandler(this.btnEditCamera_Click);
            // 
            // pnlHLine
            // 
            this.pnlHLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHLine.BackColor = System.Drawing.Color.Red;
            this.pnlHLine.Location = new System.Drawing.Point(0, 235);
            this.pnlHLine.Name = "pnlHLine";
            this.pnlHLine.Size = new System.Drawing.Size(515, 1);
            this.pnlHLine.TabIndex = 15;
            this.pnlHLine.Visible = false;
            // 
            // pnlSLine
            // 
            this.pnlSLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlSLine.BackColor = System.Drawing.Color.Red;
            this.pnlSLine.Location = new System.Drawing.Point(257, 0);
            this.pnlSLine.Name = "pnlSLine";
            this.pnlSLine.Size = new System.Drawing.Size(1, 468);
            this.pnlSLine.TabIndex = 16;
            this.pnlSLine.Visible = false;
            // 
            // DisplayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnEditCamera);
            this.Controls.Add(this.txtStationName);
            this.Controls.Add(this.lblStationName);
            this.Controls.Add(this.btnControlSizeChange);
            this.Controls.Add(this.btnTriggerContinue);
            this.Controls.Add(this.btnTriggerOnce);
            this.Controls.Add(this.btnEditTool);
            this.Controls.Add(this.btnInputImage);
            this.Controls.Add(this.btnCameraLiveMode);
            this.Controls.Add(this.btnOpenMenu);
            this.Controls.Add(this.pnlHLine);
            this.Controls.Add(this.pnlSLine);
            this.Controls.Add(this.crdImage);
            this.Controls.Add(this.cogDisplayStatusBarV21);
            this.Name = "DisplayControl";
            this.Size = new System.Drawing.Size(515, 496);
            this.Load += new System.EventHandler(this.UserControlStation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.crdImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Cognex.VisionPro.CogRecordDisplay crdImage;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarV21;
        private System.Windows.Forms.Button btnOpenMenu;
        private System.Windows.Forms.Button btnCameraLiveMode;
        private System.Windows.Forms.Button btnInputImage;
        private System.Windows.Forms.Button btnEditTool;
        private System.Windows.Forms.Button btnTriggerOnce;
        private System.Windows.Forms.Button btnTriggerContinue;
        private System.Windows.Forms.Button btnControlSizeChange;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Button btnEditCamera;
        private System.Windows.Forms.Panel pnlHLine;
        private System.Windows.Forms.Panel pnlSLine;
    }
}
