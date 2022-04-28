using System;
using UnityEngine;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;

namespace Evo
{
    public class IuCryptHmac : UObject
    {

        /// <summary>
        /// 
        /// </summary>
        public static byte[] Hash256(string text, string key)
        {
            try
            {
                var hmac = new Org.BouncyCastle.Crypto.Macs.HMac(new Org.BouncyCastle.Crypto.Digests.Sha256Digest());
                hmac.Init(new KeyParameter(Encoding.UTF8.GetBytes(key)));
                byte[] result = new byte[hmac.GetMacSize()];
                byte[] bytes = Encoding.UTF8.GetBytes(text);

                hmac.BlockUpdate(bytes, 0, bytes.Length);
                hmac.DoFinal(result, 0);

                return result;
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }

            return null;
        }

    }
}