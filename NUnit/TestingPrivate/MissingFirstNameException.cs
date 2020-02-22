using System;

namespace TestingPrivate
{
	public class MissingFirstNameException : Exception {
		public MissingFirstNameException() : base("FirstName is missing") {
		}
	}
}