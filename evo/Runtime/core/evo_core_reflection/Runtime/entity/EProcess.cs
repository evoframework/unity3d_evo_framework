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
        public string iD { get; set; }
        public long time { get; set; }

        public Thread thread;
        public string fileName;
        public string arguments;
        public string workinDirectory;
        public DataReceivedEventHandler outputDataReceived;
        public DataReceivedEventHandler errorDataReceived;

    }
}
