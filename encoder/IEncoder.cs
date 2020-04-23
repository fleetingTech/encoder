using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace encoder
{
    public interface IEncoder
    {
        BitArray Encode(string message);
        string Decode(BitArray encoded);

        List<char> EncodablePrintSymbols { get; }
        List<char> EncodableControlSymbols { get; }

        int MaxBits { get; }

        string Name { get;}
    }
}
