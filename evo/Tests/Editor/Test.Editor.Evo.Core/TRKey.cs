using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Evo;
using EvoTest;
public class TRKey
{
    [Test]
    public void TRKeyToId()
    {
        IuTimeSpan.TimeLoop(100,

          () =>
          {
              EObjectStructTest eObjectTest = new EObjectStructTest();
              var iD = IuKey.GenerateId();
              eObjectTest.iD = IuKey.ToId(iD.ToString());
              Assert.AreEqual(eObjectTest.iD, iD);

          }
          , "TRKeyNewId");
    }

}
