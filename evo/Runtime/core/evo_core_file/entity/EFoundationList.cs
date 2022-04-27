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
        private Id _iD;
        private Time _time;

        /// <summary>
        /// Id
        /// </summary>
        public Id iD
        {
            get => _iD;
            set => _iD = value;
        }

        /// <summary>
        /// Time
        /// </summary>
        public Time time
        {
            get => _time;
            set => _time = value;
        }
        #endregion

        public Dictionary<System.Int64, System.Int64> mapList;
        public Dictionary<System.Int64, EObject> mapMediatorEObject;
    }
}