using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Evo;
using EvoTest;
public class TRTimeSpan
{
    // A Test behaves as an ordinary method
    [Test]
    public void TRTimeSpanSimplePasses()
    {
        IuTimeSpan.TimeLoop(1000,

        () =>
        {
            Debug.Log("a");

        }


        , "title");
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TRTimeSpanWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
