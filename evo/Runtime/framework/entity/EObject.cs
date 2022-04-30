using UnityEngine;
using System.Collections;
using System;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class EObject : IEObject, IBinary
    {
        public EObject()
        {
        }

        #region IEvo
      
        public string iD {  get ; set; }

        public long time { get; set; }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        virtual public void ToStream(System.IO.Stream stream)
        {
            this.DoWrite(iD, stream);
            this.DoWrite(time, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        virtual public void FromStream(System.IO.Stream stream)
        {
            iD = this.DoReadId(stream);
            time = this.DoReadTime(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return iD + "\n" + time;
        }

    }
}