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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        private string _iD;

        public string iD
        {
            get => _iD;
            set => _iD = value;
        }

        public long time { get; set; }
        #endregion

        public Int64 propertyInt;
        public long propertyLong;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string propertyStr;
        public bool propertyBool;
        public bool propertyDouble;

        public override string ToString()
        {
            return iD.ToString();

        }
    }
}