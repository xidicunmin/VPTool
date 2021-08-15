using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro;

namespace VPTool
{
    public partial class FrmCalibCheckerboardTool : Form
    {
        public FrmCalibCheckerboardTool()
        {
            InitializeComponent();
        }

        private CogCalibCheckerboardTool _cogCalibCheckerboardEdit;
        private CogCalibCheckerboardTool _cogCalibCheckerboardBackup;
        private string _toolKey;

        public delegate void OnCalibCheckerboardToolSave(string toolBlockKey, CogCalibCheckerboardTool editTool, CogCalibCheckerboardTool backupTool, bool save);
        public event OnCalibCheckerboardToolSave CalibCheckerboardToolSave;

        public void ShowEdit(CogCalibCheckerboardTool cogCalibCheckerboardEdit, CogCalibCheckerboardTool cogCalibCheckerboardBackup, string toolKey, string titleText)
        {
            cogCalibCheckerboardEditV21.Invoke(new Action(delegate
            {
                if (cogCalibCheckerboardEdit == null)
                {
                    cogCalibCheckerboardEdit = new CogCalibCheckerboardTool();
                }

                Text = titleText;
                _cogCalibCheckerboardBackup = cogCalibCheckerboardBackup;
                _cogCalibCheckerboardEdit = cogCalibCheckerboardEdit;
                _toolKey = toolKey;
                cogCalibCheckerboardEditV21.Subject = _cogCalibCheckerboardEdit;
                Show();
            }));
        }

        private void FrmCalibCheckerboardTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(@"是否保存工具", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CalibCheckerboardToolSave != null)
                {
                    CalibCheckerboardToolSave(_toolKey, _cogCalibCheckerboardEdit, _cogCalibCheckerboardBackup, true);
                }
            }
            else
            {
                if (CalibCheckerboardToolSave != null)
                {
                    CalibCheckerboardToolSave(_toolKey, _cogCalibCheckerboardEdit, _cogCalibCheckerboardBackup, false);
                }
            }

            Dispose();
            Close();
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
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
                _cogCalibCheckerboardEdit.InputImage = new CogImage8Grey(new Bitmap(ofg.FileName));
                _cogCalibCheckerboardEdit.Run();
            }
        }
    }
}
