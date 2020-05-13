using MailSender.lib.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailsender.lib.Tests.Service
{
    [TestClass]
    public class TestEndoderTests
    {
        [TestMethod]
        public void Encode_ABC_to_BCD_with_key_1()
        {
            const string str = "ABC";
            const int key = 1;
            const string expected_str = "BCD";

            var actual_str = TestEncoder.Encode(str, key);

            Assert.AreEqual(expected_str, actual_str);
        }

        [TestMethod]
        public void Decode_BCD_to_ABC_with_key_1()
        {
            const string str = "BCD";
            const int key = 1;
            const string expected_str = "ABC";

            var actual_str = TestEncoder.DeCode(str, key);

            Assert.AreEqual(expected_str, actual_str);
        }
    }
}
