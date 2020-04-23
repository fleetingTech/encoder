using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace encoder
{
    public static class Utils
    {
       public static BitArray ConvertByteToBitArray(byte source )
        {
            BitArray arr = new BitArray(8, false);
            for (byte counter = 0; counter < 8; counter++)
            {
                if((source & (1<<counter)) >= 1)
                {
                    arr[counter] = true;
                }
            }
            return arr;
        }
        public static BitArray ConvertBoolArrayToBitArray(bool[] arr)
        {
            BitArray bArr = new BitArray(arr.Length, false);
            for(int counter = 0; counter < arr.Length; counter++)
            {
                bArr[counter] = arr[counter];
            }
            return bArr;
        }
    }
}
