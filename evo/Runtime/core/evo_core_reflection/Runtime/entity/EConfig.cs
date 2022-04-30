using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Evo
{
    public class EConfig : IEObject
    {

        public string iD { get; set; }

        public long time { get; set; }

        public string name;

        public Map mapConfig = new Map();
    }
}
