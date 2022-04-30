using System;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct EMessage : IEObject
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

        public int status;
        public string url;
        public string message;
        [SerializeField]
        public System.Object parameter;
        public String parameterJson;
        public System.Object sender;
        public string to;
        public string messageBack;
        public System.Object parameterBack;
        //public bool isCrypt;
        [SerializeField]
        public IEObject eObjectParameter;
        public EvoCallback<System.Object> evoCallback;

    }
}