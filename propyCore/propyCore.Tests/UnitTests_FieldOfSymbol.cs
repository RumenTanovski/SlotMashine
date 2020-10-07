using NUnit.Framework;

namespace propyCore.Tests
{
    public class Tests
    {
        private FieldOfSymbols fieldOfSymbols;

        [SetUp]
        public void Setup()
        {
            fieldOfSymbols = new FieldOfSymbols();
        }

        [TearDown]
        public void DestroyFieldOfSymbol()
        {
            fieldOfSymbols = null;
        }


        [Test]
        public void SelectSymbolIsRight()
        {
            var symbol = fieldOfSymbols.SelectSymbol();

            Assert.That(symbol, Is.AnyOf('A','B','P','*'));
        }

        [Test]
        public void RowIsRight()
        {
            var arr = fieldOfSymbols.ReturnRow();

            Assert.That(arr.Length, Is.EqualTo(3));
        }



    }
}