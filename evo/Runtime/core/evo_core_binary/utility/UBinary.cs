using System.Collections;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace Evo
{
    public class UBinary : UObject
    {

        protected static UBinary instance;
        private UBinary()
        {
        }

        public static UBinary Instance()
        {
            if (instance == null)
            {
                instance = new UBinary();
            }
            return instance;
        }

        public void DoWrite(byte[] value, Stream stream)
        {
            if (value == null)
            {
                DoWrite((int)0, stream);
               
            }
            else
            {
                byte[] arrayByte = value;
                DoWrite(arrayByte.Length, stream);
                stream.Write(arrayByte, 0, arrayByte.Length);
                stream.Flush();
            }
        }
        public void DoWrite(string value, Stream stream)
        {
            if (value == null)
            {
                DoWrite((int)-1, stream);
            }
            else
            {
                this.DoError("DoWrite:" + value);
                byte[] arrayByte = System.Text.Encoding.UTF8.GetBytes(value);
                DoWrite(arrayByte.Length, stream);
                stream.Write(arrayByte, 0, arrayByte.Length);
                stream.Flush();
            }
        }

        public string DoReadString(System.IO.Stream stream)
        {
            try
            {
                string value = null;
                int lenght = DoReadInt(stream);

                if (lenght == -1)
                {
                    value = null;
                }
                else
                {
                    byte[] arrayByte = new byte[lenght];
                    stream.Read(arrayByte, 0, lenght);
                    value = System.Text.Encoding.UTF8.GetString(arrayByte);
                }

                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return null;
        }


        public void DoWrite(Texture2D value, Stream stream)
        {
            if (value != null)
            {
                DoWrite(true, stream);
                byte[] arrayByte = value.EncodeToPNG();
                DoWrite(arrayByte.Length, stream);
                stream.Write(arrayByte, 0, arrayByte.Length);
            }
            else
            {
                DoWrite(false, stream);

            }
        }

        public void DoWrite(Color value, Stream stream)
        {
            if (value != null)
            {
                DoWrite(true, stream);
                DoWrite((float)value.r, stream);
                DoWrite((float)value.g, stream);
                DoWrite((float)value.b, stream);
                DoWrite((float)value.a, stream);
            }
            else
            {
                DoWrite(false, stream);

            }
        }

        public void DoWrite(float value, Stream stream)
        {

            byte[] arrayByte = BitConverter.GetBytes(value);
            stream.Write(arrayByte, 0, arrayByte.Length);

        }

        public void DoWrite(double value, Stream stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(value);
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(bool value, Stream stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(value);
            //  Debug.Log("bool:" + IuSerialize.ToHex(arrayByte));
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(Int16 value, Stream stream)
        {
            // byte[] arrayByte = new byte[sizeof(Int16)];

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(value);
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(Int32 value, Stream stream)
        {
            // byte[] arrayByte = new byte[sizeof(Int32)]; //BitConverter.GetBytes(value);

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(value);
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(Int64 value, Stream stream)
        {
            //byte[] arrayByte = new byte[sizeof(Int64)];

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(value);
            // Debug.Log("Int64:" + IuSerialize.ToHex(arrayByte));
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(UInt16 value, Stream stream)
        {
            // byte[] arrayByte = new byte[sizeof(UInt16)];

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(value);
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(UInt32 value, Stream stream)
        {
            //byte[] arrayByte = new byte[sizeof(UInt32)];

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(value);
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(UInt64 value, Stream stream)
        {
            // byte[] arrayByte = new byte[sizeof(UInt64)];

            //  WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(value);
            stream.Write(arrayByte, 0, arrayByte.Length);
        }

        public void DoWrite(Id value, Stream stream)
        {
            DoWrite(value.iD, stream);
        }

        public void DoRead(out Id iD, System.IO.Stream stream)
        {

            byte[] arrayByte = DoReadByteArray(stream);
            iD.iD = arrayByte;


        }

        public void DoWrite(Time value, Stream stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(value.time);
            stream.Write(arrayByte, 0, arrayByte.Length);
        }


        public void DoWrite(IBinary value, Stream stream)
        {

            if (value != null)
            {
                DoWrite(true, stream);
                DoWrite(value.GetType().Name, stream);
                value.ToStream(stream);
            }
            else
            {
                DoWrite(false, stream);
            }
        }


        /*
        public void DoWrite(EObject value, Stream stream)
        {

            if (value != null)
            {
                DoWrite(true, stream);
                DoWrite(value.GetType().Name, stream);
                DoWrite(IuSerialize.ToBytePtr(value), stream);
                // value.ToStream(stream);
            }
            else
            {
                DoWrite(false, stream);
            }
        }*/

      

        /*
         * 
         * def DoWriteEObject(value, stream: io.BytesIO):
        if value == None:
            IuBinary.DoWriteInt(-1, stream)
        else:
            IuBinary.DoWriteInt(0, stream)
            IuBinary.DoWriteString(value.__class__.__module__, stream)
            value.ToStream(stream)
        stream.flush()

    def DoReadEObject(stream: io.BytesIO):
        offset = 4
        arrayByteLength = stream.read(offset)
        length = struct.unpack('<l', arrayByteLength[0:offset])[0]
        if length == -1:
            return None
        else:
            className = IuBinary.DoReadString(stream)
            eObject = IuBinary.toClass(className)
            eObject.FromStream(stream)
            return eObject
        */

        public void DoWrite(EObject eObject,System.IO.Stream stream)
        {
            try
            {

                EObject value = null;
                if (value == null)
                {
                    DoWrite((int)-1, stream);
                }
                else
                {
                    DoWrite((Int32)0, stream);
                    DoWrite(value.GetType().Name,stream);
                    value.ToStream(stream);
                }

                stream.Flush();
            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }


        }

        /*
        public EObject DoReadEObject(System.IO.Stream stream)
        {
            try
            {                
                EObject value = null;
                int count = DoReadInt(stream);

                if (count == -1)
                {
                    return null;
                }
                else
                {
                    string className = DoReadString(stream);
                    value = Instantiate(className);
                    value.FromStream(stream);
                    return value;
                }
            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }

            return null;

        }*/

        public T DoReadEObject<T>(System.IO.Stream stream) where T:EObject, new()
        {
            try
            {
                EObject value = null;
                int count = DoReadInt(stream);

                if (count == -1)
                {
                    return null;
                }
                else
                {
                    string className = DoReadString(stream);

                    value = new T();// Instantiate<T>();
                    value.FromStream(stream);
                    return (T) value;
                }
            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }

            return null;

        }


        public T Instantiate<T>() where T:EObject
        {
            try
            {
                Type typeT = typeof(T);
              T eObjectClone = (T)Activator.CreateInstance(typeT);
              return eObjectClone;
            
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }

        /*
        public EObject Instantiate(string className)
        {
            try
            {
                this.DoWarning("className:" + className);

                var arrayName = className.Split('.');

                var name = arrayName[arrayName.Length - 1];

                this.DoWarning("className:" + name);



                var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    var types = assembly.GetTypes();
                    string assemblyStr = "";
                    foreach (var typeT in types)
                    {
                        assemblyStr +=("assembly:" + assembly.FullName + " " + typeT.FullName + "\n");
                        if (typeT.Name.Equals(className))
                        {

                          

                           // Type type = Type.GetType(name);
                            EObject eObjectClone = (EObject)Activator.CreateInstance(typeT);
                            return eObjectClone;
                        }
                    }
                    //this.DoWarning("assembly:\n" + assemblyStr);

                    IuFile.DoWrite("assembly.txt",assemblyStr,false);

                }

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }*/

        public void DoWrite(Map value, Stream stream)
        {

            try
            {
                if (value == null)
                {
                    DoWrite((int)-1, stream);
                }
                else
                {
                    DoWrite((Int32)value.Count, stream);
                    DoWrite(value.nameMap, stream);

                    foreach (var kvp in value)
                    {
                        try
                        {
                            EObject eObject = (EObject)kvp.Value;
                            eObject.ToStream(stream);
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogException(e);
                        }
                    }

                }

                stream.Flush();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }
        /*
        public Map DoReadMap(System.IO.Stream stream)
        {
            try
            {
                Map value = null;
                int count = DoReadInt(stream);
              

                if (count ==-1)
                {
                   return null;
                }
                else
                {
                    this.DoError("map count:" + count);
                    string name = DoReadString(stream);
                    value = new Map();
                    value.nameMap = name;

                    for (int i = 0; i < count; i++)
                    {
                        var eObject = DoReadEObject(stream);
                        value.DoSet(eObject);
                    }         
                }

                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return null;
        }
        */
        public Map DoReadMap<T>(System.IO.Stream stream) where T:EObject,new ()
        {
            try
            {
                Map value = null;
                int count = DoReadInt(stream);


                if (count == -1)
                {
                    return null;
                }
                else
                {
                    this.DoError("map count:" + count);
                    string name = DoReadString(stream);
                    value = new Map();
                    value.nameMap = name;

                    for (int i = 0; i < count; i++)
                    {
                        var eObject = DoReadEObject<T>(stream);
                        value.DoSet(eObject);
                    }
                }

                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return null;
        }

        public Id DoReadId(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = DoReadByteArray(stream);

                return new Id(arrayByte);

            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default;
        }



        public Time DoReadTime(System.IO.Stream stream)
        {
            try
            {
                long val = DoReadInt64(stream);
                return new Time(val);

            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default;
        }

        public Color DoReadColor(System.IO.Stream stream)
        {
            try
            {
                Color value = default(Color);
                int lenght = DoReadInt(stream);



                if (lenght != 0)
                {
                    float r = DoReadFloat(stream);

                    float g = DoReadFloat(stream);


                    float b = DoReadFloat(stream);


                    float a = DoReadFloat(stream);


                    value = new Color(r, g, b, a);
                }
                else
                {
                    value = new Color(255, 255, 255, 255); //not nullable
                }
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(Color);

        }

        public byte[] DoReadByteArray(System.IO.Stream stream)
        {
            try
            {
                byte[] value;
                int lenght = DoReadInt(stream);

                if (lenght != 0)
                {
                    byte[] arrayByte = new byte[lenght];
                    stream.Read(arrayByte, 0, lenght);
                    value = arrayByte;
                }
                else
                {
                    value = null;
                }
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return null;
        }

        public bool DoReadBoolean(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(bool)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                bool value = BitConverter.ToBoolean(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return false;
        }

        public Texture2D DoReadTexture2D(System.IO.Stream stream)
        {
            try
            {
                Texture2D value = default(Texture2D);
                int lenght = DoReadInt(stream);

                if (lenght != 0)
                {

                    byte[] arrayByte = new byte[lenght];
                    stream.Read(arrayByte, 0, lenght);

                    value = new Texture2D(0, 0);
                    value.LoadImage(arrayByte);

                }
                else
                {
                    value = null;
                }
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return null;
        }

        public UInt16 DoReadUInt16(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(bool)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                UInt16 value = BitConverter.ToUInt16(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(UInt16);
        }

        public UInt32 DoReadUInt32(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(UInt32)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                UInt32 value = BitConverter.ToUInt32(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(UInt32);
        }

        public UInt64 DoReadUInt64(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(UInt64)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                UInt64 value = BitConverter.ToUInt64(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(UInt64);
        }

        public Int16 DoReadInt16(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int16)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                Int16 value = BitConverter.ToInt16(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(Int16);
        }

        public int DoReadInt(System.IO.Stream stream)
        {

            try
            {
                byte[] arrayByte = new byte[sizeof(int)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                int value = BitConverter.ToInt32(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(int);
        }



        public Int32 DoReadInt32(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int32)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                Int32 value = BitConverter.ToInt32(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(Int32);
        }

        public Int64 DoReadInt64(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int64)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                Int64 value = BitConverter.ToInt64(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(Int64);
        }

        public long DoReadLong(System.IO.Stream stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int64)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                Int64 value = BitConverter.ToInt64(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(long);
        }

        public double DoReadDouble(System.IO.Stream stream)
        {

            try
            {
                byte[] arrayByte = new byte[sizeof(double)];
                stream.Read(arrayByte, 0, arrayByte.Length);
                double value = BitConverter.ToDouble(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(double);
        }

        public float DoReadFloat(System.IO.Stream stream)
        {
            try
            {
                float value = default(float);

                byte[] arrayByte = new byte[sizeof(float)];

                stream.Read(arrayByte, 0, arrayByte.Length);

                value = BitConverter.ToSingle(arrayByte, 0);
                return value;

            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(float);
        }



        /*
        public static void FromStream(this Map source, Stream stream)
        {
            try
            {
                source.Clear();
                Int32 count = UBinary.Instance().DoReadInt(stream);
                source.nameMap = UBinary.Instance().DoReadString(stream);

                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        var eObjectValue = UBinary.Instance().DoReadEObjectI(stream);
                        source.DoSet(eObjectValue);
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }*/

        /*
        public EObject DoReadEObject(System.IO.Stream stream)
        {
            try
            {
                // EObject eObjectReturn = null;
                EObject value = null;
                bool isValid = DoReadBoolean(stream);

                if (!isValid)
                {
                    value = null;
                }
                else
                {
                    string className = DoReadString(stream);

                    var arrayByte = DoReadByteArray(stream);
                    EObject eObjectI = IuSerialize.FromBytePtr(className, arrayByte);

                    return value;
                }
            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }

            return null;

        }*/

    }
}