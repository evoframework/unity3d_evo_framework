using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.ComponentModel;
using System;
using System.ComponentModel.Design.Serialization;

using System.Drawing;
using Evo;
using EvoTest;
using System.Reflection;

public class PointConverter : TypeConverter
{
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
        if (destinationType == typeof(InstanceDescriptor))
            return true;
        return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(ITypeDescriptorContext context,
    System.Globalization.CultureInfo culture, object value, Type destinationType)
    {
        // Insert other ConvertTo operations here.
        //
        if (destinationType == typeof(InstanceDescriptor) &&
  value is Map)
        {
            Map pt = (Map)value;

            ConstructorInfo ctor = typeof(Map).GetConstructor(
      new Type[] { typeof(int), typeof(int) });
            if (ctor != null)
            {
                return new InstanceDescriptor(ctor, new object[] { pt.Keys.Count, pt.Values.Count });
            }
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }

}






    public class TRSerializeTypeconverter
{
    // A Test behaves as an ordinary method
    [Test]
    public void TRSerializeTypeconverterSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TRSerializeTypeconverterWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
