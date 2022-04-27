using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Net;
using System.Threading.Tasks;
namespace Evo
{
    public static class IuLog
    {
#if UNITY_EDITOR
        public static bool isUnityEditor = true;
#else
        public static bool isUnityEditor = false;
#endif

        public static int countLog = 0;


        public static bool isProduction = false;
        public static bool isVerbose = true;

        public static string logSeparator = "\n-----------------------------------------------------\n";

        public static string logParamterSeparator = "\n.....................................................\n";

        public static void DoVerbose(this IEvo source, System.Object obj, System.Object parameter = null)
        {
            try
            {
                if (!isProduction)
                {
                    if (isVerbose)
                    {
                        countLog += 1;
                        string tag = "VERBOSE";

                        string message = "";


                        if (obj != null)
                        {
                            message = obj.ToString();
                        }

                        string parameterStr = "";
                        if (parameter != null)
                        {
                            parameterStr = "(" + parameter.GetType().Name + ")" + "\n" + parameter.ToString();
                        }


                        if (isUnityEditor)
                        {
                            if (source != null)
                            {
                                if (source.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
                                {
                                    Debug.Log(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameterStr, (UnityEngine.Object)source);

                                }
                                else
                                {
                                    Debug.Log(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameterStr);
                                }
                            }
                        }
                        else
                        {
                            Debug.Log(logSeparator + countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + logParamterSeparator + parameter + logSeparator);
                        }
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static void DoLogNotify(this IEvo source, System.Object obj, System.Object parameter = null)
        {
            try
            {
                if (!isProduction)
                {
                    countLog += 1;
                    string tag = "NOTIFY";

                    string message = "";
                    if (obj != null)
                    {
                        message = obj.ToString();
                    }

                    if (isUnityEditor)
                    {
                        if (source != null)
                        {
                            if (source.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
                            {
                                Debug.Log(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter, (UnityEngine.Object)source);

                            }
                            else
                            {
                                Debug.Log(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter);
                            }
                        }
                    }
                    else
                    {
                        Debug.Log(logSeparator + countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + logParamterSeparator + parameter + logSeparator);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static void DoDebug(this IEvo source, System.Object obj, System.Object parameter = null)
        {
            try
            {
                if (!isProduction)
                {
                    countLog += 1;
                    string tag = "DEBUG";

                    string message = "";
                    if (obj != null)
                    {
                        message = obj.ToString();
                    }

                    if (isUnityEditor)
                    {
                        if (source != null)
                        {
                            if (source.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
                            {
                                Debug.Log(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter, (UnityEngine.Object)source);

                            }
                            else
                            {
                                Debug.Log(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter);
                            }
                        }
                    }
                    else
                    {
                        Debug.Log(logSeparator + countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + logParamterSeparator + parameter + logSeparator);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static void DoWarning(this IEvo source, System.Object obj, System.Object parameter = null)
        {
            try
            {
                if (!isProduction)
                {
                    countLog += 1;
                    string tag = "WARNING";

                    string message = "";
                    if (obj != null)
                    {
                        message = obj.ToString();
                    }

                    if (isUnityEditor)
                    {
                        if (source != null)
                        {
                            if (source.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
                            {
                                Debug.LogWarning(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter, (UnityEngine.Object)source);
                            }
                            else
                            {
                                Debug.LogWarning(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogWarning(logSeparator + countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + logParamterSeparator + parameter + logSeparator);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static void DoError(this IEvo source, System.Object obj, System.Object parameter = null)
        {

            try
            {
                if (!isProduction)
                {
                    countLog += 1;
                    string tag = "ERROR";

                    string message = "";
                    if (obj != null)
                    {
                        message = obj.ToString();
                    }

                    if (isUnityEditor)
                    {
                        if (source != null)
                        {
                            if (source.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
                            {
                                Debug.LogError(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter, (UnityEngine.Object)source);
                            }
                            else
                            {
                                Debug.LogError(countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + "\n" + parameter);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError(logSeparator + countLog.ToString() + " " + tag + " - " + source.iD + " - " + message + logParamterSeparator + parameter + logSeparator);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static void DoException(this IEvo source, Exception exception)
        {
            try
            {
                if (!isProduction)
                {
                    countLog += 1;
                   

                    if (isUnityEditor)
                    {
                        if (source != null)
                        {
                            if (source.GetType().IsSubclassOf(typeof(UnityEngine.Object)))
                            {
                                Debug.LogException(exception, (UnityEngine.Object)source);
                            }
                            else
                            {
                                Debug.LogException(exception);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogException(exception);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}