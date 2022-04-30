using UnityEngine;
using System.Collections;
using System;
namespace Evo
{
    public static class IuKey
    {

        static string iDPad;
        static int idCounter = 1;
        static int idCounterTime = 0;

        /// <summary>
        /// 
        /// </summary>
        public static string Generate()
        {
            return GenerateTicks256().ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToId(string str)
        {
            if(str != null)
            {
                return str;
            }
            else
            {
                throw new Exception("not valid iD");
            }     
        }

        /// <summary>
        /// 
        /// </summary>
        public static string ToId<T>(string str)
        {
            return IuCryptSha.GenerateSha256(typeof(T).GetHashCode().ToString() + str.GetHashCode().ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public static long GenerateLong(int left, int right)
        {

            long res = left;

            res = (res << 32);

            res = res | (long)(uint)right;


            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateTicks256()
        {
            try
            {
                long elapsedTicks = DateTime.UtcNow.Ticks + idCounter;
                idCounter += 1;
                return IuCryptSha.GenerateSha256(elapsedTicks.ToString());
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return IuCryptSha.GenerateSha256(DateTime.UtcNow.Ticks.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        public static long GenerateLongTicks()
        {
            try
            {
                long elapsedTicks = DateTime.UtcNow.Ticks + idCounter;
                idCounter += 1;
                return elapsedTicks;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return DateTime.UtcNow.Ticks;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateDate()
        {
            return String.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.UtcNow);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateDateIt()
        {
            return String.Format("{0:dd/MM/yyyy}", DateTime.UtcNow);
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateTime()
        {
            idCounterTime += 1;
            return (DateTime.UtcNow.Ticks + idCounterTime).ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateTimeSeparator()
        {
            idCounterTime += 1;
            return String.Format("{0:yyyy-MM-dd_HH-mm-ss-ffff}", DateTime.UtcNow) + "_" + idCounterTime;
        }

        /// <summary>
        /// 
        /// </summary>
        public static string GenerateId()
        {
            try
            {
                return GenerateTicks256();
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return default;

        }

        /// <summary>
        /// 
        /// </summary>
        public static int ToIntHash(string iD)
        {
            try
            {
                string hashSha = IuCryptSha.GenerateSha256(iD);


                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(hashSha);
                int result = BitConverter.ToInt32(bytes, 0);
                return result;

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return 0;

        }

        /// <summary>
        /// 
        /// </summary>
        public static void GenerateId(EvoObject evoObject)
        {
            try
            {

                evoObject.iD = evoObject.GetType().Name + "-" + evoObject.GetInstanceID().ToString().Replace("-", "0");

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }

    }
}