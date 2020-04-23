using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using encoder;
using System.Linq;

namespace encoder_test
{
    [TestClass]
    public class Utils_Test
    {
        [TestMethod]
        public void Test_ConvertByteToBitArray()
        {
            BitArray result = Utils.ConvertByteToBitArray(0b01);
            BitArray expected = new BitArray(8, false);
            expected[0] = true;

            result.Xor(expected);
            for(var counter = 0; counter < result.Length; counter++)
            {
                Assert.IsFalse(result[counter]);
            }
        }
    }
}
