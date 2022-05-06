// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************

using System;
namespace Evo
{
    public static class IuKeyExt
    {

        /// <summary>
        /// ToID string extension
        /// </summary>
        /// <param name="value">string</param>
        /// <returns>sha256 of the value</returns>
        public static string ToId(this string _value)
        {
            if(_value != null)
            {
                return IuCryptSha.GenerateSha256(_value);
            }
            else
            {
                throw new Exception("not valid iD");
            }     
        }
    }
}