
using System;
using System.Collections.Generic;
using System.Collections;

namespace Evo
{
    public class UType : UObject
    {
        private static UType instance;

        public string host;
        public Int32 port;

        public static UType getInstance()
        {
            if (instance == null)
            {
                instance = new UType();
            }
            return instance;
        }

        private UType()
        {
        }

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