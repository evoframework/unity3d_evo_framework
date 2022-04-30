using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public class IuCryptSha : UObject
    {
        /// <summary>
        /// 
        /// </summary>
        public static string GenerateSha256(string _str)
        {
            try
            {
                return IuConvert.ToHex(GenerateSha256Raw(_str));
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        public static byte[] GenerateSha256Raw(string _str)
        {
            try
            {
                //SHA512 sha = new SHA512Managed();

                var sha = new SHA256Managed();
                byte[] arrayHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(_str));
                return arrayHash;
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
        public static string GenerateSha256(byte[] _arrayByte)
        {
            try
            {
                var sha = new SHA256Managed();
                byte[] arrayHash = sha.ComputeHash(_arrayByte);
                return IuConvert.ToHex(arrayHash);
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
        public static string GenerateSha512(string _str)
        {
            try
            {
                SHA512 sha = new SHA512Managed();
                byte[] arrayHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(_str));
                return IuConvert.ToHex(arrayHash);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }
    }
}