using UnityEngine;
using System.Collections;
namespace Evo
{
    [System.Serializable]
    public class InMessage
    {

        public string iD;

        public string name;

        [System.NonSerialized]
        public EvoCallback<System.Object> evoCallback;

        public InMessage(string iD, string name, EvoCallback<System.Object> evoCallback)
        {
            if (evoCallback != null)
            {
                this.iD = iD;
                this.name = name;
                this.evoCallback = evoCallback;
            }

        }


        public override string ToString()
        {
            return name;
        }



    }

}