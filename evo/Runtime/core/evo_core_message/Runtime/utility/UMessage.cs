using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System;
using System.Security.Cryptography;
using System.Net;
using System.IO.Compression;

using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public class UMessage : UObject
    {
        protected static UMessage instance;

        /// <summary>
        /// 
        /// </summary>
        private UMessage()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public static UMessage Instance()
        {
            if (instance == null)
            {
                instance = new UMessage();
            }
            return instance;
        }
        /*
#if !UNITY_EDITOR || UNITY_IOS
        protected const string DLL_IMPORT = "__Internal";
#else
    protected const string DLL_IMPORT = "EvoFrameworkBundle";
#endif

        [DllImport(DLL_IMPORT, CharSet = CharSet.Ansi)]
        unsafe public static extern void OnNotifyToDevicePtr(int ssServicePlugin, IntPtr ptr);
        */
        /// <summary>
        /// 
        /// </summary>
        public void DoNotifyToDevice(SServicePlugin ssServicePlugin, EvoCallback<System.Object> evoCallBack, IEObject eObject)
        {
            try
            {
                this.DoWarning("DoNotifyToDevice:\n" + eObject.ToString());

                IntPtr intPtr = IntPtr.Zero;
                if (eObject != null)
                {
                    intPtr = IuSerialize.ToPtr(eObject);

                    this.DoWarning("intPtr2");
                }

                //  OnNotifyToDevicePtr((int)ssServicePlugin, intPtr);

            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }
        }
    }
}