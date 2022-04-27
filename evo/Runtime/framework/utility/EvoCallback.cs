using System;
namespace Evo
{
    [System.Serializable]
    public delegate void EvoCallback();

    [System.Serializable]
    public delegate void EvoCallback<T>(T arg1);
}