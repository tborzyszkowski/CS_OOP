using System;
using NUnit.Framework;


// Notice no containing namespace for this class

[SetUpFixture]
public class SetUpFixtureForEntireAssembly {
	[OneTimeSetUp]
	public void RunBeforeAnyTestsInEntireAssembly() {
		Console.WriteLine("!!!!! Before any tests in entire assembly");
	}

	[OneTimeTearDown]
	public void RunAfterAnyTestsInInEntireAssembly() {
		Console.WriteLine("!!!!! After all tests in entire assembly");
	}
}

