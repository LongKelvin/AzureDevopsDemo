namespace AzureDevopsDemo.NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGlobal_Pass()
        {
            Assert.Pass();
        }
        [Test]
        public void TestGlobal_Pass1()
        {
            Assert.Pass();
        }
        [Test]
        public void TestGlobal_Pass2()
        {
            Assert.Pass();
        }
        [Test]
        public void TestGlobal_Pass3()
        {
            Assert.Pass();
        }
        [Test]
        public void TestGlobal_Pass4()
        {
            Assert.Pass();
        }
        [Test]
        public void TestGlobal_Pass5()
        {
            Assert.Pass();
        }

        [Test]
        public void TestGlobal_Failed() 
        {
            Assert.Fail();
        }
    }
}