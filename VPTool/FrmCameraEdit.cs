using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Cognex.VisionPro;

namespace VPTool
{
    public partial class FrmCameraEdit : Form
    {
        public FrmCameraEdit()
        {
            InitializeComponent();
        }
        CogAcqFifoTool _cogAcq;
        bool _save;

        public CogAcqFifoTool ShowEdit(CogAcqFifoTool cogAcq, string titleText, out bool save) 
        {
            _save = false;
            if (cogAcq == null)
            {
                cogAcq = new CogAcqFifoTool();
            }
            Text = titleText;
            _cogAcq = cogAcq;
            cogAcqFifoEditV21.Subject = _cogAcq;
            ShowDialog();
            save = _save;
            return _cogAcq;
        }

        private void frmCameraEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _save = MessageBox.Show(@"是否保存相机参数", @"提示", MessageBoxButtons.YesNo) == DialogResult.Yes;

            Dispose();
            Close();
        }
    }
}
