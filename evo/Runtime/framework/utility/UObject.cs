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

        public UObject()
        {
            iD = new Id(this.GetType().Name);
        }

    }
}
