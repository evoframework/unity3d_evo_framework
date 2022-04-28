using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Runtime.InteropServices;
using Unity.Collections.LowLevel.Unsafe;
using System.IO;
namespace Evo
{
    public static class IuBinary
    {

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source,Id value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, Time value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, byte[] value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, string value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, byte value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DoReadString(this Evo.IBinary source, System.IO.Stream stream)
        { 
            return UBinary.Instance().DoReadString( stream); 
        }

        /// <summary>
        /// 
        /// </summary>
        public static byte[] DoReadByteArray(this Evo.IBinary source, System.IO.Stream stream)
        {
            return UBinary.Instance().DoReadByteArray(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Id DoReadId(this Evo.IBinary source,  System.IO.Stream stream)
        {
            return UBinary.Instance().DoReadId( stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Time DoReadTime(this Evo.IBinary source, System.IO.Stream stream)
        {
            return UBinary.Instance().DoReadTime(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, int value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static int DoReadInt(this Evo.IBinary source, System.IO.Stream stream)
        {
            return UBinary.Instance().DoReadInt(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, Map value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Map DoReadMap<T>(this Evo.IBinary source, System.IO.Stream stream) where T:EObject,new ()
        {
            return UBinary.Instance().DoReadMap<T>(stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, EObject value, Stream stream)
        {
            UBinary.Instance().DoWrite(value, stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static EObject DoReadEObject<T>(this Evo.IBinary source, System.IO.Stream stream) where T:EObject,new ()
        {
            return UBinary.Instance().DoReadEObject<T>(stream);
        }
    }

}