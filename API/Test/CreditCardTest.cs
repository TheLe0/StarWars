using API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class CreditCardTest
    {
        private CreditCard creditCard;

        [TestInitialize]
        public void Initialize()
        {
            this.creditCard = new();
        }


        [TestMethod]
        public void TestCardNumberFormat()
        {
            this.creditCard.CardNumber = "1234123412341234";
            string formatedCardNumber = "**** **** **** 1234";

            Assert.AreEqual(true, this.creditCard.CardNumber.Equals(formatedCardNumber));
        }

    }
}
