using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using encoder.Encoders;
using System.Linq;

namespace encoder_test
{
    [TestClass]
    public class Baudot_Continental_Test
    {
        [TestMethod]
        public void basic()
        {
            encoder.Encoders.Baudot_Continental bc = new encoder.Encoders.Baudot_Continental();
            string test = "Hi".ToUpper();
            BitArray msg = bc.Encode(test);
            string retr = bc.Decode(msg);
            StringAssert.Equals(test, retr);
        }
    }
}
