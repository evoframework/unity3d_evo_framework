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

        public static string Generate()
        {
            return GenerateTicks256().ToString();
        }

        /*
                public static void ToId(this EObject source, string str)
                {
                    source.iD = new Id(str);
                    Debug.LogWarning(source.iD);
                }

                public static void NewId(this EObject source)
                {
                    source.iD = new Id(GenerateTicks256());
                }
        */
        public static Id ToId(string str)
        {
            return new Id(str);
        }

        public static Id ToId<T>(string str)
        {
            return new Id(IuCryptSha.GenerateSha256(typeof(T).GetHashCode().ToString() + str.GetHashCode().ToString()));
        }

        public static long GenerateLong(int left, int right)
        {

            long res = left;

            res = (res << 32);

            res = res | (long)(uint)right;


            return res;
        }

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

        public static string GenerateDate()
        {
            return String.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.UtcNow);
        }

        public static string GenerateDateIt()
        {
            return String.Format("{0:dd/MM/yyyy}", DateTime.UtcNow);
        }
        /*
        public static long GenerateTimeNumber ()
        {	
            return DateTime.UtcNow.; 
        }*/

        /*public static string GenerateTime ()
        {	
            idCounterTime += 1;
            return String.Format ("{0:yyyyMMddHHmmssffff}", DateTime.UtcNow) + idCounterTime; 
        }
        */

        public static string GenerateTime()
        {
            idCounterTime += 1;
            return (DateTime.UtcNow.Ticks + idCounterTime).ToString();
        }

        public static string GenerateTimeSeparator()
        {
            idCounterTime += 1;
            return String.Format("{0:yyyy-MM-dd_HH-mm-ss-ffff}", DateTime.UtcNow) + "_" + idCounterTime;
        }

        /*
        public static string Device ()
        {
            try {

                if (iD == null) {
                    IuCryptEC.DoGenerate();
                    iD = IuCryptEC.PublicKey().iD;
                 //  EKeyPublic eRsaPublic = IuCrypt.PublicKey();
                 //   iD = eRsaPublic.hash;
                  /*  string iDDevice = SystemInfo.deviceUniqueIdentifier.ToString ().Replace ("-", "") 
                        + Application.platform.ToString ();
                    //iD = iDDevice;
                    iD = IuCryptSha.GenerateSha256 (iDDevice);*/
        /*  }
       } catch (System.Exception e) {
           DoError (e);
       }
       return iD;

   }*/

        public static Id GenerateId()
        {
            try
            {
                return new Id(GenerateTicks256());
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return default;

        }

        /*public static string GenerateIdDevice ()
        {
            try {

                if (IuValidator.IsEmpty (iDPad)) {
                    int totalLenght = 16;
                    if (Device ().Length > totalLenght) {
                        iDPad = iD.Substring (0, totalLenght);
                    } else {
                        iDPad = iD.PadRight (totalLenght, '0');
                    }
                }

                string strReturn = iDPad + GenerateTicks ().ToString ();

                return strReturn;
            } catch (System.Exception e) {
                DoError (e);
            }
            return null;

        }*/

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

        /*	public static string DevicePush ()
            {
                try {

                    string strReturn = "TOKEN_PUSH";	
                    #if UNITY_5_0_0	
        #if UNITY_IPHONE
                    if (Application.platform == RuntimePlatform.IPhonePlayer) {
                        byte[] arrayByteToken = UnityEngine.iOS.NotificationServices.deviceToken;
                        if (arrayByteToken != null) {
                            strReturn = System.BitConverter.ToString (arrayByteToken).Replace ("-", "");
                        } 
                    }
        #endif
                    #if UNITY_ANDROID
                /*	if (Application.platform == RuntimePlatform.Android) {
                        if (parameter != null) {
                            token = parameter.ToString ();
                            tokenDevice = token;
                        }
                    }
                    #endif

                    #if UNITY_WEBPLAYER
                    strReturn = GenerateRsaId();
                    #endif
        #endif
                    return strReturn;
                } catch (System.Exception e) {
                    DoError (e);
                }
                return null;

            }*/

        public static void GenerateId(EvoObject evoObject)
        {
            try
            {

                evoObject.iD = new Id(evoObject.GetType().Name + "-" + evoObject.GetInstanceID().ToString().Replace("-", "0"));

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

        }

    }
}