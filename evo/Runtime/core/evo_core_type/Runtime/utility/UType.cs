
using System;
using System.Collections.Generic;
using System.Collections;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public class UType : UObject
    {
        private static UType instance;

        public string host;
        public Int32 port;

        /// <summary>
        /// 
        /// </summary>
        public static UType getInstance()
        {
            if (instance == null)
            {
                instance = new UType();
            }
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        private UType()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public bool isEObject(System.Object obj)
        {
            try
            {
                if (obj is IEObject)
                {
                    return true;
                }
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
        public bool isMap(System.Object obj)
        {
            try
            {
                if (obj is IDictionary)
                {
                    return true;
                }
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
        public bool isArray(System.Object obj)
        {
            try
            {
                if (obj is IList)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                this.DoException(e);
            }

            return false;
        }
    }
}