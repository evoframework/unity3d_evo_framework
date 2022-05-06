using System;
using Evo;
using EvoTest;
using NUnit.Framework;
using UnityEngine;


public class TECoreSerialize
{
    readonly bool isLogVerbose = true;

    readonly int countLoop = 1;

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TSerializeEObjectArrayByte()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {

            int intRand = UnityEngine.Random.Range(0, Int32.MaxValue);

            var eObjectTest0 = new EObjectTest
            {
                iD = IuKey.ToId("iD" + intRand),
                time = IuTime.UnixTimestamp(),
                propertyString = "propertyStr" + intRand,
                propertyInt = intRand,
                propertyLong = long.MaxValue,
                propertyFloat = UnityEngine.Random.Range(0, float.MaxValue),
                propertyChar = 'A',
                propertyByteArray = System.Text.Encoding.UTF8.GetBytes("propertyByteArray" + intRand),
                propertBool = true,
               propertyDouble = double.MaxValue
            };

            var arrayByte0 = eObjectTest0.ToArrayByte();

            var eObjectTest1 = new EObjectTest();

            eObjectTest1.FromArrayByte(arrayByte0);

            var arrayByte1 = eObjectTest1.ToArrayByte();

            Debug.Log(arrayByte0.Length + " " + arrayByte1.Length + "\n\n" + IuConvert.ToHex(arrayByte0) + "\n\n" + IuConvert.ToHex(arrayByte1));

            Debug.Log(eObjectTest0.propertyDouble + " " + eObjectTest1.propertyDouble);

            Assert.AreEqual(eObjectTest0.iD, eObjectTest1.iD);
            Assert.AreEqual(eObjectTest0.time, eObjectTest1.time);
            Assert.AreEqual(eObjectTest0.propertyString, eObjectTest1.propertyString);
            Assert.AreEqual(eObjectTest0.propertyInt, eObjectTest1.propertyInt);
            Assert.AreEqual(eObjectTest0.propertyLong, eObjectTest1.propertyLong);
            Assert.AreEqual(eObjectTest0.propertyFloat, eObjectTest1.propertyFloat);
            Assert.AreEqual(eObjectTest0.propertyChar, eObjectTest1.propertyChar);
            Assert.AreEqual(eObjectTest0.propertyByteArray, eObjectTest1.propertyByteArray);
            Assert.AreEqual(eObjectTest0.propertBool, eObjectTest1.propertBool);
            Assert.AreEqual(eObjectTest0.propertyDouble, eObjectTest1.propertyDouble);
            Assert.AreEqual(arrayByte0, arrayByte1);


        }, "title");
    }

    /// <summary>
    /// 
    /// </summary>
    [Test]
    public void TSerializeEStructBytePtr()
    {
        IuLog.isVerbose = isLogVerbose;
        int intRand = UnityEngine.Random.Range(0, Int32.MaxValue);
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
          {
              var eObjectTest0 = new EObjectStructTest
              {
                  iD = IuKey.ToId("iD" + intRand),
                  time = IuTime.UnixTimestamp(),
                  propertyString = "propertyStr" + intRand,
                  propertyInt = intRand,
                  propertyLong = long.MaxValue,
                  propertyFloat = UnityEngine.Random.Range(0, float.MaxValue),
                  propertyChar = 'B',
                  propertyByteArray = System.Text.Encoding.UTF8.GetBytes("propertyByteArray".PadLeft(64,'_')),
                  propertBool = true,
                  propertyDouble = double.MaxValue
              };

              if (isLogVerbose) Debug.Log(eObjectTest0.ToString());

              var arrayByte0 = IuSerialize.ToBytePtr(eObjectTest0);

              var eObjectTest1 = IuSerialize.FromBytePtr<EObjectStructTest>(arrayByte0);

              var arrayByte1 = IuSerialize.ToBytePtr(eObjectTest1);
              if (isLogVerbose) Debug.Log(IuConvert.ToHex(arrayByte0) + "|\n" + IuConvert.ToHex(arrayByte1) + "|");
              if (isLogVerbose) Debug.Log(IuConvert.ToBase64(arrayByte0));

              Assert.AreEqual(eObjectTest0.iD, eObjectTest1.iD);
              Assert.AreEqual(eObjectTest0.time, eObjectTest1.time);
              Assert.AreEqual(eObjectTest0.propertyString, eObjectTest1.propertyString);
              Assert.AreEqual(eObjectTest0.propertyInt, eObjectTest1.propertyInt);
              Assert.AreEqual(eObjectTest0.propertyLong, eObjectTest1.propertyLong);
              Assert.AreEqual(eObjectTest0.propertyFloat, eObjectTest1.propertyFloat);
              Assert.AreEqual(eObjectTest0.propertyChar, eObjectTest1.propertyChar);
              Assert.AreEqual(eObjectTest0.propertyByteArray, eObjectTest1.propertyByteArray);
              Assert.AreEqual(eObjectTest0.propertBool, eObjectTest1.propertBool);
              Assert.AreEqual(eObjectTest0.propertyDouble, eObjectTest1.propertyDouble);
              Assert.AreEqual(arrayByte0, arrayByte1);

            

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
             //From TSerializeEStructBytePtr()
             var base64 =
             "OQBCADEANwBBADgAMQA3AEUAMAA2ADMANABBADQANQBBADMAOQA4AEIARgA5AEYANgAxADIAQwAwAEYAQgA2AEIAOQBEADIARgA1ADYAQQBCADgAMwBDAEYARQAwADQARAAwAEUAMgBDADUARAA4AEMANQBFADcAQwA3ADAANwAAAP//AAAAAM2PcmIAAAAANqYyFdu1Vn9wAHIAbwBwAGUAcgB0AHkAUwB0AHIAMwA1ADUANgA0ADAAOAA4ADYAAAC2LP0HAKAB4rYsAAAAAP////9JAAAAAAAAAAAAAAAAAAAAAAAA4FYctiz9BwAACwAAAAAAAAABAAAAAAAAAAAAAAAAAAAAAAAAAP////9LAAAAAAAAABkAAAAAAAAA/////////38gX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19fX19wcm9wZXJ0eUJ5dGVBcnJheX62LAEAAAD////////vfw==";
             var arrayByte = IuConvert.FromBase64(base64);
             var eObjectTest2 = IuSerialize.FromBytePtr<EObjectStructTest>(arrayByte);

             if (isLogVerbose) Debug.Log("size" + arrayByte.Length);
             if (isLogVerbose) Debug.Log(eObjectTest2.iD);
             if (isLogVerbose) Debug.Log(eObjectTest2.time);
             if (isLogVerbose) Debug.Log(eObjectTest2.propertyString);
             if (isLogVerbose) Debug.Log(eObjectTest2.propertyInt);
             if (isLogVerbose) Debug.Log(eObjectTest2.propertyLong);
             if (isLogVerbose) Debug.Log(eObjectTest2.ToString());
         }

     , "title");
    }

}
