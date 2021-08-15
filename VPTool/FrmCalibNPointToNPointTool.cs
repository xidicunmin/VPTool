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
    public partial class FrmCalibNPointToNPointTool : Form
    {
        public FrmCalibNPointToNPointTool()
        {
            InitializeComponent();
        }

        private CogCalibNPointToNPointTool _cogCalibNPointToNPointEdit;
        private CogCalibNPointToNPointTool _cogCalibNPointToNPointBackup;
        private string _toolKey;

        public delegate void OnCalibNPointToNPointToolSave(string toolBlockKey, CogCalibNPointToNPointTool editTool, CogCalibNPointToNPointTool backupTool, bool save);
        public event OnCalibNPointToNPointToolSave CalibNPointToNPointToolSave;

        public void ShowEdit(CogCalibNPointToNPointTool cogCalibNPointToNPointEdit, CogCalibNPointToNPointTool cogCalibNPointToNPointBackup, string toolKey, string titleText)
        {
            cogCalibNPointToNPointEditV21.Invoke(new Action(delegate
            {
                if (cogCalibNPointToNPointEdit == null)
                {
                    cogCalibNPointToNPointEdit = new CogCalibNPointToNPointTool();
                }

                Text = titleText;
                _cogCalibNPointToNPointBackup = cogCalibNPointToNPointBackup;
                _cogCalibNPointToNPointEdit = cogCalibNPointToNPointEdit;
                _toolKey = toolKey;
                cogCalibNPointToNPointEditV21.Subject = cogCalibNPointToNPointEdit;
                Show();
            }));
        }

        private void FrmCalibCheckerboardTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(@"是否保存工具", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (CalibNPointToNPointToolSave != null)
                {
                    CalibNPointToNPointToolSave(_toolKey, _cogCalibNPointToNPointEdit, _cogCalibNPointToNPointBackup, true);
                }
            }
            else
            {
                if (CalibNPointToNPointToolSave != null)
                {
                    CalibNPointToNPointToolSave(_toolKey, _cogCalibNPointToNPointEdit, _cogCalibNPointToNPointBackup, false);
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
                _cogCalibNPointToNPointEdit.InputImage = new CogImage8Grey(new Bitmap(ofg.FileName));
                _cogCalibNPointToNPointEdit.Run();
            }
        }
    }
}
