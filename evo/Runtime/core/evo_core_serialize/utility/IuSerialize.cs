using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Evo
{
    public static class TypeExtensions
    {
        public static T GetInstance<T>() where T : new()
        {
            return new T();
        }
    }

    public static class New<T> where T : new()
    {
        public static readonly Func<T> Instance = Expression.Lambda<Func<T>>
            (
                                                      Expression.New(typeof(T))
                                                  ).Compile();
    }

    public static class IuSerialize
    {

        public static IntPtr ToPtr(IEObject eObject)
        {
            try
            {
                int size = Marshal.SizeOf(eObject);

                byte[] arr = new byte[size];
                IntPtr intPtr = Marshal.AllocHGlobal(size);

                Marshal.StructureToPtr(eObject, intPtr, false);
                return intPtr;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return IntPtr.Zero;
        }

        public static T FromPtr<T>(IntPtr param) where T : IEObject
        {
            try
            {
                var eObject = (IEObject)Marshal.PtrToStructure(param, typeof(T));

                return (T)eObject;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return default(T);

        }

        public static byte[] ToBytePtr(IEObject eObject)
        {
            try
            {

                int size = Marshal.SizeOf(eObject);
                byte[] arr = new byte[size];

                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(eObject, ptr, false);
                Marshal.Copy(ptr, arr, 0, size);
                Marshal.FreeHGlobal(ptr);
                return arr;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }

        public static T FromBytePtr<T>(byte[] arrayByte)
        {
            try
            {

                int size = arrayByte.Length;
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.Copy(arrayByte, 0, ptr, size);

                var eObject = (T)Marshal.PtrToStructure(ptr, typeof(T));
                Marshal.FreeHGlobal(ptr);
                return eObject;

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return default(T);
        }

        public static IEObject FromBytePtr(string className, byte[] arrayByte)
        {
            try
            {

                int size = arrayByte.Length;
                IntPtr ptr = Marshal.AllocHGlobal(size);
                Marshal.Copy(arrayByte, 0, ptr, size);
                var value = IuSerialize.Instantiate(className);
                var eObject = (IEObject)Marshal.PtrToStructure(ptr, value.GetType());
                Marshal.FreeHGlobal(ptr);
                return eObject;

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        public static Byte[] StructureToBuffer<T>(T structure)
        {
            Byte[] buffer = new Byte[Marshal.SizeOf(typeof(T))];

            unsafe
            {
                fixed (byte* pBuffer = buffer)
                {
                    Marshal.StructureToPtr(structure, new IntPtr((void*)pBuffer), true);
                }
            }

            return buffer;
        }

        public static Byte[] StructureToBuffer(IEObject eObject)
        {
            try
            {
                if (eObject != null) { }
                Byte[] buffer = new Byte[Marshal.SizeOf(eObject)];

                unsafe
                {
                    fixed (byte* pBuffer = buffer)
                    {
                        Marshal.StructureToPtr(eObject, new IntPtr((void*)pBuffer), true);
                    }
                }

                return buffer;

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;

        }

        public static T BufferToStructure<T>(Byte[] buffer, Int32 offset = 0)
        {
            unsafe
            {
                fixed (Byte* pBuffer = buffer)
                {
                    return (T)Marshal.PtrToStructure(new IntPtr((void*)&pBuffer[offset]), typeof(T));
                }
            }
        }


        public static string ToBase64(this IBinary source)
        {
            try
            {
                return IuConvert.ToBase64(ToArrayByte(source));
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }

        public static byte[] ToArrayByte(this IBinary source)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    source.ToStream(stream);
                    stream.Flush();
                    return stream.ToArray();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }



        public static byte[] ToArrayByteFull(this IBinary source)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    source.ToStream(stream);
                    stream.Flush();
                    return stream.ToArray();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }


        public static void FromBase64(this IBinary source, string base64)
        {
            try
            {
                var arrayByte = IuConvert.FromBase64(base64);
                source.FromArrayByte(arrayByte);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static void FromArrayByte(this IBinary source, byte[] arrayByte)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(arrayByte))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    source.FromStream(stream);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }


        public static void FromArrayByteFull(this IBinary source, byte[] arrayByte)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream(arrayByte))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    source.FromStream(stream);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static Dictionary<Type, IEObject> mapEObjectIClone = new Dictionary<Type, IEObject>();
        /* 
            public static void ToStream (EObject eObject, Stream stream)
            {

                try {

                    eObject.ToStream(stream);

                    foreach (EObject eObjectTmp in eObject.listEObject) {

                        if (eObjectTmp != null) {
                            UBinary.DoWrite (false, stream);
                            eObjectTmp.ToStream (stream);
                        } else {
                            UBinary.DoWrite (true, stream);
                        }



                    }

                    foreach (Map mapTmp in eObject.listMap) {
                        if (mapTmp != null) {
                            UBinary.DoWrite (false, stream);
                            mapTmp.ToStream (stream);
                        } else {
                            UBinary.DoWrite (true, stream);
                        }
                    }

                } catch (System.Exception e) {
                    Debug.LogException (e);
                }


            }

            public static void FromStream (EObject eObject, Stream stream)
            {

                try {

                    eObject.ToStream(stream);




                } catch (System.Exception e) {
                    Debug.LogException (e);
                }

            }


            /*
            public static T FromBinaryFull<T> (Stream stream) where T:EObject
            {

                try {
                    stream.Seek (0, SeekOrigin.Begin);
                    EObject eObject = Instantiate<T> ();

                    using (BinaryReader reader = new BinaryReader (stream, System.Text.Encoding.UTF8)) {
                        eObject.FromBinary (reader);
                    }

                    return (T)eObject;
                } catch (System.Exception e) {
                    Debug.LogException (e);
                }

                return default(T);
            }
        */



        /*
        public static  T FromString <T> (string stringSerialize) where T:EObject
        {

            try {

                if (stringSerialize != null) {

                    //Debug.LogWarning ("SERIALIZE:\n" + stringSerialize.Replace ("\n", "\t"));
                    EObject eObjectRoot = Instantiate<T> ();
                    int offset=0;
                   eObjectRoot.FromString ( stringSerialize, ref offset);
                    //eObjectRoot.From ( stringSerialize.ToCharArray(), ref offset);

                    return (T)eObjectRoot;
                }
            } catch (System.Exception e) {
                Debug.LogException (e);
            }

            return default(T);
        }
    */
        public static string UT8_VALUE = " \n\r1234567890'qwertyuiopasdfghjklzxcvbnm,.-!\"£$%&/()=?^QWERTYUIOPASDFGHJKLZXCVBNM;:_";
        public static Dictionary<string, string> mapX = new Dictionary<string, string>();
        public static bool isInit = false;

        public static void OnInit()
        {
            try
            {
                //    Debug.LogError("ONINIT");
                mapX.Add("00", "");
                char[] arrayChar = UT8_VALUE.ToCharArray();
                for (int i = 0; i < arrayChar.Length; i++)
                {
                    try
                    {
                        char valChar = arrayChar[i];

                        byte[] arrayByte = Encoding.UTF8.GetBytes(valChar.ToString());
                        StringBuilder stringBuilder = new StringBuilder();

                        foreach (byte b in arrayByte)

                        {

                            stringBuilder.Append(b.ToString("X"));

                        }
                        string valX = stringBuilder.ToString();
                        mapX.Add(valX, valChar.ToString());
                        //  Debug.LogError("ADD " + valChar.ToString() + "=>" + valX);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
                isInit = true;
                //   Debug.LogError("ONINIT OK");
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }
        /*
        public static String ToString(System.Object obj)
        {
            try
            {
                if (eObject != null)
                {
                    if (!isInit)
                    {
                        OnInit();
                    }

                    StringBuilder stringBuilder = new StringBuilder();

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        {
                            UBinary.DoWrite(eObject, memoryStream);
                            memoryStream.Flush();
                            var arrayByte = memoryStream.ToArray();

                            return ToString(arrayByte);



                        }



                    }
                }

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return "null";
        }
        */

        public static String ToString(IEObject eObject)
        {
            try
            {
                byte[] arrayByte = ToBytePtr(eObject);
                return IuConvert.ToBase64(arrayByte);
                //return ToString(arrayByte);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return "null";
        }


        public static String ToString(byte[] arrayByte)
        {
            try
            {

                if (!isInit)
                {
                    OnInit();
                }

                StringBuilder stringBuilder = new StringBuilder();


                string strLast = "";
                bool lastValid = false;
                foreach (byte b in arrayByte)

                {
                    try
                    {
#pragma warning disable CS0219
                        var currentValid = false;
#pragma warning restore CS0219
                        string strX = b.ToString("X");

                        if (strLast.Equals("00") && !strX.Equals("00"))
                        {
                            stringBuilder.Append("\n");
                        }

                        if (mapX.ContainsKey(strX))
                        {
                            currentValid = true;
                            if (lastValid == false)
                            {
                                stringBuilder.Append("\n");
                            }
                            stringBuilder.Append(mapX[strX]);
                            lastValid = true;
                        }
                        else
                        {
                            lastValid = false;
                            stringBuilder.Append(strX);
                        }



                        strLast = strX;
                        //
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                string strReturn = stringBuilder.ToString();

                /*   foreach (string key in mapX.Keys)
                  {
                      try
                      {
                          string value = mapX[key];
                          strReturn = strReturn.Replace(key, value);
                      }
                      catch (System.Exception e)
                      {
                          Debug.LogException(e);
                      }
                  }*/

                return strReturn;



            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return "null";
        }
        /*
        public static String ToHex(System.Object obj)
        {
            try
            {
                if (eObject != null)
                {
                    if (!isInit)
                    {
                        OnInit();
                    }

                    StringBuilder stringBuilder = new StringBuilder();

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        {
                            UBinary.DoWrite(eObject, memoryStream);
                            memoryStream.Flush();

                            var arrayByte = memoryStream.ToArray();

                            return ToHex(arrayByte);


                        }



                    }
                }

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return "null";
        }
        */
        public static String ToHex(byte[] arrayByte)
        {
            try
            {


                StringBuilder stringBuilder = new StringBuilder();


                foreach (byte b in arrayByte)

                {
                    try
                    {
                        string strX = b.ToString("X2");
                        stringBuilder.Append(strX);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                string strReturn = stringBuilder.ToString();



                return strReturn;


            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return "null";
        }

        public static IEObject Instantiate(string className)
        {
            try
            {
                //Debug.LogError("classname: " + className);
                Type type = Type.GetType(className);

                IEObject eObjectClone = (IEObject)Activator.CreateInstance(Type.GetType(className));
                return eObjectClone;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }

        /*
        public static EObject Instantiate<T>() where T : EObject 
        {
            try
            {

                Type type = typeof(T);

                if (mapEObjectIClone.ContainsKey(type))
                {

                    return (EObject)(mapEObjectIClone[type]).Clone();
                }
                else
                {

                    EObject eObjectClone = (EObject)Activator.CreateInstance<T>();
                    eObjectClone.iD = "AC";

                    mapEObjectIClone.Add(type, eObjectClone);

                    return (EObject)eObjectClone.Clone();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }
        */
    }
}