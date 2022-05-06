using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Threading.Tasks;
using System.Threading;
using Evo;
namespace EvoTest
{
    [System.Serializable]
    public class CObjectTest : CObject
    {
        public EvoEvent evoEvent;
        public EvoEvent evoEvent1;
        public EvoEvent evoEvent2;
        public EvoEvent evoEventN;

        /// <summary>
        /// 
        /// </summary>
        override public void OnDidEnable(System.Object obj)
        {
            this.DoVerbose("OnDidEnable", obj);
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDidStart(System.Object obj)
        {
            this.DoVerbose("OnDidStart", obj);
            var eObjectTest = new EObjectStructTest();
            eObjectTest.iD = "e1";
            eObjectTest.propertyString = "propertyStrVal";
            this.DoNotify(evoEvent, eObjectTest);
        }

        /// <summary>
        /// 
        /// </summary>
        override protected void OnMemoryWarning(System.Object obj)
        {
            this.DoVerbose("OnMemoryWarning", obj);
        }

        /// <summary>
        /// 
        /// </summary>
        override public void OnDidStop(System.Object obj)
        {
            this.DoVerbose("OnDidStop", obj);
            this.DoNotify(evoEvent1);
        }
    }
}