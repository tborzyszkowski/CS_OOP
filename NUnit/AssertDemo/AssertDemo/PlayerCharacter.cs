using System;
using System.Collections.Generic;

namespace AssertDemo {
	public class PlayerCharacter {
		public PlayerCharacter() {
			Name = GenerateName();
			IsNoob = true;
			CreateStartingWeapons();
		}
		public int Health { get; set; }
		public string Name { get; private set; }
		public string NickName { get; set; }
		public bool IsNoob { get; set; }
		public List<string> Weapons { get; set; }

		public void Sleep() {
			var rnd = new Random();

			var healthIncrease = rnd.Next(1, 101);

			Health += healthIncrease;
		}

		public void TakeDamage(int damage) {
			Health = Math.Max(1, Health -= damage);
		}

		private string GenerateName() {
			var names = new[]
			{
				"Danieth",
				"Derick",
				"Shalnorr",
				"G'Toth'lop",
				"Boldrakteethtop"
			};
			return names[new Random().Next(0, names.Length)];
		}

		private void CreateStartingWeapons() {
			Weapons = new List<string>()
					  {
						  "Long Bow",
						  "Short Bow",
						  "Short Sword", 
                          //"",
                
                          // "Long Bow",
                          // "Staff Of Wonder"
                      };
		}
	}
}