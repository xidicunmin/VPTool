using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.ToolBlock;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace VPTool
{
    public class Member
    {
        public class PointCoord
        {
            public double X;
            public double Y;
            public double A;
        }
        public class VisionImage
        {
            public Bitmap BmpImage
            {
                set
                {
                    CogImage = new CogImage8Grey(value);
                }
                get
                {
                    return CogImage.ToBitmap();
                }
            }

            public CogImage8Grey CogImage;

            public ICogRecord CogRecord;

        }

        public class VisionDisplayResult
        {
            public bool Status;
            public string Value;
            public float FontSize = 10;
        }

        internal class VisionTool
        {
            public string ToolName;

            public string cogCalibCheckerboardToolPath;

            public string cogCalibNPointToNPointToolPath;

            public string ProcessToolPath;

            public CogCalibCheckerboardTool cogCalibCheckerboardTool;

            public CogCalibNPointToNPointTool cogCalibNPointToNPointTool;

            public CogToolBlock ProcessTool;
        }

        public class VisionToolParameter
        {
            public Type ValueType;

            public Object Value;

            public string Name;
        }

        public enum DisplayControlEventType
        {
            OpenLiveMode,
            CloseLiveMode,
            InputImageTest,
            EditVisionTool,
            TriggerOnceTest,
            TriggerContinuousTest,
            CloseTriggerTest,
            EditStationName,
            EditCamera,
        }
    }
}
