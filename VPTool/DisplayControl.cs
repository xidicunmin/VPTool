using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;

namespace VPTool
{
    public partial class DisplayControl : UserControl
    {

        public DisplayControl()
        {
            InitializeComponent();
        }

        private string _stationName = "未知";

        /// <summary>
        /// 工位控件触发事件委托
        /// </summary>
        /// <param name="stationName">控件名称</param>
        /// <param name="eventType">事件类型</param>
        /// <param name="message">事件说明（或工位名称）</param>
        public delegate void OnTriggerEvent(string stationName, Member.DisplayControlEventType eventType,string message);

        public event OnTriggerEvent TriggerEvent;

        private int _originlX;

        private int _originlY;

        private int _originlWidth;

        private int _originlHeigth;

        private bool _isAdministrator;

        private CogRectangleAffine cogRectangleAffine = new CogRectangleAffine();

        public void AdministratorLogin(bool isLogin)
        {
            OpenMenu(false);
            _isAdministrator = isLogin;
        }

        public void SetStationName(string name)
        {
            _stationName = name;
            lblStationName.Text = _stationName;
        }

        public void SetMenuStatus(bool isOpen)
        {
            OpenMenu(false);
            btnOpenMenu.Visible = isOpen;
        }

        private void btnOpenMenu_Click(object sender, EventArgs e)
        {
            if (!_isAdministrator)
            {
                MessageBox.Show("权限不足", "提示", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            OpenMenu(btnOpenMenu.Text == @"展开菜单");
        }

        private void OpenMenu(bool open)
        {
            if (open)
            {
                btnOpenMenu.Text = @"收起菜单";
                btnCameraLiveMode.Visible = true;
                btnControlSizeChange.Visible = true;
                btnEditTool.Visible = true;
                btnInputImage.Visible = true;
                btnTriggerContinue.Visible = true;
                btnTriggerOnce.Visible = true;
                btnEditCamera.Visible = true;
            }
            else
            {
                btnOpenMenu.Text = @"展开菜单";
                btnCameraLiveMode.Visible = false;
                btnControlSizeChange.Visible = false;
                btnEditTool.Visible = false;
                btnInputImage.Visible = false;
                btnTriggerContinue.Visible = false;
                btnTriggerOnce.Visible = false;
                btnEditCamera.Visible = false;
            }
        }

        private void btnCameraLiveMode_Click(object sender, EventArgs e)
        {
            if (btnCameraLiveMode.Text == @"打开实时")
            {
               
                if (TriggerEvent != null)
                {
                    TriggerEvent(_stationName, Member.DisplayControlEventType.OpenLiveMode, "开启实时");
                }
            }
            else
            {
               
                if (TriggerEvent != null)
                {
                    TriggerEvent(_stationName, Member.DisplayControlEventType.CloseLiveMode, "关闭实时");
                }
            }
        }

        private void btnControlSizeChange_Click(object sender, EventArgs e)
        {
            if (btnControlSizeChange.Text == @"放大显示")
            {
                BringToFront();
                btnControlSizeChange.Text = @"缩小显示";
                _originlX = Location.X;
                _originlY = Location.Y;
                _originlHeigth = Height;
                _originlWidth = Width;
                Width = Parent.Width - 6;
                Height = Parent.Height - 6;
                Location = new Point(3,3);
            }
            else
            {
                SendToBack();
                btnControlSizeChange.Text = @"放大显示";
                Width = _originlWidth;
                Height = _originlHeigth;
                Location = new Point(_originlX,_originlY);
            }
        }

        private void UserControlStation_Load(object sender, EventArgs e)
        {
            cogDisplayStatusBarV21.Display = crdImage;
            lblStationName.Text = _stationName;

           
        }

        private void lblStationName_DoubleClick(object sender, EventArgs e)
        {
            if (!_isAdministrator)
            {
                MessageBox.Show("权限不足", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lblStationName.Visible = false;
            txtStationName.Text = lblStationName.Text;
            txtStationName.Visible = true;
            txtStationName.Focus();
        }

        private void txtStationName_Leave(object sender, EventArgs e)
        {
            if (txtStationName.Text.Trim() != "")
            {
                txtStationName.Visible = false;
                if (txtStationName.Text.Trim() != lblStationName.Text.Trim())
                {
                    lblStationName.Text = txtStationName.Text;
                    if (TriggerEvent != null)
                    {
                        TriggerEvent(_stationName, Member.DisplayControlEventType.EditStationName, lblStationName.Text);
                    }
                    _stationName = lblStationName.Text;
                }
                lblStationName.Visible = true;
            }
            else
            {
                MessageBox.Show(@"工位名称不能为空");
            }
        }

        private void txtStationName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtStationName.Text.Trim() != "")
                {
                    txtStationName.Visible = false;
                    if (txtStationName.Text.Trim() != lblStationName.Text.Trim())
                    {
                        lblStationName.Text = txtStationName.Text;
                        if (TriggerEvent != null)
                        {
                            TriggerEvent(_stationName, Member.DisplayControlEventType.EditStationName, lblStationName.Text);
                        }
                    }
                    lblStationName.Visible = true;
                }
                else
                {
                    MessageBox.Show(@"工位名称不能为空");
                }
            }
        }

        private void btnInputImage_Click(object sender, EventArgs e)
        {
            if (TriggerEvent != null)
            {
                TriggerEvent(_stationName, Member.DisplayControlEventType.InputImageTest, "导入图片");
            }
        }

        private void btnEditTool_Click(object sender, EventArgs e)
        {
            if (TriggerEvent != null)
            {
                TriggerEvent(_stationName, Member.DisplayControlEventType.EditVisionTool, "工具编辑");
            }
        }

        private void btnTriggerOnce_Click(object sender, EventArgs e)
        {
            if (TriggerEvent != null)
            {
                TriggerEvent(_stationName, Member.DisplayControlEventType.TriggerOnceTest, "单次触发");
            }
        }

        private void btnTriggerContinue_Click(object sender, EventArgs e)
        {
            if (btnTriggerContinue.Text == @"连续触发")
            {
                btnTriggerContinue.Text = @"停止触发";
                btnEditTool.Enabled = false;
                btnInputImage.Enabled = false;
                btnCameraLiveMode.Enabled = false;
                btnTriggerOnce.Enabled = false;
                lblStationName.Enabled = false;
                if (TriggerEvent != null)
                {
                    TriggerEvent(_stationName, Member.DisplayControlEventType.TriggerContinuousTest, "连续触发");
                }
            }
            else
            {
                btnTriggerContinue.Text = @"连续触发";
                btnEditTool.Enabled = true;
                btnInputImage.Enabled = true;
                btnCameraLiveMode.Enabled = true;
                btnTriggerOnce.Enabled = true;
                lblStationName.Enabled = true;
                if (TriggerEvent != null)
                {
                    TriggerEvent(_stationName, Member.DisplayControlEventType.CloseTriggerTest, "停止触发");
                }
            }
        }

        public void LiveMode(bool status, ICogAcqFifo acqFifo)
        {
            if (status)
            {
                crdImage.StartLiveDisplay(acqFifo);
                btnCameraLiveMode.Text = @"关闭实时";
                btnEditTool.Enabled = false;
                btnInputImage.Enabled = false;
                btnTriggerContinue.Enabled = false;
                btnTriggerOnce.Enabled = false;
                lblStationName.Enabled = false;
                btnEditCamera.Enabled = false;
            }
            else
            {
                crdImage.StopLiveDisplay();
                btnCameraLiveMode.Text = @"打开实时";
                btnEditTool.Enabled = true;
                btnInputImage.Enabled = true;
                btnTriggerContinue.Enabled = true;
                btnTriggerOnce.Enabled = true;
                lblStationName.Enabled = true;
                btnEditCamera.Enabled = true;
            }
        }

        public void SetDisplayImage(Member.VisionImage visionImage, List<Member.VisionDisplayResult> displayResults = null)
        {
            this.BeginInvoke(new Action(delegate {
                lock (crdImage)
                {
                    //清空显示画面
                    crdImage.StaticGraphics.Clear();
                    crdImage.InteractiveGraphics.Clear();

                    //赋值图像及画线结果
                    crdImage.Image = visionImage.CogImage;

                    if (visionImage.CogRecord != null)
                    {
                        crdImage.Record = visionImage.CogRecord;
                    }
                    //添加自定义显示信息
                    if (displayResults != null && visionImage.CogImage != null)
                    {
                        double x = visionImage.CogImage.Width * 0.03, y = visionImage.CogImage.Height * 0.07, d = visionImage.CogImage.Height * 0.09;
                        for (int i = 0; i < displayResults.Count; i++)
                        {
                            DisplayDrawString(CogGraphicLabelAlignmentConstants.TopLeft, displayResults[i].Value, x, y, displayResults[i].FontSize,
                                   displayResults[i].Status, crdImage);
                            y += d;
                        }
                    }
                }
            }));
        }

        //public void SetStationDisplayName(string name)
        //{
        //    lblStationName.Text = name;
        //}

        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
        public bool GetDisplayRecordImage(out Bitmap image,out string msg)
        {
            image = null;
            msg = string.Empty;
            bool status;
            try
            {
                ////得到空间
                //CogTransform2DLinear trans = new CogTransform2DLinear();
                //ICogTransform2D itrans = crdImage.Image.GetTransform("#", crdImage.Image.SelectedSpaceName);//
                //trans = (CogTransform2DLinear)itrans.InvertBase();

                ////map
                //double or_x, or_y, Wi, Hi;
                //trans.MapPoint(0, 0, out or_x, out or_y);
                //trans.MapPoint(crdImage.Image.Width, crdImage.Image.Height, out Wi, out Hi);

                ////赋值截取图像的矩形框大小
                //CogRectangle contentRect = new CogRectangle();
                //contentRect.SetXYWidthHeight(or_x, Hi, Wi - or_x, or_y - Hi);

                ////截取图像
                //image = crdImage.CreateContentBitmap(CogDisplayContentBitmapConstants.Custom, contentRect, 1024);
                if (crdImage.Image != null && crdImage.Record!=null)
                {
                    lock (crdImage)
                    {
                        image = (Bitmap)crdImage.CreateContentBitmap(CogDisplayContentBitmapConstants.Image);
                        //image = (Bitmap)crdImage.CreateContentBitmap(CogDisplayContentBitmapConstants.Display);
                        status = true;
                    }
                   
                }
                else
                {
                    status = false;
                    msg += "显示工位" + _stationName + "画线图为空，无法获取";
                }
               

            }
            catch (Exception e)
            {
                status = false;
                msg += "获取显示工位" + _stationName + "画线图异常：" + e.Message + "\r\n";
                // ignored
            }

            return status;
        }

        private void btnEditCamera_Click(object sender, EventArgs e)
        {
            if (TriggerEvent != null)
            {
                TriggerEvent(_stationName, Member.DisplayControlEventType.EditCamera, "相机编辑");
            }
        }
        
        /// <summary>
        /// 添加字符
        /// </summary>
        /// <param name="cogGraphicLabelAlignmentConstants"></param>
        /// <param name="msg"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="fontSize"></param>
        /// <param name="bResult"></param>
        /// <param name="display"></param>
        private void DisplayDrawString(CogGraphicLabelAlignmentConstants cogGraphicLabelAlignmentConstants,string msg, double x, double y, float fontSize, bool bResult,
            CogRecordDisplay display)
        {
            CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();
            cogGraphicLabel.Alignment = cogGraphicLabelAlignmentConstants;
            string space = "*";
            if (display.Image != null)
            {
                space = "*\\#";
            }

            CogColorConstants cogColor = CogColorConstants.Green;
            if (!bResult)
            {
                cogColor = CogColorConstants.Red;
            }
            Font font = new Font("微软雅黑",fontSize,FontStyle.Bold);
            cogGraphicLabel.Font = font;
            cogGraphicLabel.Color = cogColor;
            cogGraphicLabel.SelectedSpaceName = space;
            cogGraphicLabel.SetXYText(x,y,msg);
            display.Invoke(new Action(delegate { display.StaticGraphics.Add(cogGraphicLabel, ""); }));
        }

        public void SetAuxiliaryLine(bool open)
        {
            pnlHLine.Visible = pnlSLine.Visible = open;
        }

        public void SetInteractiveGraphics(bool open,out double centerX,out double centerY,out double xLength,out double yLength,out double rotation,out double skew)
        {
            centerX = 50;
            centerY = 50;
            xLength = 100;
            yLength = 100;
            rotation = 0;
            skew = 0;
            if (cogRectangleAffine != null)
            {
                if (open)
                {
                    cogRectangleAffine.SetCenterLengthsRotationSkew(centerX, centerY, xLength, yLength, rotation, skew);
                    cogRectangleAffine.Interactive = true;
                    cogRectangleAffine.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
                    crdImage.InteractiveGraphics.Add(cogRectangleAffine, "RectangleAffine", false);
                }
                else
                {
                    centerX = cogRectangleAffine.CenterX;
                    centerY = cogRectangleAffine.CenterY;
                    xLength = cogRectangleAffine.SideXLength;
                    yLength = cogRectangleAffine.SideYLength;
                    rotation = cogRectangleAffine.Rotation;
                    skew = cogRectangleAffine.Skew;
                    try
                    {
                        crdImage.InteractiveGraphics.Remove("RectangleAffine");
                    }
                    catch (Exception)
                    {

                    }
                    
                }
            }
        }
    }
}
