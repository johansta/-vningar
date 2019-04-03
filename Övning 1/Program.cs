using System;

namespace Övning_1
{
    class Program
    {
        enum MenuOptions {Default,Lagra, Lista, Avsluta};

        static Company company = new Company("Electrolux");

        static void setupTestData()
        {
            Employee employee = new Employee("Johan", 25000);
            Employee employee2 = new Employee("Erik", 15000);
            Employee employee3 = new Employee("Jan", 35000);
            Employee employee4 = new Employee("Sten", 45000);

            company.getRegister().add(employee);
            company.getRegister().add(employee2);
            company.getRegister().add(employee3);
            company.getRegister().add(employee4);

        }

        static void Main(string[] args)
        {
            setupTestData();

            while (true)
            {
                Console.WriteLine("{0} - Personalregister\n", company.getName());
                Console.WriteLine("Register funktioner: \n1.Lagra anställd \n2.Lista anställda \n3 Avsluta program");
                Console.WriteLine("\nMata in 1,2 eller 3");

                MenuOptions selectedOption = MenuOptions.Default;

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();

                if (char.IsDigit(consoleKeyInfo.KeyChar))
                {
                    selectedOption = (MenuOptions)int.Parse(consoleKeyInfo.KeyChar.ToString());
                }

                if (selectedOption == MenuOptions.Lagra)
                {
                    Console.WriteLine("\nMata in namn:");
                    String name = Console.ReadLine();

                    Console.WriteLine("\nMata in lön:");
                    int salary = int.Parse(Console.ReadLine());

                    Employee employee = new Employee(name, salary);
                    company.getRegister().add(employee);
                }
                else if (selectedOption == MenuOptions.Lista)
                {
                    Console.WriteLine("\nLista på anställda:");
                    company.getRegister().list();
                    Console.WriteLine("\n\n");
                }
                else if (selectedOption == MenuOptions.Avsluta)
                {
                    break;
                }
                else
                {
                    throw new ArgumentException();
                }
            }

        }
    }
}
