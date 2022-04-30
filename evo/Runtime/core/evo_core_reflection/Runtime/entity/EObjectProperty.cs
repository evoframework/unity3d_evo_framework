using UnityEngine;
using System.Collections;
using System;
namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public enum EnumVisibilty
    {
        VISIBILITY_PUBLIC,
        VISIBILITY_PROTECTED,
        VISIBILITY_PRIVATE,
        VISIBILITY_STATIC_PUBLIC,
        VISIBILITY_STATIC_PROTECTED,
        VISIBILITY_STATIC_PRIVATE
    }

    /// <summary>
    /// 
    /// </summary>
    public class EObjectIProperty : IEObject
    {
        public string iD { get; set; }

        public long time { get; set; }

        public string name;

        public EnumVisibilty visibility;

        public Type type;
        public string typeName;

        public int gType;

        public System.Object value;

        public GObject gObjectLink;

    }
}