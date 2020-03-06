using System;
using NUnit.Framework;

namespace AttributesDemo.Tests.SomeOtherNamespace
{  
    [TestFixture]
    public class TestsInAnotherNamespace
    {        
        [Test]
        public void TestA()
        {
            Console.WriteLine("In test: {0}", TestContext.CurrentContext.Test.Name);
        }

        [Test]
        public void TestB()
        {
            Console.WriteLine("In test: {0}", TestContext.CurrentContext.Test.Name);
        }
    }
}
