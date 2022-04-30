using System;
using UnityEngine;
namespace Evo
{
    public class IuType
    {

        /// <summary>
        /// 
        /// </summary>
        public static bool isEObjectI(System.Object obj)
        {
            return UType.getInstance().isEObject(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isArray(System.Object obj)
        {
            return UType.getInstance().isArray(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isHashtable(System.Object obj)
        {
            return obj.GetType().Equals(typeof(System.Collections.Hashtable));
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isSortedDictionary(System.Object obj)
        {
            return obj.GetType().Equals(typeof(System.Collections.Generic.SortedDictionary<string, System.Object>));
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isMap(System.Object obj)
        {
            return obj.GetType().Equals(typeof(Map));
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isArrayByte(System.Object obj)
        {
            return obj.GetType().Equals(typeof(byte[]));
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isTexture(System.Object obj)
        {
            return obj.GetType().Equals(typeof(Texture));
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isTexture2D(System.Object obj)
        {
            return obj.GetType().Equals(typeof(Texture2D));
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool isTexture3D(System.Object obj)
        {
            return obj.GetType().Equals(typeof(Texture3D));
        }
    }
}