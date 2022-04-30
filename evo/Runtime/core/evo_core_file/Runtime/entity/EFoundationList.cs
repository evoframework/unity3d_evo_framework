using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Evo
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct EFoundationList : IEObject
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

        public Dictionary<System.Int64, System.Int64> mapList;
        public Dictionary<System.Int64, EObject> mapMediatorEObject;
    }
}