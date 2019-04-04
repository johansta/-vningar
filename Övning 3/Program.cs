using Övning_3.Animals;
using Övning_3.Birds;
using Övning_3.UserErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;

namespace Övning_3
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonHandler personHandler = new PersonHandler();
            IPerson person = personHandler.CreatePerson(35, "Johan", "Svensson", 185, 75);

            personHandler.SetAge(person, 20);
            personHandler.SetFname(person, "Erik");
            personHandler.SetHeight(person, 170);
            personHandler.SetLName(person, "Andersson");
            personHandler.SetWeight(person, 100);

            Console.WriteLine(personHandler.GetAge(person));
            Console.WriteLine(personHandler.GetWeight(person));

            //Person test = null;//Priavte nested class
            //person.Age = 10;
            //person.Name = "Johan";

            /*List<Animal> animals = new List<Animal>();

            animals.Add(new Flamingo("Erik",100,20,10,true));
            animals.Add(new Dog("Erik", 100, 20, 5));
            animals.Add(new Animal("Erik", 100, 20));

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Stats());
            }

            foreach (var animal in animals)
            {
                if (animal is Dog)
                {
                    Console.WriteLine(animal.Stats());
                }
            }

            foreach (var animal in animals)
            {

                if (animal is Dog dog)
                {
                    Console.WriteLine(dog.FavoritCandy());
                }
          
                if (animal is Dog)
                {
                    Dog dog = animal as Dog;

                    Console.WriteLine(dog.FavoritCandy());
                }

        }*/

            /*List<UserError> userErrors = new List<UserError>();

            userErrors.Add(new EmptyInputError());
            userErrors.Add(new NumericInputError());
            userErrors.Add(new TextInputError());
            userErrors.Add(new LengthInputError());
            userErrors.Add(new ShortInputError());

            foreach (var userError in userErrors)
            {
                Console.WriteLine(userError.UEMessage());
            }*/

            Console.ReadKey();
        }
    }
}
