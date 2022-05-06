// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************

using System;
using UnityEngine;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class IuConvert : UObject
    {
        /// <summary>
        /// 
        /// </summary>
        public static byte[] FromHex(string hex)
        {
            try
            {
                if (hex.Length % 2 == 1)
                    throw new Exception("The binary key cannot have an odd number of digits");

                byte[] arr = new byte[hex.Length >> 1];

                for (int i = 0; i < hex.Length >> 1; ++i)
                {
                    arr[i] = (byte)((GetHexVal(hex[i << 1]) << 4) + (GetHexVal(hex[(i << 1) + 1])));
                }

                return arr;


            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static int GetHexVal(char hex)
        {
            int val = (int)hex;
            //For uppercase A-F letters:
            return val - (val < 58 ? 48 : 55);
            //For lowercase a-f letters:
            //return val - (val < 58 ? 48 : 87);
            //Or the two combined, but a bit slower:
            //return val - (val < 58 ? 48 : (val < 97 ? 55 : 87));
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToHex(byte[] arrayByte)
        {
            try
            {
                System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();


                foreach (byte b in arrayByte)

                {
                    try
                    {
                        string strX = b.ToString("X2");
                        stringBuilder.Append(strX);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                string strReturn = stringBuilder.ToString();



                return strReturn;


            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool toBool(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    if (obj.GetType().Name.Equals("bool"))
                    {
                        return (bool)obj;
                    }

                    if (obj.ToString().ToLower().Equals("true"))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return false;

        }

        /// <summary>
        /// 
        /// </summary>
        public static int toInt(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    return Convert.ToInt32(obj);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static float toFloat(System.Object obj)
        {
            try
            {
                if (obj != null)
                {

                    return Convert.ToSingle(obj);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static long toLong(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    return (long)Convert.ToDouble(obj);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static double toDouble(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    return Convert.ToDouble(obj);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string toString(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    return obj.ToString();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static GUISkin toGuiSkin(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    GUISkin guiSkin = new GUISkin();
                    return guiSkin;
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Rect toRect(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string strRect = obj.ToString().Replace("[", "").Replace("]", "");
                    strRect = strRect.Replace("Screen.width", Screen.width.ToString()).Replace("Screen.height", Screen.height.ToString());
                    Array arraLine = strRect.Split(',');

                    if (arraLine.Length == 4)
                    {
                        return new Rect(fromPercentWidth(arraLine.GetValue(0)), fromPercentHeight(arraLine.GetValue(1)), fromPercentWidth(arraLine.GetValue(2)), fromPercentHeight(arraLine.GetValue(3)));
                    }
                    else
                    {
                        //DoError("NotValidRect:" + obj);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return new Rect(0, 0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Resolution ToResolution(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    Resolution resolution = new Resolution();
                    string strRect = obj.ToString().Replace("[", "").Replace("]", "");
                    Array arrayLine = strRect.Split(',');

                    if (arrayLine.Length == 3)
                    {

                        resolution.height = IuConvert.toInt(arrayLine.GetValue(0));
                        resolution.refreshRate = IuConvert.toInt(arrayLine.GetValue(1));
                        resolution.width = IuConvert.toInt(arrayLine.GetValue(2));
                        return resolution;
                    }
                    else
                    {
                        //  DoError("NotValidRect:" + obj);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }

            return new Resolution(); ;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Rect toRectInverse(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string strRect = obj.ToString().Replace("[", "").Replace("]", "");
                    strRect = strRect.Replace("Screen.width", Screen.width.ToString()).Replace("Screen.height", Screen.height.ToString());
                    Array arraLine = strRect.Split(',');

                    if (arraLine.Length == 4)
                    {
                        return new Rect(fromPercentHeight(arraLine.GetValue(0)), fromPercentWidth(arraLine.GetValue(1)), fromPercentHeight(arraLine.GetValue(2)), fromPercentWidth(arraLine.GetValue(3)));
                    }
                    else
                    {
                        //  DoError("NotValidRect:" + obj);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return new Rect(0, 0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Rect ToRectCanvas(Canvas canvas, System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string strRect = obj.ToString().Replace("[", "").Replace("]", "");
                    RectTransform canvasRectTransform = canvas.gameObject.GetComponent<RectTransform>();
                    Vector2 vectorSize = canvasRectTransform.sizeDelta;
                    Array arraLine = strRect.Split(',');

                    if (arraLine.Length == 4)
                    {
                        return new Rect(FromPercent(arraLine.GetValue(0).ToString(), vectorSize.x), FromPercent(arraLine.GetValue(1).ToString(), vectorSize.y), FromPercent(arraLine.GetValue(2).ToString(), vectorSize.x), FromPercent(arraLine.GetValue(3).ToString(), vectorSize.y));
                    }
                    else
                    {
                        //  DoError("NotValidRect:" + obj);
                    }
                }

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return new Rect(0, 0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Rect toRectForceInverse(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string strRect = obj.ToString().Replace("[", "").Replace("]", "");
                    strRect = strRect.Replace("Screen.width", Screen.width.ToString()).Replace("Screen.height", Screen.height.ToString());
                    Array arraLine = strRect.Split(',');

                    if (arraLine.Length == 4)
                    {
                        return new Rect(fromPercentWidth(arraLine.GetValue(0)), fromPercentHeight(arraLine.GetValue(1)), fromPercentHeight(arraLine.GetValue(2)), fromPercentWidth(arraLine.GetValue(3)));
                    }
                    else
                    {
                        //  DoError("NotValidRect:" + obj);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return new Rect(0, 0, 0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Vector2 ToVector2(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string strRect = obj.ToString().Replace("[", "").Replace("]", "");
                    //strRect = strRect.Replace ("Screen.width", Screen.width.ToString ()).Replace ("Screen.height", Screen.height.ToString ());
                    Array arraLine = strRect.Split(',');

                    if (arraLine.Length == 2)
                    {
                        return new Vector2(toFloat(arraLine.GetValue(0)), toFloat(arraLine.GetValue(1)));
                    }
                    else
                    {
                        //  DoError("NotValidVector2:" + obj);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return Vector2.zero;
        }

        /// <summary>
        /// 
        /// </summary>
        public static Vector3 ToVector3(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string strRect = obj.ToString().Replace("[", "").Replace("]", "");
                    //strRect = strRect.Replace ("Screen.width", Screen.width.ToString ()).Replace ("Screen.height", Screen.height.ToString ());
                    Array arraLine = strRect.Split(',');

                    if (arraLine.Length == 3)
                    {
                        return new Vector3(toFloat(arraLine.GetValue(0)), toFloat(arraLine.GetValue(1)), toFloat(arraLine.GetValue(2)));
                    }
                    else
                    {
                        //   DoError("NotValidVector3:" + obj);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return Vector2.zero;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToDecimal(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string strReturn = Math.Round(toFloat(obj)).ToString();

                    return strReturn;

                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        public static float FromPercent(string str, float max)
        {
            try
            {
                if (str.Contains("%"))
                {
                    str = str.Replace("%", "");
                    return (max * (Convert.ToSingle(str) / 100));
                }
                return Convert.ToSingle(str);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static float fromPercentWidth(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string str = obj.ToString();
                    if (str.Contains("%"))
                    {
                        str = str.Replace("%", "");
                        return (Screen.width * (Convert.ToSingle(str) / 100));
                    }
                    return Convert.ToSingle(str);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static float fromPercentHeight(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    string str = obj.ToString();
                    if (str.Contains("%"))
                    {
                        str = str.Replace("%", "");
                        return (Screen.height * (Convert.ToSingle(str) / 100));
                    }
                    return Convert.ToSingle(str);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToBase64(byte[] arrayByte)
        {
            try
            {
                if (arrayByte != null)
                {

                    return Convert.ToBase64String(arrayByte);
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] FromBase64(string str)
        {
            try
            {

                return Convert.FromBase64String(str);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static DateTime ToDateTime(string time)
        {
            try
            {

                string[] arrayString = time.Split('_');

                if (arrayString.Length == 2)
                {

                    string[] arrayDate = arrayString[0].Split('-');
                    string[] arrayTime = arrayString[1].Split('-');

                    int year = toInt(arrayDate[0]);
                    int month = toInt(arrayDate[1]);
                    int day = toInt(arrayDate[2]);

                    int hour = toInt(arrayTime[0]);
                    int minute = toInt(arrayTime[1]);
                    int second = toInt(arrayTime[2]);
                    int tick = toInt(arrayTime[3]);

                    //DoError(year.ToString () + " " + month.ToString () + " " + day.ToString () + " " + hour.ToString () + " " + minute.ToString () + " " + second.ToString () + " " + tick.ToString ());	
                    DateTime dateTimeReturn = new DateTime(year, month, day, hour, minute, second);
                    //	DateTime dateTimeReturn = new DateTime(year, month, day, hour, minute, second, tick);				
                    return dateTimeReturn;
                }

            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return DateTime.UtcNow;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToElapsedTime(string timeStart, string timeEnd)
        {
            try
            {

                DateTime dateTimeStart = ToDateTime(timeStart);
                DateTime dateTimeEnd = ToDateTime(timeEnd);
                DateTime dateTimeEpoc = new DateTime(1970, 1, 1, 0, 0, 0);
                double milliseconds = (dateTimeEnd - dateTimeStart).TotalMilliseconds;

                TimeSpan timeSpan = TimeSpan.FromMilliseconds(milliseconds);

                return timeSpan.ToString();
                //IuLog.Error("timeElapsed:" + milliseconds.ToString());
                //DateTime dateTimeElapsed = new DateTime(milliseconds);


                /*	long timeStartLong = ToDateTime (timeStart).TotalMilliseconds;
                DoError("longStart:" + timeStartLong.ToString ());	

                long timeEndLong = ToDateTime (timeStart).ToFileTimeUtc ();
                DoError("longEnd:" + timeEndLong.ToString ());	


                long timeElapsed = timeEndLong - timeStartLong;
                DoError("longElapsed:" + timeElapsed.ToString ());	

                DateTime dateTime = new DateTime (timeElapsed);			*/
                //	return String.Format ("{0:yyyy-MM-dd_HH-mm-ss-ffff}", dateTimeElapsed); 
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] ToByteArray(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream();
                    bf.Serialize(ms, obj);
                    return ms.ToArray();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToUtf8String(byte[] arrayByte)
        {
            try
            {
                return System.Text.Encoding.UTF8.GetString(arrayByte);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] ToUtf8ArrayByte(string str)
        {
            try
            {
                return System.Text.Encoding.UTF8.GetBytes(str);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static System.Object FromByteArray(byte[] arrBytes)
        {
            try
            {
                MemoryStream memStream = new MemoryStream();
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                System.Object obj = (System.Object)binForm.Deserialize(memStream);
                return obj;
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

    }
}
