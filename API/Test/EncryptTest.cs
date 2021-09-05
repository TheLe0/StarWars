using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class EncryptTest
    {
        private string EnhancedHashPassword;
        private string PlainText;

        [TestInitialize]
        public void Initialize()
        {
            this.PlainText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            this.EnhancedHashPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(this.PlainText);
        }

        [TestMethod]
        public void TestCompareEncryption()
        {
            var validatePassword = BCrypt.Net.BCrypt.EnhancedVerify(
                this.PlainText,
                this.EnhancedHashPassword
            );

            Assert.AreEqual(true, validatePassword);
        }
    }
}
