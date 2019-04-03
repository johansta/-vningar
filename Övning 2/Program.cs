using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Du har kommit till huvudmenyn och du navigerar genom att skriva in siffror för att testa olika funktioner.");

            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMata in en siffra för att testa en specifik funktion.");

                String selectedOption = Console.ReadLine();

                switch (selectedOption)
                {
                    case "0":
                        {
                            Console.WriteLine("Programmet avslutas");
                            running = false;
                        }break;
                    case "1":
                        {
                            Console.WriteLine("\nMata in ålder:");

                            int age; 
                            bool result = false;

                            //Validation for age input
                            do
                            {
                                result = int.TryParse(Console.ReadLine(), out age);

                                if(!result || age < 0)
                                {
                                    Console.WriteLine("\nOgilltigt värde försök igen:");
                                }

                            } while (!result || age < 0);

                            String output = null;

                            if (age < 20)
                            {
                                output = "Ungdomspris: 80kr";
                            }
                            else if (age > 64)
                            {
                                output = "Pensionärspris: 90kr";
                            }
                            else
                            {
                                output = "Standardpris: 120kr";
                            }

                            Console.WriteLine("\n" + output);

                        }break;
                    case "2":
                        {
                            Console.WriteLine("Mata in en godtycklig text som kommer att upprepas 10 gånger");

                            String input = Console.ReadLine();

                            for (int i = 0; i < 10; i++)
                            {
                                Console.Write(input);
                            }

                        }break;
                    case "3":
                        {
                            Console.WriteLine("Ange en mening med minst 3 ord. Det sista ordet kommer att plockas ut och skrivas ut.");
                            String[] result;

                            //Validation for sentence input
                            do
                            {
                                String input = Console.ReadLine();
                                result = input.Split(' ');

                                if (result.Length < 3)
                                {
                                    Console.WriteLine("\nOgilltigt värde försök igen:");
                                }

                            } while (result.Length < 3);

                            Console.WriteLine(result[2]);
                        }
                        break;
                    default:
                    {
                        Console.WriteLine("Felaktig alternativ");
                    }break;
                };                
            }
        }
    }
}
