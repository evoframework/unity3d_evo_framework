using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Evo
{
    [System.Serializable]
    public class UObject : IEvo
    {
        #region IEvo
        private string _iD;

        public string iD
        {
            get => _iD;
            set => _iD = value;
        }

        public long time { get; set; }
        #endregion

        public UObject()
        {
            iD = this.GetType().Name;
        }

    }
}
