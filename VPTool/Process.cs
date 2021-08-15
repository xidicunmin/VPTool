using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.CalibFix;
using System.Threading.Tasks;

namespace VPTool
{
    public class Process
    {
        public Process()
        {
            string loadMsg = "";
            string visionToolDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\VisionTools";
            string cogCalibCheckerboardToolDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CalibCheckerboardTools";
            string cogCalibNPointToNPointToolDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\CalibNPointToNPointTools";
            if (!Directory.Exists(visionToolDirectory))
            {
                Directory.CreateDirectory(visionToolDirectory);
            }
            if (!Directory.Exists(cogCalibCheckerboardToolDirectory))
            {
                Directory.CreateDirectory(cogCalibCheckerboardToolDirectory);
            }
            if (!Directory.Exists(cogCalibNPointToNPointToolDirectory))
            {
                Directory.CreateDirectory(cogCalibNPointToNPointToolDirectory);
            }
            string[] visionToolPath = Directory.GetFiles(visionToolDirectory);
            foreach (var path in visionToolPath)
            {
                Member.VisionTool visionTool = new Member.VisionTool();
                visionTool.ToolName = Path.GetFileNameWithoutExtension(path);
                visionTool.ProcessToolPath = path;
                visionTool.cogCalibCheckerboardToolPath = cogCalibCheckerboardToolDirectory + "\\" + visionTool.ToolName + Path.GetExtension(path);
                visionTool.cogCalibNPointToNPointToolPath = cogCalibNPointToNPointToolDirectory + "\\" + visionTool.ToolName + Path.GetExtension(path);
                string msg = "";
                if (File.Exists(visionTool.ProcessToolPath))
                {
                    if (Path.GetExtension(visionTool.ProcessToolPath) == ".vpp")
                    {
                        visionTool.ProcessTool = commonTool.LoadCogToolBlockTool(visionTool.ProcessToolPath, ref msg);
                    }
                    else
                    {
                        visionTool.ProcessTool = (CogToolBlock)commonTool.Deserialize(visionTool.ProcessToolPath, out msg);
                    }
                    
                    loadMsg += msg;
                }
                if (File.Exists(visionTool.cogCalibCheckerboardToolPath))
                {
                    if (Path.GetExtension(visionTool.cogCalibCheckerboardToolPath) == ".vpp")
                    {
                        visionTool.cogCalibCheckerboardTool = commonTool.LoadCogCalibCheckerboardTool(visionTool.cogCalibCheckerboardToolPath, ref msg);
                    }
                    else
                    {
                        visionTool.cogCalibCheckerboardTool = (CogCalibCheckerboardTool)commonTool.Deserialize(visionTool.cogCalibCheckerboardToolPath, out msg);
                    }
                    loadMsg += msg;
                }
                if (File.Exists(visionTool.cogCalibNPointToNPointToolPath))
                {
                    if (Path.GetExtension(visionTool.cogCalibNPointToNPointToolPath) == ".vpp")
                    {
                        visionTool.cogCalibNPointToNPointTool = commonTool.LoadCogCalibNPointToNPointTool(visionTool.cogCalibNPointToNPointToolPath, ref msg);
                    }
                    else
                    {
                        visionTool.cogCalibNPointToNPointTool = (CogCalibNPointToNPointTool)commonTool.Deserialize(visionTool.cogCalibNPointToNPointToolPath, out msg);
                    }
                    
                    loadMsg += msg;
                }
                if (visionTool.ProcessTool != null && !visionTools.ContainsKey(visionTool.ToolName))
                {
                    visionTools.Add(visionTool.ToolName, visionTool);
                }
            }
        }

        private Common commonTool = new Common();

        private Dictionary<string, Member.VisionTool> visionTools = new Dictionary<string, Member.VisionTool>();

