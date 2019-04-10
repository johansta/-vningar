using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Övning_4_Extra
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("RecursiveOdd");
            WriteLine("1 -> " + RecursiveOdd(1));
            WriteLine("3 -> " + RecursiveOdd(3));
            WriteLine("5 -> " + RecursiveOdd(5));

            WriteLine("RecursiveEven");
            WriteLine("1 -> " + RecursiveEven(1));
            WriteLine("3 -> " + RecursiveEven(3));
            WriteLine("5 -> " + RecursiveEven(5));

            WriteLine("RecursiveFibonacci");

            for (int i = 0; i < 10; i++)
            {
                WriteLine($"{i} -> {RecursiveFibonacci(i)}");
            }

            WriteLine("IterativeOdd");
            WriteLine("1 -> " + IterativeOdd(1));
            WriteLine("3 -> " + IterativeOdd(3));
            WriteLine("5 -> " + IterativeOdd(5));

            WriteLine("IterativeEven");
            WriteLine("1 -> " + IterativeEven(1));
            WriteLine("3 -> " + IterativeEven(3));
            WriteLine("5 -> " + IterativeEven(5));

            WriteLine("IterativeFibonacci");

            for (int i = 0; i < 10; i++)
            {
                WriteLine($"{i} -> {IterativeFibonacci(i)}");
            }

            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private static int RecursiveOdd(int n)
        {
            if(n == 0)
            {
                return 1;
            }

            return RecursiveOdd(n - 1) + 2;

        }

        private static int RecursiveEven(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return RecursiveEven(n - 1) + 2;

        }

        //F₀ = 0, F₁ = 1, and Fₙ = Fₙ₋₁ + Fₙ₋₂, for n > 1
        private static int RecursiveFibonacci(int n)
        {
            if(n == 0)
            {
                return 0;//F₀ = 0
            }
            else if(n == 1)
            {
                return 1;//F₁ = 1
            }

            //Fₙ =  Fₙ₋₁ + Fₙ₋₂ for n > 1
            return RecursiveFibonacci(n - 1) + RecursiveFibonacci(n - 2);
        }


        private static int IterativeOdd(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            int result = 1;

            for (int i = 1; i <= n; i++)
            {
                result += 2;
            }

            return result;
        }

        private static int IterativeEven(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int result = 0;

            for (int i = 1; i <= n; i++)
            {
                result += 2;
            }

            return result;
        }


        private static int IterativeFibonacci(int n)
        {
            if (n == 0)
            {
                return 0;//F₀ = 0
            }
            else if (n == 1)
            {
                return 1;//F₁ = 1
            }

            int fnMinus1 = 0;//Fₙ₋₁
            int fnMinus2 = 1;//Fₙ₋₂

            int result = 0;

            
            for (int i = 0; i < n; i++)
            {
                //Fₙ =  Fₙ₋₁ + Fₙ₋₂ for n > 1
                result = fnMinus1 + fnMinus2;

                //Update previous two values
                fnMinus2 = fnMinus1;
                fnMinus1 = result;
            }
            
            return result;
        }
    }
}
