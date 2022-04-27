using UnityEngine;
using System.Collections;
using System.Security.Cryptography;

namespace Evo
{
    public class IuCryptSha : UObject
    {

        public static string GenerateMd5(string str)
        {
            try
            {
                //SHA512 sha = new SHA512Managed();
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] arrayHash = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
                return IuConvert.ToHex(arrayHash);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        public static string GenerateSha1(string str)
        {
            try
            {
                //SHA512 sha = new SHA512Managed();

                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] arrayHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
                return IuConvert.ToHex(arrayHash);

            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        public static string GenerateSha256(string str)
        {
            try
            {
                //SHA512 sha = new SHA512Managed();

                var sha = new SHA256Managed();
                byte[] arrayHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
                return IuConvert.ToHex(arrayHash);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        public static string GenerateSha256(byte[] arrayByte)
        {
            try
            {
                var sha = new SHA256Managed();
                byte[] arrayHash = sha.ComputeHash(arrayByte);
                return IuConvert.ToHex(arrayHash);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
            return null;
        }

        public static string GenerateSha512(string str)
        {
            try
            {
                SHA512 sha = new SHA512Managed();
                byte[] arrayHash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(str));
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