using System;
using NUnit.Framework;

namespace AttributesDemo.Tests.SomeNamespace
{
    [SetUpFixture]
    public class SetUpFixtureForSpecificNamespace
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTestsInSomeNamespace()
        {
            Console.WriteLine("#### Before any tests in SomeNamespace");
        }

        [OneTimeTearDown]
        public void RunAfterAnyTestsInSomeNamespace()
        {
            Console.WriteLine("#### After all tests in SomeNamespace");
        }
    }
}
