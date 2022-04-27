using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Collections;
namespace Evo
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EMessageStruct
    {

        public int result;
        public IntPtr parameter;
        public int parameterSize;
        public UInt32 lenghtData;
        public IntPtr parameterData;
    }

    public enum SServicePlugin : int
    {
        ssOnSms = 0,
        ssOnFingerprint = 1,
        ssOnSay = 2,
        ssOnInitContact = 3,
        ssOnShareFile = 4,
    }
}