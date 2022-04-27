using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Evo
{
    public static class IuMessage
    {
        /// <summary>
        /// 
        /// </summary>
        public static void DoNotify(this EvoObject source, EvoEvent evoEvent, System.Object obj = null)
        {
            try
            {
                source.DoLogNotify(evoEvent.ToString(), obj);
                evoEvent.Invoke(obj);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e, source);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Task DoNotifyAsync(this EvoObject source, EvoEvent evoEvent, System.Object obj)
        {
            try
            {
                evoEvent.Invoke(obj);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e, source);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoNotifyResponse(this EvoObject source, EvoCallback<IEObject> evoCallback, IEObject eObject)
        {
            try
            {
                evoCallback.Invoke(eObject);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e, source);
            }
        }

        /*
                public static void DoNotifyToDevice(this EvoObject source, System.Object obj)
                {
                    try
                    {

                        UMessage.Instance().OnNotifyToDevice(obj);
                        EMessage eMessage = (EMessage)obj;
                        if (eMessage.parameter != null)
                        {
                            //IuLog.DoLog(source, source.iD, ELog.TAG_NOTIFY_TO_DEVICE, eMessage.message, eMessage.parameter.ToString());
                        }
                        else
                        {
                            // IuLog.DoLog(source, source.iD, ELog.TAG_NOTIFY_TO_DEVICE, eMessage.message, "null");
                        }

                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e, source);
                    }
                }


                public static void DoNotifyToDevice(this EvoObject source, string message, System.Object parameter = null, string messageBack = null)
                {
                    try
                    {
                        if (source.IsValid(message))
                        {
                            UMessage.Instance().DoNotifyToDevice(message, parameter, messageBack);
                        }
                        else
                        {
                            source.DoError("ERROR NULL EMESSAGE");
                        }
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e, source);
                    }
                }
*/
    }
}