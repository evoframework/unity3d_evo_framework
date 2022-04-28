using System.Collections.Generic;
using System;
using System.Threading;
using System.Runtime.Serialization;
using System.Linq;
using System.IO;
using UnityEngine;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class MapObject<TValue> : Dictionary<string, TValue>//, ISerializationCallbackReceiver
    {
        [SerializeField]
        private List<string> keys = new List<string>();

        [SerializeField]
        private List<TValue> values = new List<TValue>();

        /*	// save the dictionary to lists
            public void OnBeforeSerialize()
            {
                Debug.LogError("OnBeforeSerialize");
                keys.Clear();
                values.Clear();
                foreach(KeyValuePair<string, TValue> pair in this)
                {
                    keys.Add(pair.Key);
                    values.Add(pair.Value);
                }
            }

            // load dictionary from lists
            public void OnAfterDeserialize()
            {
                Debug.LogError("OnAfterDeserialize");
                this.Clear();

                if(keys.Count != values.Count){
                    throw new System.Exception(string.Format("there are {0} keys and {1} values after deserialization. Make sure that both key and value types are serializable."));
                }
                for(int i = 0; i < keys.Count; i++){
                    this.Add(keys[i], values[i]);
                }
            }
            */


        /// <summary>
        /// 
        /// </summary>
        public void DoSet(string key, TValue value)
        {
            try
            {

                if (ContainsKey(key))
                {
                    this[key] = value;
                }
                else
                {
                    this.Add(key, value);
                }

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }
        /*
        public K DoGet<K> (string key)
        {
            try {
                return (K) this [key];
            } catch (System.Exception e) {
                //UObject.DoError (e);
            }	

            return default(K);
        }
    */
        /// <summary>
        /// 
        /// </summary>
        public TValue DoGet(string key)
        {
            try
            {
                return (TValue)this[key];
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return default(TValue);
        }


        /// <summary>
        /// 
        /// </summary>
        public T1 DoGet<T1>(string key) where T1 : TValue
        {
            try
            {
                return (T1)this[key];
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return default(T1);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoDel(string key)
        {
            try
            {
                if (ContainsKey(key))
                {
                    this.Remove(key);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ToStream(Stream stream)
        {

            try
            {


            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
            //	writer.Flush();
        }

        /// <summary>
        /// 
        /// </summary>
        public void FromStream(Stream stream)
        {
            try
            {
                this.Clear();

            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
        }

    }
}