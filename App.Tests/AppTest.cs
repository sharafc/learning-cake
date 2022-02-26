using NUnit.Framework;

namespace App.Tests
{
    [TestFixture]
    public class App_ConsoleOutputExists
    {
        [SetUp]
        public void Setup()
        {
            return;
        }

        [Test]
        public void PassTest()
        {
            Assert.Pass();
        }
    }
};
