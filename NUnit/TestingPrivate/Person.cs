using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingPrivate {
	public class Person {
		private string _firstName { get; set; }
		private string _lastName { get; set; }

		public Person(string firstName, string lastName) {
			_firstName = firstName;
			_lastName = lastName;
		}

		public string PersonText() {
			if (string.IsNullOrEmpty(_firstName))
				throw new MissingFirstNameException();

			return this.PersonText(_firstName, _lastName);
		}

		private string PersonText(string firstName, string lastName) {
			return $"Person {firstName} {lastName} !";
		}

	}
}
