using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Evo
{
    public static class IuObject
    {
        public static void Try(this IEvo source, Action action)
        {
            try
            {
                ((Action)action)();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        public static void Throw(this IEvo source, Action action)
        {
            try
            {
                ((Action)action)();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
                throw e;
            }
        }
    }
}
