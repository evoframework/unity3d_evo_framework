using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Runtime.InteropServices;
using System;
using System.IO;
using Evo;
using EvoTest;


public class TECoreSerialize
{
    readonly bool isLogVerbose = false;

    readonly int countLoop = 10000;

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TSerializeEObjectArrayByte()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            var eObjectTest0 = new EObjectTest
            {
                iD = "0123456789str",
                time = long.MaxValue,
                propertyStr = "propertyStr",
                propertyInt = Int64.MaxValue,
                propertyLong = long.MaxValue
            };

            var arrayByte = eObjectTest0.ToArrayByte();

            var eObjectTest1 = new EObjectTest();

            eObjectTest1.FromArrayByte(arrayByte);

            var arrayByte1 = eObjectTest1.ToArrayByte();

            Assert.AreEqual(eObjectTest0.iD, eObjectTest1.iD);
            Assert.AreEqual(eObjectTest0.time, eObjectTest1.time);
            Assert.AreEqual(eObjectTest0.propertyStr, eObjectTest1.propertyStr);
            //            Assert.AreEqual(eObjectTest0.propertyInt, eObjectTest1.propertyInt);
            Assert.AreEqual(eObjectTest0.propertyDouble, eObjectTest1.propertyDouble);

        }, "title");
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TSerializeEStructBytePtr()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
          {
              var eObjectTest0 = new EObjectStructTest
              {
                  iD = "0123456789str",
                  time = long.MaxValue,
                  propertyStr = "propertyStr",
                  propertyInt = Int64.MaxValue,
                  propertyLong = long.MaxValue
              };

              if (isLogVerbose) Debug.Log(eObjectTest0.ToString());

              var arrayByte = IuSerialize.ToBytePtr(eObjectTest0);

              var eObjectTest1 = IuSerialize.FromBytePtr<EObjectStructTest>(arrayByte);
              if (isLogVerbose) Debug.Log(eObjectTest1.iD);
              if (isLogVerbose) Debug.Log(eObjectTest1.time);
              if (isLogVerbose) Debug.Log(eObjectTest1.propertyStr);
              if (isLogVerbose) Debug.Log(eObjectTest1.propertyInt);
              if (isLogVerbose) Debug.Log(eObjectTest1.propertyLong);
              if (isLogVerbose) Debug.Log(eObjectTest1.ToString());

              var arrayByte1 = IuSerialize.ToBytePtr(eObjectTest1);
              if (isLogVerbose) Debug.Log(IuConvert.ToHex(arrayByte) + "|\n" + IuConvert.ToHex(arrayByte1) + "|");

              Assert.AreEqual(eObjectTest0.iD, eObjectTest1.iD);
              Assert.AreEqual(eObjectTest0.time, eObjectTest1.time);
              Assert.AreEqual(eObjectTest0.propertyStr, eObjectTest1.propertyStr);
              Assert.AreEqual(eObjectTest0.propertyInt, eObjectTest1.propertyInt);
              Assert.AreEqual(eObjectTest0.propertyLong, eObjectTest1.propertyLong);

          }, "title");
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TDeserializeEStructBytePtrFromBase64()
    {
        IuLog.isVerbose = isLogVerbose;

        _ = IuTimeSpan.TimeLoop(countLoop, () =>
         {
             var base64 =
             "MAAxADIAMwA0ADUANgA3ADgAOQAAAAAATwMAAAQAAAADAAAAnQUAAFUDAAAKAAAAAwAAAAcAAAAVAAAAGwAAACkAAAAvAAAAPQAAAJ0FAABWAwAADAAAAAMAAAAHAAAAFQAAABsAAAApAAAALwAAAD0AAACdAQAArQEAAJ0FAAD/////////f/////////9//////////39wAHIAbwBwAGUAcgB0AHkAUwB0AHIAAAAMAAAAnQEAAK0BAACUBQAAZgMAAAQAAAAMAAAAlAUAAGgDAAACAAAA";
             var arrayByte = IuConvert.FromBase64(base64);
             var eObjectTest2 = IuSerialize.FromBytePtr<EObjectStructTest>(arrayByte);

             if (isLogVerbose) Debug.Log("size" + arrayByte.Length);
             if (isLogVerbose) Debug.Log(eObjectTest2.iD);
             if (isLogVerbose) Debug.Log(eObjectTest2.time);
             if (isLogVerbose) Debug.Log(eObjectTest2.propertyStr);
             if (isLogVerbose) Debug.Log(eObjectTest2.propertyInt);
             if (isLogVerbose) Debug.Log(eObjectTest2.propertyLong);
             if (isLogVerbose) Debug.Log(eObjectTest2.ToString());
         }

     , "title");
    }

}
