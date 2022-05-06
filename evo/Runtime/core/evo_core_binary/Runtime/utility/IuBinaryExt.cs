// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************

using System.IO;

namespace Evo
{
    public static class IuBinaryExt
    {
        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, int _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static int DoReadInt(this Evo.IBinary source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadInt(_stream);
        }


        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, char _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static char DoReadChar(this Evo.IBinary source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadChar(_stream);
        }


        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, bool _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool DoReadBool(this Evo.IBinary source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadBoolean(_stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, double _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static double DoReadDouble(this Evo.IBinary _source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadDouble(_stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, float _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static float DoReadFloat(this Evo.IBinary _source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadFloat(_stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, string _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string DoReadString(this Evo.IBinary source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadString(_stream);
        }
    
        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, byte[] _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }


        /// <summary>
        /// 
        /// </summary>
        public static byte[] DoReadByteArray(this Evo.IBinary source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadByteArray(_stream);
        }

    
        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, long _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static long DoReadLong(this Evo.IBinary source, System.IO.Stream _stream)
        {
            return UBinary.Instance().DoReadInt64(_stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, Map _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static Map DoReadMap<T>(this Evo.IBinary source, System.IO.Stream _stream) where T:EObject,new ()
        {
            return UBinary.Instance().DoReadMap<T>(_stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DoWrite(this Evo.IBinary source, EObject _value, Stream _stream)
        {
            UBinary.Instance().DoWrite(_value, _stream);
        }

        /// <summary>
        /// 
        /// </summary>
        public static EObject DoReadEObject<T>(this Evo.IBinary source, System.IO.Stream _stream) where T:EObject,new ()
        {
            return UBinary.Instance().DoReadEObject<T>(_stream);
        }
    }

}