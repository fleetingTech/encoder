﻿using encoder.Encoders;
using System;
using System.Collections;

namespace encoder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            encoder.Encoders.Baudot_Continental bc = new encoder.Encoders.Baudot_Continental();
            string test = "Hi".ToUpper();
            BitArray msg = bc.Encode(test);
            string retr = bc.Decode(msg);
            return;
        }
    }
}
