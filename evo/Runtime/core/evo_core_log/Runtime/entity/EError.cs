// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************

using System.Runtime.InteropServices;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]   
    public unsafe struct EError : IEObject
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

        public string type;
        public bool isAutoClose; 
    }
}