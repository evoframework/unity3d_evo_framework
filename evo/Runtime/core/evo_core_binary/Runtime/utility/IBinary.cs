// ***************************************************************
//
// Evo Framework 
//
// doc:     https://evoframework.github.io
//
// licence: Attribution-NonCommercial-ShareAlike 4.0 International
//
//****************************************************************

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