using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace encoder.Encoders
{
    public class Baudot_Continental : IEncoder
    {
        public string Name { get => "Baudot Continental"; }

        public List<char> EncodablePrintSymbols => throw new NotImplementedException();

        public List<char> EncodableControlSymbols => chars.Keys.ToList();

        public int MaxBits => 5;

        private Dictionary<char, EncodedSymbol> chars = new Dictionary<char, EncodedSymbol>();
        private Dictionary<EncodedSymbol,char> encoded = new Dictionary<EncodedSymbol, char>();

        private void BuildLookUp(EncodedSymbol t, char symbol)
        {
            Debug.Assert(this.chars.ContainsKey(symbol) == false
               && this.encoded.ContainsKey(t) == false);

            this.chars[symbol] = t;
            this.encoded[t] = symbol;
        }
        public Baudot_Continental()
        {
            BuildLookUp( new EncodedSymbol(0b00100,5), 'A');
            BuildLookUp( new EncodedSymbol(0b00110,5), 'É');
            BuildLookUp( new EncodedSymbol(0b00010,5), 'E');
            BuildLookUp( new EncodedSymbol(0b00011,5), 'I');
            BuildLookUp( new EncodedSymbol(0b00111,5), 'O');
            BuildLookUp( new EncodedSymbol(0b00101,5), 'U');
            BuildLookUp( new EncodedSymbol(0b00001,5), 'Y');
            BuildLookUp( new EncodedSymbol(0b01001,5), 'B');
            BuildLookUp( new EncodedSymbol(0b01101,5), 'C');
            BuildLookUp( new EncodedSymbol(0b01111,5), 'D');
            BuildLookUp( new EncodedSymbol(0b01011,5), 'F');
            BuildLookUp( new EncodedSymbol(0b01010,5), 'G');
            BuildLookUp( new EncodedSymbol(0b01110,5), 'H');
            BuildLookUp( new EncodedSymbol(0b01100,5), 'J');
            BuildLookUp( new EncodedSymbol(0b11100,5), 'K');
            BuildLookUp( new EncodedSymbol(0b11110,5), 'L');
            BuildLookUp( new EncodedSymbol(0b11010,5), 'M');
            BuildLookUp( new EncodedSymbol(0b11011,5), 'N');
            BuildLookUp( new EncodedSymbol(0b11111,5), 'P');
            BuildLookUp( new EncodedSymbol(0b11101,5), 'Q');
            BuildLookUp( new EncodedSymbol(0b11001,5), 'R');
            BuildLookUp( new EncodedSymbol(0b10001,5), 'S');
            BuildLookUp( new EncodedSymbol(0b10101,5), 'T');
            BuildLookUp( new EncodedSymbol(0b10111,5), 'V');
            BuildLookUp( new EncodedSymbol(0b10011,5), 'W');
            BuildLookUp( new EncodedSymbol(0b10010,5), 'X');
            BuildLookUp( new EncodedSymbol(0b10110,5), 'Z');
            BuildLookUp( new EncodedSymbol(0b10100,5), '-');
            BuildLookUp( new EncodedSymbol(0b10000,5), ' '); 
        }


        public string Decode(BitArray encoded)
        {
            int charCount = encoded.Length / MaxBits;
            StringBuilder sb = new StringBuilder(charCount);

            int arIt = 0;
            for(int cIt = 0; cIt < charCount; cIt++)
            {
                bool[] t = new bool[MaxBits];
                for(int bT = 0; bT <= MaxBits - 1; bT++)
                {
                    t[bT] = encoded[arIt + bT];
                }
                EncodedSymbol es = new EncodedSymbol(t);
                arIt += MaxBits;
                sb.Append(this.encoded[es]);
                
            }
            return sb.ToString();
        }

        public BitArray Encode(string message)
        {
            BitArray retr = new BitArray(message.Length * MaxBits, false);

            int arIt = 0;
            for(int charC = 0; charC < message.Length; charC++)
            {
                char c = message[charC];
                BitArray t = Utils.ConvertBoolArrayToBitArray(this.chars[c].Bits);
                for(int it = 0; it <= MaxBits - 1; it++)
                {
                    retr[arIt + it] = t[it];
                }
                arIt += MaxBits;
            }
            return retr;
        }
    }
}
