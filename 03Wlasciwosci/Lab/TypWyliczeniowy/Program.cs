using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypWyliczeniowy {
    class Program {
        static void Main(string[] args) {
            AnimalType animal = AnimalType.Dog;
            Visibility visible = Visibility.Hidden;

            // ... Use Console.WriteLine to print out heir values.
            Console.WriteLine(animal);
            Console.WriteLine(visible);
            Console.WriteLine((int)animal);
            Console.WriteLine((int)visible);
            if (AnimalType.Cat == animal)
                Console.WriteLine("Tak");
            animal = (AnimalType) 10;
            Console.WriteLine(animal.ToString());
        }
    }
}
