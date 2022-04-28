using UnityEngine;
using System.Collections;
using System;
using System.Threading;
using System.Linq;
using System.Diagnostics;
using System.IO;
namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public class EProcess : IEObject
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


        public Thread thread;
        public string fileName;
        public string arguments;
        public string workinDirectory;
        public DataReceivedEventHandler outputDataReceived;
        public DataReceivedEventHandler errorDataReceived;


    }
}
