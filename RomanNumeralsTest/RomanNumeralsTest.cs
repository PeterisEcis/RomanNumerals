using NUnit.Framework;
using RomanNumerals;

namespace RomanNumeralsTest
{
    public class RomanNumeralsTest
    {
        [Test]
        public void Roman_1_I()
        {
            var romanNumeralGenerator = new RomanNumeralGenerator();
            Assert.AreEqual("I", romanNumeralGenerator.Generate(1));
        }

        [Test]
        public void Roman_2_II()
        {
            var romanNumeralGenerator = new RomanNumeralGenerator();
            Assert.AreEqual("II", romanNumeralGenerator.Generate(2));
        }

        [Test]
        public void Roman_5_V()
        {
            var romanNumeralGenerator = new RomanNumeralGenerator();
            Assert.AreEqual("V", romanNumeralGenerator.Generate(5));
        }

        [Test]
        public void Roman_10_X()
        {
            var romanNumeralGenerator = new RomanNumeralGenerator();
            Assert.AreEqual("X", romanNumeralGenerator.Generate(10));
        }

        [Test]
        public void Roman_20_XX()
        {
            var romanNumeralGenerator = new RomanNumeralGenerator();
            Assert.AreEqual("XX", romanNumeralGenerator.Generate(20));
        }
        [Test]
        public void Roman_3999_MMMCMXCIX()
        {
            var romanNumeralGenerator = new RomanNumeralGenerator();
            Assert.AreEqual("MMMCMXCIX", romanNumeralGenerator.Generate(3999));
        }
    }
}