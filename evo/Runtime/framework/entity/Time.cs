
using System.Runtime.InteropServices;
namespace Evo
{
    /// <summary>
    /// Time struct
    /// </summary>
    [System.Serializable]
    [StructLayout(LayoutKind.Sequential)]
    public struct Time : System.IEquatable<Time>
    {
        /// <summary>
        /// 
        /// </summary>
        public long time;

        public Time(long time)
        {
            this.time = time;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Equals(Time other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return other.time == this.time;
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
            return this.time.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator ==(Time left, Time right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool operator !=(Time left, Time right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            return time.ToString();
        }
    }
}

