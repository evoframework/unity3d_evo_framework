using System;
using System.Runtime.InteropServices;
namespace Evo
{
    /// <summary>
    /// Id struct
    /// </summary>
    [System.Serializable]
    [StructLayout(LayoutKind.Sequential, Size = SIZE_BYTES)]
    public struct Id : IEquatable<Id>
    {
        /// <summary>
        /// 
        /// </summary>
        public const int SIZE_BYTES = 32; // 256/8


        /// <summary>
        /// 
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = SIZE_BYTES)]
        public byte[] iD;

        /// <summary>
        /// 
        /// </summary>
        public Id(byte[] iD)
        {
            this.iD = iD;
        }

        /// <summary>
        /// 
        /// </summary>
        public Id(string iD)
        {
            this.iD = System.Text.Encoding.UTF8.GetBytes(iD);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(Id other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return other.iD == this.iD;
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != typeof(Id))
            {
                return false;
            }
            return Equals((Id)obj);
        }

        /// <summary>
        /// 
        /// </summary>
        public override int GetHashCode()
        {
            return this.iD.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(Id left, Id right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(Id left, Id right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return System.Text.Encoding.UTF8.GetString(iD);
        }
    }
}

