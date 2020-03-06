using NUnit.Framework;

namespace AttributesDemo.Tests.DataDrivenTests
{  
    [TestFixture]
    public class ClassWithIntermittentBugTests
    {        
        [Test]
        [Repeat(10)]
        public void ShouldDoWork()
        {
            var sut = new ClassWithIntermittentBug();

            sut.DoWork();            
        }
    }
}
