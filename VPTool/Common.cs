using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro.ToolBlock;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace VPTool
{
    public class Common
    {
        /// <summary>
        /// 加载CogToolBlock工具
        /// </summary>
        /// <param name="path"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public CogToolBlock LoadCogToolBlockTool(string path, ref string errMsg)
        {
            if (File.Exists(path))
            {
                try
                {
                    return (CogToolBlock)CogSerializer.LoadObjectFromFile(path,
                        new BinaryFormatter().GetType(), CogSerializationOptionsConstants.Minimum);
                }
                catch (Exception ex)
                {
                    errMsg = "加载VPP异常，异常信息：" + ex.Message;
                    return null;
                }
            }
            else
            {
                errMsg = "找不到VPP文件：" + path;
            }
            return null;
        }

        public CogCalibCheckerboardTool LoadCogCalibCheckerboardTool(string path, ref string errMsg)
        {
            if (File.Exists(path))
            {
                try
                {
                    return (CogCalibCheckerboardTool)CogSerializer.LoadObjectFromFile(path,
                        new BinaryFormatter().GetType(), CogSerializationOptionsConstants.Minimum);
                }
                catch (Exception ex)
                {
                    errMsg = "加载VPP异常，异常信息：" + ex.Message;
                    return null;
                }
            }
            else
            {
                errMsg = "找不到VPP文件：" + path;
            }
            return null;
        }

        public CogCalibNPointToNPointTool LoadCogCalibNPointToNPointTool(string path, ref string errMsg)
        {
            if (File.Exists(path))
            {
                try
                {
                    return (CogCalibNPointToNPointTool)CogSerializer.LoadObjectFromFile(path,
                        new BinaryFormatter().GetType(), CogSerializationOptionsConstants.Minimum);
                }
                catch (Exception ex)
                {
                    errMsg = "加载VPP异常，异常信息：" + ex.Message;
                    return null;
                }
            }
            else
            {
                errMsg = "找不到VPP文件：" + path;
            }
            return null;
        }

        /// <summary>
        /// 加载相机Vpp
        /// </summary>
        /// <param name="path"></param>
        /// <param name="ErrMsg"></param>
        public CogAcqFifoTool LoadVppAcq(string path, ref string ErrMsg)
        {
            if (File.Exists(path))
            {
                try
                {
                    CogAcqFifoTool camera = (CogAcqFifoTool)CogSerializer.LoadObjectFromFile(path);
                    camera.Operator.TimeoutEnabled = false;
                    camera.Operator.OwnedTriggerParams.TriggerEnabled = true;
                    camera.Operator.OwnedTriggerParams.TriggerModel = CogAcqTriggerModelConstants.Manual;
                    return camera;
                }
                catch (Exception ex)
                {
                    ErrMsg = "加载VPP异常，异常信息：" + ex.Message;
                    return null;
                }
            }
            else
            {
                ErrMsg = "找不到VPP文件：" + path;
            }
            return null;
        }


        public bool SaveVppAcq(CogAcqFifoTool acqTool, string path)
        {
            try
            {
                CogSerializer.SaveObjectToFile(acqTool, path, typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool SaveVpp(object tool, string path)
        {
            try
            {
                CogSerializer.SaveObjectToFile(tool, path, typeof(BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 从相机中获取图像
        /// </summary>
        /// <param name="camera"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public CogImage8Grey GetImage(CogAcqFifoTool camera, ref string errMsg)
        {
            if (camera != null)
            {
                CogImage8Grey image = null;
                try
                {
                    camera.Run();
                    if (camera.RunStatus.Result == CogToolResultConstants.Accept)
                    {
                        image = (CogImage8Grey)camera.OutputImage;
                    }
                    else
                    {
                        image = null;
                    }
                    //偶尔会有取像异常，需要二次取像
                    if (image == null)
                    {
                        camera.Run();
                        if (camera.RunStatus.Result == CogToolResultConstants.Accept)
                        {
                            image = (CogImage8Grey)camera.OutputImage;
                        }
                        else
                        {
                            errMsg = "相机二次取像都失败，无法获取图片";
                        }
                    }
                }
                catch (Exception ex)
                {
                    image = null;
                    errMsg = "相机取像出现异常，异常信息：" + ex.Message;
                }
                return image;
            }
            else
            {
                errMsg = "相机尚未初始化";
            }
            return null;
        }
        /// <summary>
        /// 复制一个Cognex工具
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object CopyTool(object obj)
        {
            return CogSerializer.DeepCopyObject(obj);
        }

        public bool Serialize(object obj,string path,out string errMsg)
        {
            bool status = false;
            errMsg = "";
            if (path!="")
            {
                try
                {
                    //FileStream fileStream = new FileStream(path, FileMode.Create);
                    //BinaryFormatter binaryFormatter = new BinaryFormatter();
                    //binaryFormatter.Serialize(fileStream, obj);
                    ////SoapFormatter soapFormatter = new SoapFormatter();
                    ////soapFormatter.Serialize(fileStream, obj);
                    ////XmlSerializer xmlSerializer = new XmlSerializer(typeof(object));
                    ////xmlSerializer.Serialize(fileStream, obj);
                    //fileStream.Close();
                    //status = true;

                    using (AesCryptoServiceProvider crypt = new AesCryptoServiceProvider())
                    {
                        crypt.Key = Encoding.ASCII.GetBytes("1995081619950816");
                        crypt.IV = Encoding.ASCII.GetBytes("1995081619950816");
                        using (ICryptoTransform transform = crypt.CreateEncryptor())
                        {
                            FileStream fs = new FileStream(path, FileMode.Create);
                            using (CryptoStream cs = new CryptoStream(fs, transform, CryptoStreamMode.Write))
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                formatter.Serialize(cs, obj);
                                status = true;
                                cs.Close();
                                fs.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    errMsg = "保存文件异常，异常信息：" + ex.Message;
                }
            }
            else
            {
                errMsg = "文件路径为空：" + path;
            }
            return status;
        }

        public object Deserialize(string path,out string errMsg)
        {
            object obj = null;
            errMsg = "";
            if (File.Exists(path))
            {
                try
                {
                    //FileStream fileStream = new FileStream(path, FileMode.Open);
                    //BinaryFormatter binaryFormatter = new BinaryFormatter();
                    //obj = binaryFormatter.Deserialize(fileStream);
                    ////SoapFormatter soapFormatter = new SoapFormatter();
                    ////obj = soapFormatter.Deserialize(fileStream);
                    ////XmlSerializer xmlSerializer = new XmlSerializer(typeof(object));
                    ////obj = xmlSerializer.Deserialize(fileStream);
                    //fileStream.Close();

                    using (AesCryptoServiceProvider crypt = new AesCryptoServiceProvider())
                    {
                        crypt.Key = Encoding.ASCII.GetBytes("1995081619950816");
                        crypt.IV = Encoding.ASCII.GetBytes("1995081619950816");
                        using (ICryptoTransform transform = crypt.CreateDecryptor())
                        {
                            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                            using (CryptoStream cs = new CryptoStream(fs, transform, CryptoStreamMode.Read))
                            {
                                BinaryFormatter formatter = new BinaryFormatter();
                                obj = formatter.Deserialize(cs);
                                cs.Close();
                                fs.Close();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    errMsg = "加载文件异常，异常信息：" + ex.Message;
                }
            }
            else
            {
                errMsg = "找不到文件：" + path;
            }
            return obj;
        }

        public object LoadCogTool(string path, out string errMsg)
        {
            errMsg = "";
            if (File.Exists(path))
            {
                try
                {
                    return CogSerializer.LoadObjectFromFile(path,
                        new BinaryFormatter().GetType(), CogSerializationOptionsConstants.Minimum);
                }
                catch (Exception ex)
                {
                    errMsg = "加载VPP异常，异常信息：" + ex.Message;
                    return null;
                }
            }
            else
            {
                errMsg = "找不到VPP文件：" + path;
            }
            return null;
        }
    }
}
