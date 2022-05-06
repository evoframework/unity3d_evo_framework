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