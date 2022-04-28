using UnityEngine;
using System.Collections.Generic;
using System;
using System.Threading;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class MapSort : SortedDictionary<Id, System.Object>
    {

        /*
        public System.Object DoGet (string key)
        {
            try {
                if (ContainsKey (key)) {
                    return this [key];
                }
            } catch (System.Exception e) {
                UObject.DoError(e);
            }	
            return null;
        }*/

        /// <summary>
        /// 
        /// </summary>
        public MapSort Clone()
        {
            try
            {

                MapSort mapReturn = new MapSort();
                foreach (var key in this.Keys)
                {
                    mapReturn.Add(key, this[key]);

                }
                return mapReturn;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Contain(System.Object obj)
        {
            try
            {
                if (obj != null)
                {
                    IEObject eObject = (IEObject)obj;

                    if (eObject.iD != null)
                    {
                        return this.ContainsKey(eObject.iD);
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public T DoGet<T>(Id key)
        {
            try
            {
                if (ContainsKey(key))
                {
                    return (T)this[key];
                }
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return default(T);
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoSet(Id key, System.Object value)
        {
            try
            {
                //if (key != null) {
                if (ContainsKey(key))
                {
                    this[key] = value;
                }
                else
                {
                    this.Add(key, value);
                }
                //}
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void DoSet(System.Object obj)
        {
            try
            {
                IEObject eObject = (IEObject)obj;
                if (ContainsKey(eObject.iD))
                {
                    this[eObject.iD] = eObject;
                }
                else
                {
                    this.Add(eObject.iD, eObject);
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
        public void DoDel(Id key)
        {
            try
            {
                //if (key != null) {


                if (ContainsKey(key))
                {
                    this.Remove(key);
                }
                //}
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public void DoDel(System.Object obj)
        {
            try
            {
                IEObject eObject = (IEObject)obj;
                //if (eObject.iD != null) {


                if (ContainsKey(eObject.iD))
                {
                    this.Remove(eObject.iD);
                }
                //}
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        override public string ToString()
        {
            try
            {
                string strReturn = "Map " + "[" + this.Count + "]\n";
                int i = 0;

                foreach (var key in this.Keys)
                {
                    try
                    {
                        strReturn += "\tkey: [" + i.ToString() + "]\n" + key + "\n\tvalue:\n" + DoGet<System.Object>(key).ToString() + "\n";
                        i += 1;
                        if (i >= 20)
                        {
                            strReturn += "\n...\n";
                            break;
                        }
                    }
                    catch (System.Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                return strReturn;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

    }
}