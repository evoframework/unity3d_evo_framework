using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Threading;
using System.Runtime.Serialization;
using System.Linq;
using System.IO;
namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class Map : Dictionary<string, IEObject>
    {

        /*  public List<EObject> listEObject = new List<EObject>();

         public void OnBeforeSerialize()
         {
             listEObjectI.Clear();

             foreach (var kvp in this)
             {
                 listEObjectI.Add(kvp.Value);
             }
         }

         public void OnAfterDeserialize()
         {
             Clear();
             foreach (EObject eObject in listEObject)
             {
                 DoSet(eObject);
             }
         }*/

        public string nameMap = "Map";

        /// <summary>
        /// 
        /// </summary>
        public Map()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public Map Clone()
        {
            try
            {

                Map mapReturn = new Map();
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
        virtual public string ToStringSimple()
        {
            return ToString();
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

                    return this.ContainsKey(eObject.iD);

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
        public T DoGet<T>(string key) where T : IEObject
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

        /* public void Add(EObject value)
         {
             try
             {
                 if (value != null)
                 {
                     Add(IuKey.ToId(Count.ToString()), value);
                 }
             }
             catch (System.Exception e)
             {
                 Debug.LogException(e);
             }

         }*/

        /// <summary>
        /// 
        /// </summary>
        public void DoSet(System.Object obj)
        {
            try
            {
                if (obj != null)
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
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DoSet(string iD, IEObject eObject)
        {
            try
            {


                if (ContainsKey(iD))
                {
                    this[iD] = eObject;
                }
                else
                {
                    this.Add(iD, eObject);
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
        public void DoDel(System.Object obj)
        {
            try
            {
                IEObject eObject = (IEObject)obj;



                if (ContainsKey(eObject.iD))
                {
                    this.Remove(eObject.iD);
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
        override public string ToString()
        {
            try
            {
                string strReturn = "\n{\n";


                foreach (var kvp in this)
                {
                    try
                    {
                        IEObject eObject = (IEObject)kvp.Value;
                        if (eObject != null)
                        {
                            strReturn += "\n'" + kvp.Key.ToString() + "'" + ":" + kvp.Value;
                        }
                    }
                    catch (System.Exception e)
                    {
                        UnityEngine.Debug.LogException(e);
                    }
                }

                strReturn += "}";

                return strReturn;//string.Join("\n", this.Select(x => x.Key + "=" + x.Value).ToArray());

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }
    }
}