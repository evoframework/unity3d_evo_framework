using System;
namespace Evo
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public delegate void EvoCallback();

    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public delegate void EvoCallback<T>(T arg1);
}