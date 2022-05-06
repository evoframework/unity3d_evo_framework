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
    public static class IuTime
    {

        /// <summary>
        /// Gets a Unix timestamp representing the current moment
        /// </summary> 
        /// <returns>Now expressed as a Unix timestamp</returns>
        public static long UnixTimestamp()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }

        /// <summary>
        /// Gets a Unix timestamp representing the current moment
        /// </summary>
        /// <returns>Now expressed as a Unix timestamp</returns>
        public static long UnixTimestampMilliseconds()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
        }
    }
}