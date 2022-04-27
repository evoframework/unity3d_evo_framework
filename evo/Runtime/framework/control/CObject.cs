using System;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;
namespace Evo
{
    [System.Serializable]
    public abstract class CObject : EvoObject
    {
        /// <summary>
        /// OnDidStart
        /// </summary>
        override public void OnDidStart(System.Object obj)
        {
        }

        /// <summary>
        /// OnDidStop
        /// </summary>
        override public void OnDidStop(System.Object obj)
        {
        }

        /// <summary>
        /// OnMemoryWarning
        /// </summary>
        override protected  void OnMemoryWarning(System.Object obj)
        {      
        }
    }
}