        public bool RunVisionTool(Member.VisionImage visionImage, string visionName, out Dictionary<string, Member.VisionToolParameter> outputs, out string msg, Dictionary<string, Member.VisionToolParameter> inputs = null)
        {
            bool status = false;
            outputs = new Dictionary<string, Member.VisionToolParameter>();
            msg = "";
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.ProcessTool != null)
                {
                    visionTool.ProcessTool.Inputs[0].Value = visionImage.CogImage;
                    if (inputs != null)
                    {
                        foreach (var input in inputs)
                        {
                            if (visionTool.ProcessTool.Inputs.Contains(input.Key))
                            {
                                visionTool.ProcessTool.Inputs[input.Key].Value = input.Value.Value;
                            }
                        }
                    }
                    visionTool.ProcessTool.Run();
                    visionImage.CogRecord = visionTool.ProcessTool.CreateLastRunRecord();
                    status = visionTool.ProcessTool.RunStatus.Result == CogToolResultConstants.Accept;
                    if (status)
                    {
                        for (int i = 0; i < visionTool.ProcessTool.Outputs.Count; i++)
                        {
                            Member.VisionToolParameter output = new Member.VisionToolParameter();
                            output.Name = visionTool.ProcessTool.Outputs[i].Name;
                            output.ValueType = visionTool.ProcessTool.Outputs[i].ValueType;
                            output.Value = visionTool.ProcessTool.Outputs[i].Value;
                            outputs.Add(output.Name,output);
                        }
                    }
                    else
                    {
                        msg = string.Format("{0}的视觉处理工具运行失败，请编辑工具", visionName);
                    }
                }
                else
                {
                    msg = string.Format("{0}的视觉处理工具未载入", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        public bool InitCalibCheckerboardTool(Member.VisionImage visionImage, string visionName, out string msg, out double rms)
        {
            bool status = false;
            msg = "";
            rms = 999;
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.cogCalibCheckerboardTool == null)
                {
                    visionTool.cogCalibCheckerboardTool = new Cognex.VisionPro.CalibFix.CogCalibCheckerboardTool();
                }
                visionTool.cogCalibCheckerboardTool.Calibration.CalibrationImage = visionImage.CogImage;
                visionTool.cogCalibCheckerboardTool.Calibration.Calibrate();
                status = visionTool.cogCalibCheckerboardTool.Calibration.Calibrated;
                if (status)
                {
                    commonTool.SaveVpp(visionTool.cogCalibCheckerboardTool, visionTool.cogCalibCheckerboardToolPath);
                }
                else
                {
                    msg = string.Format("{0}的视觉棋盘格工具初始化失败，请编辑工具并检查图像后重新初始化", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        public bool RunCalibCheckerboardTool(Member.VisionImage inputImage, string visionName, out string msg)
        {
            bool status = false;
            msg = "";
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.cogCalibCheckerboardTool != null)
                {
                    visionTool.cogCalibCheckerboardTool.InputImage = inputImage.CogImage;
                    visionTool.cogCalibCheckerboardTool.Run();
                    status = visionTool.cogCalibCheckerboardTool.RunStatus.Result == CogToolResultConstants.Accept;
                    if (status)
                    {
                        inputImage.CogImage = (CogImage8Grey)visionTool.cogCalibCheckerboardTool.OutputImage;
                    }
                    else
                    {
                        msg = string.Format("{0}的视觉棋盘格工具矫正图像失败，请编辑工具", visionName);
                    }
                }
                else
                {
                    msg = string.Format("{0}的视觉棋盘格工具未初始化", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        public bool InitNPointToNPointTool(Member.VisionImage visionImage, string visionName, List<Member.PointCoord> unCalibratedPoints, List<Member.PointCoord> rawCalibrationPoints, out string msg, out double rms)
        {
            bool status = false;
            msg = "";
            rms = 999;
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.cogCalibNPointToNPointTool == null)
                {
                    visionTool.cogCalibNPointToNPointTool = new Cognex.VisionPro.CalibFix.CogCalibNPointToNPointTool();
                }
                if (unCalibratedPoints.Count == rawCalibrationPoints.Count)
                {
                    visionTool.cogCalibNPointToNPointTool.CalibrationImage = visionImage.CogImage;
                    visionTool.cogCalibNPointToNPointTool.Calibration.NumPoints = 0;
                    for (int i = 0; i < unCalibratedPoints.Count; i++)
                    {
                        visionTool.cogCalibNPointToNPointTool.Calibration.AddPointPair(unCalibratedPoints[i].X, unCalibratedPoints[i].Y, rawCalibrationPoints[i].X, rawCalibrationPoints[i].Y);
                    }
                    visionTool.cogCalibNPointToNPointTool.Calibration.Calibrate();
                    status = visionTool.cogCalibNPointToNPointTool.Calibration.Calibrated;
                    if (status)
                    {
                        commonTool.SaveVpp(visionTool.cogCalibNPointToNPointTool, visionTool.cogCalibNPointToNPointToolPath);
                    }
                    else
                    {
                        msg = string.Format("{0}的视觉坐标转换工具初始化失败，请编辑工具并检查点位后重新初始化", visionName);
                    }
                }
                else
                {
                    msg = string.Format("{0}的视觉坐标转换工具校准点位不匹配", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        public bool RunNPointToNPointTool(Member.VisionImage inputImage, string visionName, out string msg)
        {
            bool status = false;
            msg = "";
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.cogCalibNPointToNPointTool != null)
                {
                    visionTool.cogCalibNPointToNPointTool.InputImage = inputImage.CogImage;
                    visionTool.cogCalibNPointToNPointTool.Run();
                    status = visionTool.cogCalibNPointToNPointTool.RunStatus.Result == CogToolResultConstants.Accept;
                    if (status)
                    {
                        inputImage.CogImage = (CogImage8Grey)visionTool.cogCalibNPointToNPointTool.OutputImage;
                    }
                    else
                    {
                        msg = string.Format("{0}的视觉坐标转换工具转换图像失败，请编辑工具", visionName);
                    }
                }
                else
                {
                    msg = string.Format("{0}的视觉坐标转换工具未初始化", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        public bool EditVisionTool(string visionName, string title, out string msg)
        {
            bool status = false;
            msg = "";
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.ProcessTool != null)
                {
                    status = true;
                    FrmToolBlock frmToolBlock = new FrmToolBlock();
                    Task.Factory.StartNew(() => {
                        CogToolBlock editTool = (CogToolBlock)commonTool.CopyTool(visionTool.ProcessTool);
                        //导入原工具图片
                        editTool.Inputs[0].Value = visionTool.ProcessTool.Inputs[0].Value;
                        CogToolBlock backupTool = (CogToolBlock)commonTool.CopyTool(editTool);
                        frmToolBlock.ShowEdit(visionTool.cogCalibCheckerboardTool, visionTool.cogCalibNPointToNPointTool, editTool, backupTool, visionName, title);
                        frmToolBlock.ToolBlockSave += new FrmToolBlock.OnToolBlockSave(frmToolBlock_ToolBlockSave);
                    });
                }
                else
                {
                    msg = string.Format("{0}的视觉处理工具未载入", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        void frmToolBlock_ToolBlockSave(string toolBlockKey, CogToolBlock editTool, CogToolBlock backupTool, bool save)
        {
            if (save)
            {
                visionTools[toolBlockKey].ProcessTool = editTool;
                if (Path.GetExtension(visionTools[toolBlockKey].ProcessToolPath) == ".vpp")
                {
                    commonTool.SaveVpp(visionTools[toolBlockKey].ProcessTool, visionTools[toolBlockKey].ProcessToolPath);
                }
                else
                {
                    string msg;
                    commonTool.Serialize(visionTools[toolBlockKey].ProcessTool, visionTools[toolBlockKey].ProcessToolPath, out msg);
                }
            }
            else
            {
                visionTools[toolBlockKey].ProcessTool = backupTool;
            }
        }

        public bool EditCalibCheckerboardTool(string visionName, string title, out string msg)
        {
            bool status = false;
            msg = "";
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.cogCalibCheckerboardTool != null)
                {
                    status = true;
                    FrmCalibCheckerboardTool frmCalibCheckerboardTool = new FrmCalibCheckerboardTool();
                    Task.Factory.StartNew(() => {
                        CogCalibCheckerboardTool editTool = (CogCalibCheckerboardTool)commonTool.CopyTool(visionTool.cogCalibCheckerboardTool);
                        editTool.InputImage = visionTool.cogCalibCheckerboardTool.InputImage;
                        CogCalibCheckerboardTool backupTool = (CogCalibCheckerboardTool)commonTool.CopyTool(editTool);
                        frmCalibCheckerboardTool.ShowEdit(editTool, backupTool, visionName, title);
                        frmCalibCheckerboardTool.CalibCheckerboardToolSave += new FrmCalibCheckerboardTool.OnCalibCheckerboardToolSave(frmCalibCheckerboardTool_CalibCheckerboardToolSave);
                    });
                }
                else
                {
                    msg = string.Format("{0}的视觉棋盘格工具未初始化", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        void frmCalibCheckerboardTool_CalibCheckerboardToolSave(string toolBlockKey, CogCalibCheckerboardTool editTool, CogCalibCheckerboardTool backupTool, bool save)
        {
            if (save)
            {
                visionTools[toolBlockKey].cogCalibCheckerboardTool = editTool;
                if (Path.GetExtension(visionTools[toolBlockKey].cogCalibCheckerboardToolPath) == ".vpp")
                {
                    commonTool.SaveVpp(visionTools[toolBlockKey].cogCalibCheckerboardTool, visionTools[toolBlockKey].cogCalibCheckerboardToolPath);
                }
                else
                {
                    string msg;
                    commonTool.Serialize(visionTools[toolBlockKey].cogCalibCheckerboardTool, visionTools[toolBlockKey].cogCalibCheckerboardToolPath, out msg);
                }
            }
            else
            {
                visionTools[toolBlockKey].cogCalibCheckerboardTool = backupTool;
            }
        }

        public bool EditNPointToNPointTool(string visionName, string title, out string msg)
        {
            bool status = false;
            msg = "";
            if (visionTools.ContainsKey(visionName))
            {
                Member.VisionTool visionTool = visionTools[visionName];
                if (visionTool.cogCalibNPointToNPointTool != null)
                {
                    status = true;
                    FrmCalibNPointToNPointTool frmCalibNPointToNPointTool = new FrmCalibNPointToNPointTool();
                    Task.Factory.StartNew(() => {
                        CogCalibNPointToNPointTool editTool = (CogCalibNPointToNPointTool)commonTool.CopyTool(visionTool.cogCalibNPointToNPointTool);
                        editTool.InputImage = visionTool.cogCalibNPointToNPointTool.InputImage;
                        CogCalibNPointToNPointTool backupTool = (CogCalibNPointToNPointTool)commonTool.CopyTool(editTool);
                        frmCalibNPointToNPointTool.ShowEdit(editTool, backupTool, visionName, title);
                        frmCalibNPointToNPointTool.CalibNPointToNPointToolSave += new FrmCalibNPointToNPointTool.OnCalibNPointToNPointToolSave(frmCalibNPointToNPointTool_CalibNPointToNPointToolSave);
                    });
                }
                else
                {
                    msg = string.Format("{0}的视觉坐标转换工具未初始化", visionName);
                }
            }
            else
            {
                msg = string.Format("未找到名称为{0}的视觉工具", visionName);
            }
            return status;
        }

        void frmCalibNPointToNPointTool_CalibNPointToNPointToolSave(string toolBlockKey, CogCalibNPointToNPointTool editTool, CogCalibNPointToNPointTool backupTool, bool save)
        {
            if (save)
            {
                visionTools[toolBlockKey].cogCalibNPointToNPointTool = editTool;
                if(Path.GetExtension(visionTools[toolBlockKey].cogCalibNPointToNPointToolPath) == ".vpp")
                {
                    commonTool.SaveVpp(visionTools[toolBlockKey].cogCalibNPointToNPointTool, visionTools[toolBlockKey].cogCalibNPointToNPointToolPath);
                }
                else
                {
                    string msg;
                    commonTool.Serialize(visionTools[toolBlockKey].cogCalibNPointToNPointTool, visionTools[toolBlockKey].cogCalibNPointToNPointToolPath, out msg);
                }
            }
            else
            {
                visionTools[toolBlockKey].cogCalibNPointToNPointTool = backupTool;
            }
        }

        public void FoundRotationCenterCrood(List<Member.PointCoord> rotationPointList, List<Member.PointCoord> realAngleList, double centerRange, out bool status,
           out double centerX, out double centerY, out string msg)
        {
            msg = string.Empty;
            centerX = 0;
            centerY = 0;
            status = false;
            if (rotationPointList.Count > 2)
            {
                var centersX = new List<double>();
                var centersY = new List<double>();
                bool reverseA;
                var realDifferenceA = realAngleList[realAngleList.Count - 1].A - realAngleList[0].A;
                var rotationDifferenceA = rotationPointList[rotationPointList.Count - 1].A - rotationPointList[0].A;
                reverseA = (realDifferenceA < 0 && rotationDifferenceA > 0) ||
                            (realDifferenceA > 0 && rotationDifferenceA < 0);
                if (Math.Abs(Math.Abs(realDifferenceA) - Math.Abs(rotationDifferenceA)) <= 0.5)
                {
                    if (rotationPointList.Count == realAngleList.Count)
                    {
                        for (int i = 0; i < realAngleList.Count; i++)
                        {
                            var rawAngle = realAngleList[i].A;
                            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "旋转点位坐标" + (i + 1) + "真实角度：" + rawAngle + "，视觉角度：" + rotationPointList[i].A + "\r\n");
                            if (reverseA)
                            {
                                realAngleList[i].A = rawAngle * -1;
                                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "旋转点位坐标" + (i + 1) + "真实角度：" + rawAngle + "修改为" + realAngleList[i].A + "\r\n");
                            }
                        }
                        for (var i = 0; i < rotationPointList.Count; i++)
                        {

                            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "旋转点位坐标" + (i + 1) + "X：" + rotationPointList[i].X + "，Y：" + rotationPointList[i].Y + "\r\n");

                            if (i <= 0) continue;
                            var cA = realAngleList[i].A - realAngleList[i - 1].A;

                            var cX = (rotationPointList[i].X + rotationPointList[i - 1].X) / 2 -
                                     ((rotationPointList[i].Y - rotationPointList[i - 1].Y) *
                                      Math.Sin(cA / 180 * Math.PI)) / (2 * (1 - Math.Cos(cA / 180 * Math.PI)));

                            var cY = (rotationPointList[i].Y + rotationPointList[i - 1].Y) / 2 +
                                     ((rotationPointList[i].X - rotationPointList[i - 1].X) *
                                      Math.Sin(cA / 180 * Math.PI)) / (2 * (1 - Math.Cos(cA / 180 * Math.PI)));

                            centersX.Add(cX);
                            centersY.Add(cY);

                            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "算法一圆心坐标" + (i + 1) + "坐标x：" + cX + "坐标y：" + cY + "\r\n");
                        }

                        if (centersX.Max() - centersX.Min() < centerRange && centersY.Max() - centersY.Min() < centerRange)
                        {
                            status = true;
                            centerX = centersX.Average();
                            centerY = centersY.Average();
                            for (double i = centerX - 50; i < centerX + 50; i += 0.5)
                            {
                                List<double> rangeY = new List<double>();
                                double modelY = rotationPointList[0].Y;
                                for (int j = 1; j < rotationPointList.Count; j++)
                                {
                                    double rotationX;
                                    double rotationY;
                                    PointRotationClockWise(i, centerY, rotationPointList[j].X, rotationPointList[j].Y, realAngleList[j].A - realAngleList[0].A, out rotationX, out rotationY);
                                    rangeY.Add(Math.Abs(rotationY - modelY));
                                }
                                if (Math.Abs(rangeY.Max() - rangeY.Min()) < 0.01)
                                {
                                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                string.Format("{0}Y方向偏移最大值为{1}最小值为{2}\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"), rangeY.Max(), rangeY.Min()));
                                    centerX = i;
                                    break;
                                }
                            }
                            for (double i = centerY - 50; i < centerY + 50; i += 0.5)
                            {
                                List<double> rangeX = new List<double>();
                                double modelY = rotationPointList[0].Y;
                                for (int j = 1; j < rotationPointList.Count; j++)
                                {
                                    double rotationX;
                                    double rotationY;
                                    PointRotationClockWise(centerX, i, rotationPointList[j].X, rotationPointList[j].Y, realAngleList[j].A - realAngleList[0].A, out rotationX, out rotationY);
                                    rangeX.Add(Math.Abs(rotationY - modelY));
                                }
                                if(Math.Abs(rangeX.Max() - rangeX.Min()) < 0.01)
                                {
                                    File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                string.Format("{0}X方向偏移最大值为{1}最小值为{2}\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"), rangeX.Max(), rangeX.Min()));
                                    centerY = i;
                                    break;
                                }
                            }

                            msg += "算法一寻找旋转中心成功\r\n";
                        }
                        else
                        {
                            File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "算法一圆心坐标极差超过" + centerRange + "，使用算法二\r\n");
                            msg += "算法一寻找旋转中心失败，使用算法二\r\n";
                            centersX.Clear();
                            centersY.Clear();
                            for (var i = 0; i < rotationPointList.Count; i++)
                            {
                                if (i <= 0) continue;
                                var cA = realAngleList[i].A - realAngleList[i - 1].A;

                                var cX = (rotationPointList[i].X + rotationPointList[i - 1].X) / 2 +
                                         ((rotationPointList[i].Y - rotationPointList[i - 1].Y) *
                                          Math.Sin(cA / 180 * Math.PI)) / (2 * (1 - Math.Cos(cA / 180 * Math.PI)));

                                var cY = (rotationPointList[i].Y + rotationPointList[i - 1].Y) / 2 -
                                         ((rotationPointList[i].X - rotationPointList[i - 1].X) *
                                          Math.Sin(cA / 180 * Math.PI)) / (2 * (1 - Math.Cos(cA / 180 * Math.PI)));

                                centersX.Add(cX);
                                centersY.Add(cY);
                                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "算法二圆心坐标" + (i + 1) + "坐标x：" + cX + "坐标y：" + cY + "\r\n");

                            }

                            if (centersX.Max() - centersX.Min() < centerRange && centersY.Max() - centersY.Min() < centerRange)
                            {

                                status = true;
                                centerX = centersX.Average();
                                centerY = centersY.Average();

                                for (double i = centerX - 50; i < centerX + 50; i += 0.5)
                                {
                                    List<double> rangeY = new List<double>();
                                    double modelX = rotationPointList[0].X;
                                    double modelY = rotationPointList[0].Y;
                                    for (int j = 1; j < rotationPointList.Count; j++)
                                    {
                                        double rotationX;
                                        double rotationY;
                                        PointRotationAntiClockWise(i, centerY, rotationPointList[j].X, rotationPointList[j].Y, realAngleList[j].A - realAngleList[0].A, out rotationX, out rotationY);
                                        rangeY.Add(Math.Abs(rotationY - modelY));
                                    }
                                    if (Math.Abs(rangeY.Max() - rangeY.Min()) < 0.01)
                                    {
                                        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                string.Format("{0}Y方向偏移最大值为{1}最小值为{2}\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"), rangeY.Max(), rangeY.Min()));
                                        centerX = i;
                                        break;
                                    }
                                }
                                for (double i = centerY - 50; i < centerY + 50; i += 0.5)
                                {
                                    List<double> rangeX = new List<double>();
                                    double modelX = rotationPointList[0].X;
                                    double modelY = rotationPointList[0].Y;
                                    for (int j = 1; j < rotationPointList.Count; j++)
                                    {
                                        double rotationX;
                                        double rotationY;
                                        PointRotationAntiClockWise(centerX, i, rotationPointList[j].X, rotationPointList[j].Y, realAngleList[j].A - realAngleList[0].A, out rotationX, out rotationY);
                                        rangeX.Add(Math.Abs(rotationY - modelY));
                                    }
                                    if (Math.Abs(rangeX.Max() - rangeX.Min()) < 0.01)
                                    {
                                        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                string.Format("{0}X方向偏移最大值为{1}最小值为{2}\r\n", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff"), rangeX.Max(), rangeX.Min()));
                                        centerY = i;
                                        break;
                                    }
                                }

                                msg += "算法二寻找旋转中心成功\r\n";
                            }
                            else
                            {
                                status = false;
                                msg += "算法二寻找旋转中心失败，请到" + AppDomain.CurrentDomain.BaseDirectory + "确认寻找圆心结果\r\n";
                                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "\\旋转中心算法.txt",
                                    DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff") + "算法二圆心坐标极差超过" + centerRange + "，判定失败\r\n");
                            }
                        }
                    }
                    else
                    {
                        msg += "旋转点数量和真实角度数量不匹配\r\n";
                    }
                }
                else
                {
                    msg += "旋转角度差值和真实角度差值超过0.5\r\n";
                }
            }
            else
            {
                msg += "旋转点数小于三点，无法进行计算旋转中心\r\n";
            }
        }

        public void PointRotationClockWise(double rotationCenterX, double rotationCenterY, double pointX, double pointY, double rotationAngle, out double outputX, out double outputY)
        {
            outputX = (pointX - rotationCenterX) * Math.Cos(rotationAngle * Math.PI / 180) + (pointY - rotationCenterY) * Math.Sin(rotationAngle * Math.PI / 180) + rotationCenterX;
            outputY = (pointY - rotationCenterY) * Math.Cos(rotationAngle * Math.PI / 180) - (pointX - rotationCenterX) * Math.Sin(rotationAngle * Math.PI / 180) + rotationCenterY;

        }

        public void PointRotationAntiClockWise(double rotationCenterX, double rotationCenterY, double pointX, double pointY, double rotationAngle, out double outputX, out double outputY)
        {
            outputX = (pointX - rotationCenterX) * Math.Cos(rotationAngle * Math.PI / 180) - (pointY - rotationCenterY) * Math.Sin(rotationAngle * Math.PI / 180) + rotationCenterX;
            outputY = (pointY - rotationCenterY) * Math.Cos(rotationAngle * Math.PI / 180) + (pointX - rotationCenterX) * Math.Sin(rotationAngle * Math.PI / 180) + rotationCenterY;

        }
    }
}
