// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************

using System.Collections;
using System.IO;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public class UBinary : UObject
    { 
        protected static UBinary instance;

        /// <summary>
        /// Singleton
        /// </summary>
        private UBinary()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public static UBinary Instance()
        {
            if (instance == null)
            {
                instance = new UBinary();
            }
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(byte[] _value, Stream _stream)
        {
            if (_value == null)
            {
                DoWrite((int)0, _stream);
               
            }
            else
            {
                byte[] arrayByte = _value;
                DoWrite(arrayByte.Length, _stream);
                _stream.Write(arrayByte, 0, arrayByte.Length);
                _stream.Flush();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(string _value, Stream _stream)
        {
            if (_value == null)
            {
                DoWrite((int)-1, _stream);
            }
            else
            {
                //this.DoVerbose("DoWrite:" + _value);
                byte[] arrayByte = System.Text.Encoding.UTF8.GetBytes(_value);
                //this.DoVerbose("DoWrite:" + arrayByte.Length);
                DoWrite( arrayByte.Length, _stream);
                _stream.Write(arrayByte, 0, arrayByte.Length);
                _stream.Flush();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string DoReadString(System.IO.Stream _stream)
        {
            try
            {
                string value = null;
                int lenght = DoReadInt(_stream);

                if (lenght == -1)
                {
                    value = null;
                }
                else
                {
                    //this.DoVerbose("lenght:" + lenght);
                    byte[] arrayByte = new byte[lenght];
                    _stream.Read(arrayByte, 0, lenght);
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

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(Texture2D _value, Stream _stream)
        {
            if (_value != null)
            {
                DoWrite(true, _stream);
                byte[] arrayByte = _value.EncodeToPNG();
                DoWrite(arrayByte.Length, _stream);
                _stream.Write(arrayByte, 0, arrayByte.Length);
            }
            else
            {
                DoWrite(false, _stream);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(Color _value, Stream _stream)
        {
            if (_value != null)
            {
                DoWrite(true, _stream);
                DoWrite((float)_value.r, _stream);
                DoWrite((float)_value.g, _stream);
                DoWrite((float)_value.b, _stream);
                DoWrite((float)_value.a, _stream);
            }
            else
            {
                DoWrite(false, _stream);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(float _value, Stream _stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(_value);
            _stream.Write(arrayByte, 0, arrayByte.Length);

        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(double _value, Stream _stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(_value);
            this.DoVerbose("DoWrite" + arrayByte.Length + " " + _value);
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(char _value, Stream _stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(_value);      
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public char DoReadChar(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(char)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                char value = BitConverter.ToChar(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }

            return default(char);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(bool _value, Stream _stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(_value);
            //this.DoVerbose("sizeof(arrayByte bool)" + arrayByte.Length);
            //  Debug.Log("bool:" + IuSerialize.ToHex(arrayByte));
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(byte _value, Stream _stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(_value);
            Debug.LogWarning(arrayByte.Length);
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(Int16 _value, Stream _stream)
        {
            // byte[] arrayByte = new byte[sizeof(Int16)];

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(_value);
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(Int32 _value, Stream _stream)
        {
            // byte[] arrayByte = new byte[sizeof(Int32)]; //BitConverter.GetBytes(value);

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(_value);
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(Int64 _value, Stream _stream)
        {
            byte[] arrayByte = BitConverter.GetBytes(_value);  
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        
        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(UInt16 _value, Stream _stream)
        {
            // byte[] arrayByte = new byte[sizeof(UInt16)];

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(_value);
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(UInt32 _value, Stream _stream)
        {
            //byte[] arrayByte = new byte[sizeof(UInt32)];

            // WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(_value);
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(UInt64 _value, Stream _stream)
        {
            // byte[] arrayByte = new byte[sizeof(UInt64)];

            //  WriteEndian(ref arrayByte, (ulong)value);
            byte[] arrayByte = BitConverter.GetBytes(_value);
            _stream.Write(arrayByte, 0, arrayByte.Length);
        }
    
        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(IBinary _value, Stream _stream)
        {

            if (_value != null)
            {
                DoWrite(true, _stream);
                DoWrite(_value.GetType().Name, _stream);
                _value.ToStream(_stream);
            }
            else
            {
                DoWrite(false, _stream);
            }
        }


        /*
        public void DoWrite(EObject _value, Stream _stream)
        {

            if (value != null)
            {
                DoWrite(true, _stream);
                DoWrite(value.GetType().Name, _stream);
                DoWrite(IuSerialize.ToBytePtr(value), _stream);
                // _value.ToStream(stream);
            }
            else
            {
                DoWrite(false, _stream);
            }
        }*/



        /*
         * 
         * def DoWriteEObject(value, _stream: io.BytesIO):
        if _value == None:
            IuBinary.DoWriteInt(-1, _stream)
        else:
            IuBinary.DoWriteInt(0, _stream)
            IuBinary.DoWriteString(value.__class__.__module__, _stream)
            _value.ToStream(stream)
        _stream.flush()

    def DoReadEObject(stream: io.BytesIO):
        offset = 4
        arrayByteLength = _stream.read(offset)
        length = struct.unpack('<l', arrayByteLength[0:offset])[0]
        if length == -1:
            return None
        else:
            className = IuBinary.DoReadString(stream)
            eObject = IuBinary.toClass(className)
            eObject.FromStream(stream)
            return eObject
        */

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(EObject eObject,System.IO.Stream _stream)
        {
            try
            {

                EObject _value = null;
                if (_value == null)
                {
                    DoWrite((int)-1, _stream);
                }
                else
                {
                    DoWrite((Int32)0, _stream);
                    DoWrite(_value.GetType().Name,_stream);
                    _value.ToStream(_stream);
                }

                _stream.Flush();
            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }


        }

        /*
        public EObject DoReadEObject(System.IO.Stream _stream)
        {
            try
            {                
                EObject _value = null;
                int count = DoReadInt(stream);

                if (count == -1)
                {
                    return null;
                }
                else
                {
                    string className = DoReadString(stream);
                    _value = Instantiate(className);
                    _value.FromStream(stream);
                    return _value;
                }
            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }

            return null;

        }*/

        /// <summary>
        /// 
        /// </summary>
        public T DoReadEObject<T>(System.IO.Stream _stream) where T:EObject, new()
        {
            try
            {
                EObject _value = null;
                int count = DoReadInt(_stream);

                if (count == -1)
                {
                    return null;
                }
                else
                {
                    string className = DoReadString(_stream);

                    _value = new T();// Instantiate<T>();
                    _value.FromStream(_stream);
                    return (T) _value;
                }
            }
            catch (System.Exception e)
            {
                this.DoException(e);
            }

            return null;

        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public void DoWrite(Map _value, Stream _stream)
        {

            try
            {
                if (_value == null)
                {
                    DoWrite((int)-1, _stream);
                }
                else
                {
                    DoWrite((Int32)_value.Count, _stream);
                    DoWrite(_value.nameMap, _stream);

                    foreach (var kvp in _value)
                    {
                        try
                        {
                            EObject eObject = (EObject)kvp.Value;
                            eObject.ToStream(_stream);
                        }
                        catch (System.Exception e)
                        {
                            Debug.LogException(e);
                        }
                    }

                }

                _stream.Flush();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }
        /*
        public Map DoReadMap(System.IO.Stream _stream)
        {
            try
            {
                Map _value = null;
                int count = DoReadInt(stream);
              

                if (count ==-1)
                {
                   return null;
                }
                else
                {
                    this.DoError("map count:" + count);
                    string name = DoReadString(stream);
                    _value = new Map();
                    _value.nameMap = name;

                    for (int i = 0; i < count; i++)
                    {
                        var eObject = DoReadEObject(stream);
                        _value.DoSet(eObject);
                    }         
                }

                return _value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return null;
        }
        */

        /// <summary>
        /// 
        /// </summary>
        public Map DoReadMap<T>(System.IO.Stream _stream) where T:EObject,new ()
        {
            try
            {
                Map value = null;
                int count = DoReadInt(_stream);


                if (count == -1)
                {
                    return null;
                }
                else
                {
                    //this.DoVerbose("map count:" + count);
                    string name = DoReadString(_stream);
                    value = new Map();
                    value.nameMap = name;

                    for (int i = 0; i < count; i++)
                    {
                        var eObject = DoReadEObject<T>(_stream);
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

 
        /// <summary>
        /// 
        /// </summary>
        public Color DoReadColor(System.IO.Stream _stream)
        {
            try
            {
                Color value = default(Color);
                int lenght = DoReadInt(_stream);



                if (lenght != 0)
                {
                    float r = DoReadFloat(_stream);

                    float g = DoReadFloat(_stream);


                    float b = DoReadFloat(_stream);


                    float a = DoReadFloat(_stream);


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

        /// <summary>
        /// 
        /// </summary>
        public byte DoReadByte(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(byte)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                byte value = arrayByte[0];
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(byte);
        }

        /// <summary>
        /// 
        /// </summary>
        public byte[] DoReadByteArray(System.IO.Stream _stream)
        {
            try
            {
                byte[] value;
                int lenght = DoReadInt(_stream);

                if (lenght != 0)
                {
                    byte[] arrayByte = new byte[lenght];
                    _stream.Read(arrayByte, 0, lenght);
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

        /// <summary>
        /// 
        /// </summary>
        public bool DoReadBoolean(System.IO.Stream _stream)
        {
            try
            {
                //this.DoVerbose("sizeof(bool)" + sizeof(bool));
                byte[] arrayByte = new byte[sizeof(bool)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                bool value = BitConverter.ToBoolean(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public Texture2D DoReadTexture2D(System.IO.Stream _stream)
        {
            try
            {
                Texture2D value = default(Texture2D);
                int lenght = DoReadInt(_stream);

                if (lenght != 0)
                {

                    byte[] arrayByte = new byte[lenght];
                    _stream.Read(arrayByte, 0, lenght);

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

        /// <summary>
        /// 
        /// </summary>
        public UInt16 DoReadUInt16(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(bool)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                UInt16 value = BitConverter.ToUInt16(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(UInt16);
        }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 DoReadUInt32(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(UInt32)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                UInt32 value = BitConverter.ToUInt32(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(UInt32);
        }

        /// <summary>
        /// 
        /// </summary>
        public UInt64 DoReadUInt64(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(UInt64)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                UInt64 value = BitConverter.ToUInt64(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(UInt64);
        }

        /// <summary>
        /// 
        /// </summary>
        public Int16 DoReadInt16(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int16)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                Int16 value = BitConverter.ToInt16(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(Int16);
        }

        /// <summary>
        /// 
        /// </summary>
        public int DoReadInt(System.IO.Stream _stream)
        {

            try
            {
                byte[] arrayByte = new byte[sizeof(int)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                int value = BitConverter.ToInt32(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(int);
        }

        /// <summary>
        /// 
        /// </summary>
        public Int32 DoReadInt32(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int32)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                Int32 value = BitConverter.ToInt32(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(Int32);
        }

        /// <summary>
        /// 
        /// </summary>
        public Int64 DoReadInt64(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int64)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                Int64 value = BitConverter.ToInt64(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(Int64);
        }

        /// <summary>
        /// 
        /// </summary>
        public long DoReadLong(System.IO.Stream _stream)
        {
            try
            {
                byte[] arrayByte = new byte[sizeof(Int64)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                Int64 value = BitConverter.ToInt64(arrayByte, 0);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(long);
        }

        /// <summary>
        /// 
        /// </summary>
        public double DoReadDouble(System.IO.Stream _stream)
        {

            try
            {
                this.DoVerbose("sizeof(double):" + sizeof(double));
                byte[] arrayByte = new byte[sizeof(double)];
                _stream.Read(arrayByte, 0, arrayByte.Length);
                double value = BitConverter.ToDouble(arrayByte, 0);
                this.DoVerbose("(double):" + value);
                return value;
            }
            catch (Exception e)
            {
                this.DoException(e);
            }
            return default(double);
        }

        /// <summary>
        /// 
        /// </summary>
        public float DoReadFloat(System.IO.Stream _stream)
        {
            try
            {
                float value = default(float);

                byte[] arrayByte = new byte[sizeof(float)];

                _stream.Read(arrayByte, 0, arrayByte.Length);

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
        public static void FromStream(this Map source, Stream _stream)
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
        public EObject DoReadEObject(System.IO.Stream _stream)
        {
            try
            {
                // EObject eObjectReturn = null;
                EObject _value = null;
                bool isValid = DoReadBoolean(stream);

                if (!isValid)
                {
                    _value = null;
                }
                else
                {
                    string className = DoReadString(stream);

                    var arrayByte = DoReadByteArray(stream);
                    EObject eObjectI = IuSerialize.FromBytePtr(className, arrayByte);

                    return _value;
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