using System;
using Evo;

namespace EvoTest
{
    [System.Serializable]
    public class EObjectTest : EObject
    {
        public Int64 propertyInt;
        public long propertyLong;
        public string propertyStr;
        public bool propertyBool;
        public double propertyDouble;


        override public void ToStream(System.IO.Stream stream)
        {
            base.ToStream(stream);
          //  this.DoWrite(propertyInt, stream);
         //   this.DoWrite(propertyLong, stream);
            this.DoWrite(propertyStr, stream);
            this.DoWrite(propertyBool, stream);
            this.DoWrite(propertyDouble, stream);

        }

        override public void FromStream(System.IO.Stream stream)
        {
            base.FromStream(stream);
         //   this.propertyInt = this.DoReadInt(stream);
          //  this.propertyLong = this.DoReadLong(stream);
            this.propertyStr = this.DoReadString(stream);
            this.propertyBool = this.DoReadBool(stream);
            this.propertyDouble = this.DoReadDouble(stream);
        }

    }
}