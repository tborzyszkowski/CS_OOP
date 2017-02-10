using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ListComparer {
    class Program {
        private static void SearchAndInsert(List<string> list,
        string insert, DinoComparer dc) {
            Console.WriteLine("\nBinarySearch and Insert \"{0}\":", insert);

            int index = list.BinarySearch(insert, dc);

            if (index < 0) {
                list.Insert(~index, insert);
            }
        }

        private static void Display(List<string> list) {
            Console.WriteLine();
            foreach (string s in list) {
                Console.WriteLine(s);
            }
        }

        static void Main(string[] args) {
            List<string> dinosaurs = new List<string>();
            dinosaurs.Add("Pachycephalosaurus");
            dinosaurs.Add("Amargasaurus");
            dinosaurs.Add("Mamenchisaurus");
            dinosaurs.Add("Deinonychus");
            Display(dinosaurs);

            DinoComparer dc = new DinoComparer();

            Console.WriteLine("\nSort with alternate comparer:");
            dinosaurs.Sort(dc);
            Display(dinosaurs);

            SearchAndInsert(dinosaurs, "Coelophysis", dc);
            Display(dinosaurs);

            SearchAndInsert(dinosaurs, "Oviraptor", dc);
            Display(dinosaurs);

            SearchAndInsert(dinosaurs, "Tyrannosaur", dc);
            Display(dinosaurs);

            SearchAndInsert(dinosaurs, null, dc);
            Display(dinosaurs);
        }
    }
}
