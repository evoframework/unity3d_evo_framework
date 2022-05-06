using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using EvoTest;
using Evo;
using System.IO;
using System;

// <summary>
/// evo_core_binary tests
/// </summary>
public class TECoreBinary
{

    readonly bool isLogVerbose = true;

    readonly int countLoop = 1;

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteInt()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            int value0 = UnityEngine.Random.Range(0, Int32.MaxValue);

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadInt(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteInt");
    }

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteChar()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            char value0 = (char) UnityEngine.Random.Range(0, 255);

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadChar(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteInt");
    }

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteString()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            string value0 = IuKey.ToId(UnityEngine.Random.Range(0, Int32.MaxValue).ToString());

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadString(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteString");
    }

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteFloat()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            float value0 = UnityEngine.Random.Range(0, float.MaxValue);

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadFloat(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteFloat");
    }

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteDouble()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            double value0 = double.MaxValue;

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadDouble(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteDouble");
    }


    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteLong()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            long value0 = long.MaxValue;

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadLong(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteLong");
    }

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteBool()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            bool value0 = true;

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadBoolean(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteBool");
    }

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteByte()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
           // int intRand = UnityEngine.Random.Range(0, Int32.MaxValue);
            byte value0 = 0x20;

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadByte(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteByte");
    }

    // <summary>
    /// 
    /// </summary>
    [Test]
    public void TEReadWriteByteArray()
    {
        IuLog.isVerbose = isLogVerbose;
        _ = IuTimeSpan.TimeLoop(countLoop, () =>
        {
            int intRand = UnityEngine.Random.Range(0, Int32.MaxValue);
            byte[] value0 = System.Text.Encoding.UTF8.GetBytes("byteArray" + intRand);

            byte[] arrayByte = null;

            using (var memoryStream = new MemoryStream())
            {
                UBinary.Instance().DoWrite(value0, memoryStream);
                memoryStream.Flush();
                arrayByte = memoryStream.ToArray();
            }

            using (var memoryStream = new MemoryStream(arrayByte))
            {
                memoryStream.Seek(0, SeekOrigin.Begin);
                var value1 = UBinary.Instance().DoReadByteArray(memoryStream);
                Assert.AreEqual(value0, value1);
            }

        }, "TEReadWriteByteArray");
    }
}
