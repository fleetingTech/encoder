using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace encoder
{
    public class EncodedSymbol
    {
        private readonly bool[] bits;
        private static int HashSeed = "EncodedSymbol".ToArray().Sum(x => (int)x);
        private int hash = 0;

        public int Length {get => bits.Length;}

   
        public bool[] Bits { get => bits; }

        public EncodedSymbol(bool[] bits)
        {
            this.bits = bits;
        }

        public EncodedSymbol(int bits, int bitCount)
        {
            this.bits = new bool[bitCount];
            for (int counter = 0; counter < bitCount; counter++)
            {
                if ((bits & (1 << counter)) >= 1)
                {
                    this.bits[counter] = true;
                }
            }
        }

        public override bool Equals(object obj)
        {
            EncodedSymbol other = obj as EncodedSymbol;
            if (other == null)
            {
                return false;
            }

            return other.bits.SequenceEqual(this.bits);
        }

        public override int GetHashCode()
        {
            if(this.hash == 0)
            {
                for (int counter = 0; counter < this.bits.Length; counter++)
                {
                    if (this.bits[counter] == true)
                    {
                        hash++;
                    }
                    hash *= 13; //no even number, else we just bitshift
                }
            }

            return hash;
        }
    }
}
