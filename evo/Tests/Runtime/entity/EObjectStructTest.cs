using System.Runtime.InteropServices;
using Evo;
using System;

namespace EvoTest
{
    [System.Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct EObjectStructTest : IEObject
    {

        #region IEvo
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)]
        private string _iD;

        public string iD
        {
            get => _iD;
            set => _iD = value;
        }

        public long time { get; set; }
        #endregion

        public int propertyInt;
        public float propertyFloat;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)] //+\0
        public string propertyString;
       // public Map propertyMap;
        public long propertyLong;
        public char propertyChar;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        public byte[] propertyByteArray;
        public bool propertBool;
        public double propertyDouble;

        public override string ToString()
        {
            return iD.ToString();

        }
    }
}