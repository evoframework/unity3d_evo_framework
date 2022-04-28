using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public unsafe struct ELog : IEObject
    {
        #region IEvo
        private Evo.Id _iD;

        private Evo.Time _time;

        /// <summary>
        /// Id
        /// </summary>
        public Evo.Id iD
        {
            get => _iD;
            set => _iD = value;
        }

        /// <summary>
        /// Time
        /// </summary>
        public Evo.Time time
        {
            get => _time;
            set => _time = value;
        }
        #endregion

        /*
            public EvoObject evoObject;

            public string idCaller;

            public string trace;

            public string tag;

            public long tick;

            public long tickOffset;

            public string message;

            public string messageBack;

            public string messageEvoCallBack;

            public System.Object parameter;
            public string traceStr;

            public bool isLocal;

            public UnityEngine.Object objectContext;

            public MapObject<string> mapTrace;

            public MapObject<string> mapStackTrace;

            public List<string> arrayTrace;
        */

    }
}