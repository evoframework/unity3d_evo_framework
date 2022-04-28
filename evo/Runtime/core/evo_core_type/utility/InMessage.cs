using UnityEngine;
using System.Collections;
namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class InMessage
    {

        public string iD;

        public string name;

        [System.NonSerialized]
        public EvoCallback<System.Object> evoCallback;

        /// <summary>
        /// 
        /// </summary>
        public InMessage(string iD, string name, EvoCallback<System.Object> evoCallback)
        {
            if (evoCallback != null)
            {
                this.iD = iD;
                this.name = name;
                this.evoCallback = evoCallback;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return name;
        }
    }

}