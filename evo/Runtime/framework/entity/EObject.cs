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
        public string iD { get; set; }

        public long time { get; set; }
        #endregion

        #region IBinary    
        /// <summary>
        /// IBinary ToStream
        /// </summary>
        virtual public void ToStream(System.IO.Stream stream)
        {
            this.DoWrite(iD, stream);
            this.DoWrite(time, stream);
        }

        /// <summary>
        /// IBinary FromStream
        /// </summary>
        virtual public void FromStream(System.IO.Stream stream)
        {
            iD = this.DoReadString(stream);
            time = this.DoReadLong(stream);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return iD + "\n" + time;
        }
        
    }
}