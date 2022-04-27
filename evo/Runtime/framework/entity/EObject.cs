using UnityEngine;
using System.Collections;
using System;

namespace Evo
{
    [System.Serializable]
    public class EObject : IEObject, IBinary
    {
        public EObject()
        {
        }

        #region IEvo

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

        private Evo.Id _iD;
        private Evo.Time _time;

        #endregion


        virtual public void ToStream(System.IO.Stream stream)
        {
            this.DoWrite(iD, stream);
            this.DoWrite(time, stream);
        }

        virtual public void FromStream(System.IO.Stream stream)
        {
            iD = this.DoReadId(stream);
            time = this.DoReadTime(stream);
        }

        public override string ToString()
        {
            return iD + "\n" + time;
        }

    }
}