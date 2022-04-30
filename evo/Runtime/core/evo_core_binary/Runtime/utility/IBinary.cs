using System;

namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBinary
    {
        /// <summary>
        /// 
        /// </summary>
        void ToStream(System.IO.Stream stream);

        /// <summary>
        /// 
        /// </summary>
        void FromStream(System.IO.Stream stream);
    }
}