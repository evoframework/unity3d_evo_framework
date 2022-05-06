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

public static class IuTimeExt
{
    /// <summary>
    /// Converts a given DateTime into a Unix timestamp
    /// </summary>
    /// <param name="value">Any DateTime</param>
    /// <returns>The given DateTime in Unix timestamp format</returns>
    public static long ToUnixTimestamp(this DateTime _source)
    {
        return (long)(_source.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    }

    /// <summary>
    /// Converts a given DateTime into a Unix timestamp
    /// </summary>
    /// <param name="value">Any DateTime</param>
    /// <returns>The given DateTime in Unix timestamp format</returns>
    public static long ToUnixTimestampMilliseconds(this DateTime _source)
    {
        return (long)(_source.ToUniversalTime().Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds;
    }

   
    /// <summary>
    /// Returns a local DateTime based on provided unix timestamp
    /// </summary>
    /// <param name="timestamp">Unix/posix timestamp</param>
    /// <returns>Local datetime</returns>
    public static DateTime ParseUnixTimestamp(long _timestamp)
    {
        return (new DateTime(1970, 1, 1)).AddSeconds(_timestamp).ToLocalTime();
    }

}