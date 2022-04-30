using UnityEngine;
using System.Collections;
namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public class EObjectIMethod : IEObject
    {

        public string iD { get; set; }

        public long time { get;set; }

        public string name;

        public string parameter;

        public EnumVisibilty visibility;

    }

}