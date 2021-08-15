using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace VPTool
{
    public partial class FrmToolBlock : System.Windows.Forms.Form
    {
        public FrmToolBlock()
        {
            InitializeComponent();
        }

        private List<string> testImagePathList = new List<string>();
        private CogToolBlock _cogToolBlock;
        private CogToolBlock _backupToolBlock;
        private CogCalibCheckerboardTool _cogCalibCheckerboard;
        private CogCalibNPointToNPointTool _cogCalibNPointToNPoint;
        private int _imageSelectCount = 0;

        //bool _save;
        int _toolBlockId;
        string _toolBlockKey;

        public delegate void OnToolBlockSave(string toolBlockKey,CogToolBlock editTool, CogToolBlock backupTool,bool save);
        public event OnToolBlockSave ToolBlockSave;

        /// <summary>
        /// 开启vpp编辑画面
        /// </summary>
        /// <param name="cogCalibCheckerboard">棋盘格矫正工具</param>
        /// <param name="cogCalibNPointToNPoint">坐标系标定工具</param>
        /// <param name="enableCheckerboard">启用棋盘格工具</param>
        /// <param name="enableCalibNPointToNPoint">启用坐标系工具</param>
        /// <param name="cogToolBlock">编辑vpp</param>
        /// <param name="backupToolBlock">备份vpp</param>
        /// <param name="toolBlockId">工具id</param>
        /// <param name="titleText">vpp名称</param>
        public void ShowEdit(CogCalibCheckerboardTool cogCalibCheckerboard, CogCalibNPointToNPointTool cogCalibNPointToNPoint, CogToolBlock cogToolBlock, CogToolBlock backupToolBlock, string toolBlockKey, string titleText)
        {
            //mod 20200918 by wangsizhe start
            ////_save = false;
            //if (cogToolBlock == null)
            //{
            //    cogToolBlock = new CogToolBlock();
            //}

            //if (cogCalibCheckerboard == null)
            //{
            //    cogCalibCheckerboard = new CogCalibCheckerboardTool();
            //}

            //if (cogCalibNPointToNPoint == null)
            //{
            //    cogCalibNPointToNPoint = new CogCalibNPointToNPointTool();
            //}

            //_enableCheckerboard = enableCheckerboard;
            //_enableCalibNPointToNPoint = enableCalibNPointToNPoint;
            //_cogCalibCheckerboard = cogCalibCheckerboard;
            //_cogCalibNPointToNPoint = cogCalibNPointToNPoint;
            //Text = titleText;
            //_backupToolBlock = backupToolBlock;
            //_cogToolBlock = cogToolBlock;
            //_toolBlockId = toolBlockId;
            //cogToolBlockEditV21.Subject = _cogToolBlock;
            //Show();
            cogToolBlockEditV21.Invoke(new Action(delegate
            {
                if (cogToolBlock == null)
                {
                    cogToolBlock = new CogToolBlock();
                }

                if (cogCalibCheckerboard == null)
                {
                    cogCalibCheckerboard = new CogCalibCheckerboardTool();
                }
                else
                {
                    chkCheckerboardTool.Checked = true;
                }

                if (cogCalibNPointToNPoint == null)
                {
                    cogCalibNPointToNPoint = new CogCalibNPointToNPointTool();
                }
                else
                {
                    chkNPointToNPointTool.Checked = true;
                }

                _cogCalibCheckerboard = cogCalibCheckerboard;
                _cogCalibNPointToNPoint = cogCalibNPointToNPoint;
                Text = titleText;
                _backupToolBlock = backupToolBlock;
                _cogToolBlock = cogToolBlock;
                _toolBlockKey = toolBlockKey;
                cogToolBlockEditV21.Subject = _cogToolBlock;
                Show();
            }));
            //mod 20200918 by wangsizhe end
        }

        private void frmCogFitCircleTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_save = MessageBox.Show(@"是否保存工具", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes;
            if (MessageBox.Show(@"是否保存工具", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (ToolBlockSave != null)
                {
                    ToolBlockSave(_toolBlockKey, _cogToolBlock,_backupToolBlock,true);
                }
            }
            else
            {
                if (ToolBlockSave != null)
                {
                    ToolBlockSave(_toolBlockKey, _cogToolBlock, _backupToolBlock, false);
                }
            }

            Dispose();
            Close();
        }

        private void RunTool(int imagePathSn)
        {
            if (testImagePathList.Count > imagePathSn)
            {
                CogImage8Grey img = new CogImage8Grey(new Bitmap(testImagePathList[imagePathSn]));
                //var imgFile = new CogImageFileTool();
                //imgFile.Operator.Open(testImagePathList[imagePathSn], CogImageFileModeConstants.Read);
                //imgFile.Run();
                //ICogImage img = imgFile.OutputImage;
                if (chkCheckerboardTool.Checked)
                {
                    _cogCalibCheckerboard.InputImage = img;
                    _cogCalibCheckerboard.Run();
                    img = (CogImage8Grey) _cogCalibCheckerboard.OutputImage;
                }
                //_cogToolBlock.Inputs[1].Value = img;
                if (chkNPointToNPointTool.Checked)
                {
                    _cogCalibNPointToNPoint.InputImage = img;
                    _cogCalibNPointToNPoint.Run();
                    img = (CogImage8Grey) _cogCalibNPointToNPoint.OutputImage;
                }
                _cogToolBlock.Inputs[0].Value = img;
                _cogToolBlock.Run();

                _imageSelectCount = imagePathSn + 1;
                RefreshImageCount();
            }
            else
            {
                MessageBox.Show(@"找不到指定图片");
            }

          

        }

        private void btnInputImage_Click(object sender, System.EventArgs e)
        {
            var ofg = new OpenFileDialog();
            ofg.DefaultExt = ".bmp";
            if (DialogResult.OK == ofg.ShowDialog())
            {
                if (!(ofg.FileName.ToLower().EndsWith(".bmp") || ofg.FileName.ToLower().EndsWith(".png")
                                                              || ofg.FileName.ToLower().EndsWith(".jpg")))
                {
                    MessageBox.Show(@"打开文件错误！");
                    return;
                }
                CleanImages();
                testImagePathList.Add(ofg.FileName);
                RunTool(0);
            }
        }

        private void btnInputImages_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择图片文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CleanImages();
                string foldPath = dialog.SelectedPath;
                string[] strs = System.IO.Directory.GetFiles(foldPath);
                foreach (string file in strs)
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(file);
                    if (fi.Extension == ".Jpg" || fi.Extension == ".Jpeg" || fi.Extension == ".Png" ||
                        fi.Extension == ".Bmp" || fi.Extension == ".jpg" || fi.Extension == ".jpeg" ||
                        fi.Extension == ".png" || fi.Extension == ".bmp" || fi.Extension == ".JPG" ||
                        fi.Extension == ".JPEG" || fi.Extension == ".PNG" || fi.Extension == ".BMP")
                    {
                        testImagePathList.Add(file);
                    }
                }

                if (testImagePathList.Count > 0)
                {
                    RunTool(0);
                }
                else
                {
                    MessageBox.Show(@"文件夹内找不到图片！");
                }
            }
        }

        private void CleanImages()
        {
            testImagePathList.Clear();
            _imageSelectCount = 0;
        }

        private delegate void OnRefreshImageCount();

        private void RefreshImageCount()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new OnRefreshImageCount(RefreshImageCount));
                return;
            }
            lblImageCount.Text = "当前图像：（" + _imageSelectCount + "/" + testImagePathList.Count + "）";
            if (_imageSelectCount < testImagePathList.Count)
            {
                btnNextImage.Enabled = true;
                btnLastImage.Enabled = _imageSelectCount != 1;
            }else if (_imageSelectCount == testImagePathList.Count)
            {
                btnNextImage.Enabled = false;
                btnLastImage.Enabled = _imageSelectCount > 1;
            }
            else
            {
                btnNextImage.Enabled = false;
                btnLastImage.Enabled = false;
            }
            //add 20200806 by wangsizhe start
            if (btnLastImage.Text == "停止自动" && !btnLastImage.Enabled)
            {
                btnLastImage.Text = "上一张";
                btnInputImage.Enabled = true;
                btnInputImages.Enabled = true;
                pnlNextImage.Enabled = true;
                chkAutoRun.Checked = false;
                chkAutoRun.Enabled = true;
                nudAutoRunTime.Enabled = true;
            }
            if (btnNextImage.Text == "停止自动" && !btnNextImage.Enabled)
            {
                btnNextImage.Text = "下一张";
                btnInputImage.Enabled = true;
                btnInputImages.Enabled = true;
                pnlLastImage.Enabled = true;
                chkAutoRun.Checked = false;
                chkAutoRun.Enabled = true;
                nudAutoRunTime.Enabled = true;
            }
            //add 20200806 by wangsizhe end
        }

        private void btnLastImage_Click(object sender, System.EventArgs e)
        {
            if (testImagePathList.Count >= _imageSelectCount)
            {
                //mod 20200805 by wangsizhe start
                //_imageSelectCount = _imageSelectCount - 2;
                //RunTool(_imageSelectCount);
                if (btnLastImage.Text == "停止自动")
                {
                    btnLastImage.Text = "上一张";
                    btnInputImage.Enabled = true;
                    btnInputImages.Enabled = true;
                    pnlNextImage.Enabled = true;
                    chkAutoRun.Checked = false;
                    chkAutoRun.Enabled = true;
                    nudAutoRunTime.Enabled = true;
                    return;
                }
                else if (chkAutoRun.Checked)
                {
                    btnLastImage.Text = "停止自动";
                    btnInputImage.Enabled = false;
                    btnInputImages.Enabled = false;
                    pnlNextImage.Enabled = false;
                    chkAutoRun.Enabled = false;
                    nudAutoRunTime.Enabled = false;
                }
                 Task t = new Task(() => {
                 do
                 {
                     if (_imageSelectCount < 2)
                         break;
                     _imageSelectCount = _imageSelectCount - 2;
                     RunTool(_imageSelectCount);
                     Thread.Sleep((int)nudAutoRunTime.Value);
                 } while (chkAutoRun.Checked && testImagePathList.Count >= _imageSelectCount);
                 });
                 t.Start();
                //mod 20200805 by wangsizhe end
            }
        }

        private void btnNextImage_Click(object sender, System.EventArgs e)
        {
            if (testImagePathList.Count >= _imageSelectCount)
            {
                //mod 20200805 by wangsizhe start
                //RunTool(_imageSelectCount);
                if(btnNextImage.Text == "停止自动")
                {
                    btnNextImage.Text = "下一张";
                    btnInputImage.Enabled = true;
                    btnInputImages.Enabled = true;
                    pnlLastImage.Enabled = true;
                    chkAutoRun.Checked = false;
                    chkAutoRun.Enabled = true;
                    nudAutoRunTime.Enabled = true;
                    return;
                }
                else if (chkAutoRun.Checked)
                {
                    btnNextImage.Text = "停止自动";
                    btnInputImage.Enabled = false;
                    btnInputImages.Enabled = false;
                    pnlLastImage.Enabled = false;
                    chkAutoRun.Enabled = false;
                    nudAutoRunTime.Enabled = false;
                }
                Task t = new Task(() => {
                    do
                    {
                        if (_imageSelectCount == testImagePathList.Count)
                            break;
                        RunTool(_imageSelectCount);
                         Thread.Sleep((int)nudAutoRunTime.Value);
                       
                    } while (chkAutoRun.Checked && testImagePathList.Count >= _imageSelectCount);
                });
                t.Start();
               
                //mod 20200805 by wangsizhe end
            }
        }

       
    }
}
