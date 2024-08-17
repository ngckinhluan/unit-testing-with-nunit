using NUnit.Framework;
using PrimeService; 

namespace PrimeService.Test
{
    [TestFixture] 
    public class PrimeServiceTests
    {
        private PrimeService _primeService;

        [SetUp]
        public void Setup()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void IsPrime_InputIs1_ReturnsFalse()
        {
            var result = _primeService.IsPrime(1);
            Assert.IsFalse(result, "1 is not a prime number.");
        }

        [Test]
        public void IsPrime_InputIs2_ReturnsTrue()
        {
            var result = _primeService.IsPrime(2);
            Assert.IsTrue(result, "2 is a prime number.");
        }

        [Test]
        public void IsPrime_InputIs3_ReturnsTrue()
        {
            var result = _primeService.IsPrime(3);
            Assert.IsTrue(result, "3 is a prime number.");
        }

        [Test]
        public void IsPrime_InputIs4_ReturnsFalse()
        {
            var result = _primeService.IsPrime(4);
            Assert.IsFalse(result, "4 is not a prime number.");
        }

        [Test]
        public void IsPrime_InputIsNegative_ReturnsFalse()
        {
            var result = _primeService.IsPrime(-5);
            Assert.IsFalse(result, "Negative numbers are not prime.");
        }

        [Test]
        public void IsPrime_InputIsPrimeNumber_ReturnsTrue()
        {
            var result = _primeService.IsPrime(13);
            Assert.IsTrue(result, "13 is a prime number.");
        }

        [Test]
        public void IsPrime_InputIsNonPrimeOddNumber_ReturnsFalse()
        {
            var result = _primeService.IsPrime(9);
            Assert.IsFalse(result, "9 is not a prime number.");
        }
    }
}