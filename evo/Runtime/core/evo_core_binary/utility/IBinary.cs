using System;

namespace Evo
{
    public interface IBinary
    {
        void ToStream(System.IO.Stream stream);

        void FromStream(System.IO.Stream stream);
    }
}