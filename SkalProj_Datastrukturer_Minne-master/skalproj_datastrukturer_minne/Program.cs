using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {

        static String InvalidInputMessage = $"Invalid input try again:{Environment.NewLine}";

        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {

                WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Clear();
                    WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        return;
                    default:
                        WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();
            bool running = true;

            while (running)
            {
                String input = null;

                WriteLine("'+value' to add element to list");
                WriteLine("'-value' to remove element from list");
                WriteLine("'e' to exit to main menu");

                try
                {
                    input = Console.ReadLine();
                }
                catch (Exception)
                {

                    WriteLine(InvalidInputMessage);
                    continue;
                }

                if (String.IsNullOrWhiteSpace(input))
                {
                    WriteLine(InvalidInputMessage);
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);




                switch (nav)
                {
                    case '+':

                        if (String.IsNullOrWhiteSpace(value))
                        {
                            WriteLine(InvalidInputMessage);
                            continue;
                        }

                        theList.Add(value);
                        break;
                    case '-':

                        if (String.IsNullOrWhiteSpace(value))
                        {
                            WriteLine(InvalidInputMessage);
                            continue;
                        }

                        theList.Remove(value);
                        break;
                    case 'e':
                        running = false;
                        break;
                    default:
                        continue;
                }

                WriteLine("Number of elements: " + theList.Count + " Current capacity " + theList.Capacity);

                WriteLine("Current list: ");

                if (theList.Count == 0)
                {
                    WriteLine("List is empty");
                }
                else
                {
                    foreach (var item in theList)
                    {
                        WriteLine(item);
                    }
                }

                Write(Environment.NewLine);
            }

        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Queue<string> theQueue = new Queue<string>();
            bool running = true;

            while (running)
            {
                String input = null;

                WriteLine("'+value' to add element to que");
                WriteLine("'-' to remove element from que");
                WriteLine("'e' to exit to main menu" + Environment.NewLine);

                try
                {
                    input = Console.ReadLine();
                }
                catch (Exception)
                {

                    WriteLine(InvalidInputMessage);
                    continue;
                }

                if (String.IsNullOrEmpty(input))
                {
                    WriteLine(InvalidInputMessage);
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':

                        if (String.IsNullOrEmpty(value))
                        {
                            WriteLine(InvalidInputMessage);
                            continue;
                        }

                        theQueue.Enqueue(value);
                        break;
                    case '-':

                        if (theQueue.Count != 0)
                        {
                            theQueue.Dequeue();
                        }
                        else
                        {
                            WriteLine("Invalid command, queue is already empty!");
                        }

                        break;
                    case 'e':
                        running = false;
                        break;
                    default:
                        continue;               
                }

                WriteLine("Number of elements: " + theQueue.Count);

                WriteLine("Current queue: ");

                foreach (var item in theQueue)
                {
                    WriteLine(item);
                }
            }


        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            Stack<String> theStack = new Stack<String>();
            bool running = true;

            while (running)
            {
                String input = null;

                WriteLine("'+value' to push element to stack");
                WriteLine("'-' to pop element from stack");
                WriteLine("'rvalue' to reverse string using the stack");
                WriteLine("'e' to exit to main menu");

                try
                {
                    input = Console.ReadLine();
                }
                catch (Exception)
                {

                    WriteLine(InvalidInputMessage);
                    continue;
                }

                if (String.IsNullOrWhiteSpace(input))
                {
                    WriteLine(InvalidInputMessage);
                    continue;
                }

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':

                        if (String.IsNullOrWhiteSpace(value))
                        {
                            WriteLine(InvalidInputMessage);
                            continue;
                        }

                        theStack.Push(value);
                        break;
                    case '-':

                        if (theStack.Count == 0)
                        {
                            WriteLine("Stack is empty");
                        }
                        else
                        {
                            theStack.Pop();
                        }
                        break;
                    case 'r':

                        for (int i = 0; i < value.Length; i++)
                        {
                            theStack.Push(value[i].ToString());
                        }

                        WriteLine("Reversed string: ");

                        for (int i = 0; i < value.Length; i++)
                        {
                            Write(theStack.Pop());
                        }

                        break;
                    case 'e':
                        running = false;
                        break;
                    default:
                        continue;
                }

                WriteLine(Environment.NewLine + "Number of elements on stack: " + theStack.Count);

                WriteLine("Current stack: ");

                if (theStack.Count == 0)
                {
                    WriteLine("Stack is empty");
                }
                else
                {
                    foreach (var item in theStack)
                    {
                        WriteLine(item);
                    }

                }

                Write(Environment.NewLine);
            }

        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})]
             * Example of incorrect: (()]), [), {[()}]
             */

            Dictionary<char, char> paranthesisOpenToClose = new Dictionary<char, char>();

            paranthesisOpenToClose.Add('{', '}');
            paranthesisOpenToClose.Add('(', ')');
            paranthesisOpenToClose.Add('[', ']');

            Dictionary<char, char> paranthesisCloseToOpen = new Dictionary<char, char>();

            paranthesisCloseToOpen.Add('}', '{');
            paranthesisCloseToOpen.Add(')', '(');
            paranthesisCloseToOpen.Add(']', '[');

            bool running = true;

            while (running)
            {
                Stack<char> theStack = new Stack<char>();

                String input = null;

                ForegroundColor = ConsoleColor.White;
                WriteLine("'+value' to check if value is wellformed'");
                WriteLine("'e' to exit to main menu");

                try
                {
                    input = Console.ReadLine();
                }
                catch (Exception)
                {

                    WriteLine(InvalidInputMessage);
                    continue;
                }

                if (String.IsNullOrWhiteSpace(input))
                {
                    WriteLine(InvalidInputMessage);
                    continue;
                }

                bool valid = true;

                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':

                        if (String.IsNullOrWhiteSpace(value))
                        {
                            WriteLine(InvalidInputMessage);
                            continue;
                        }

                        for (int i = 0; i < value.Length; i++)
                        {
                            char item = value[i];

                            if (paranthesisCloseToOpen.ContainsValue(item))//Opening paranthesis stored in keys 
                            {
                                theStack.Push(item);

                            }
                            else if (paranthesisCloseToOpen.ContainsKey(item))//Closing paranthesis stored in values
                            {
                                if (theStack.Count == 0)
                                {
                                    ForegroundColor = ConsoleColor.White;
                                    Write("Malformed input. Expected opening paranthesis before ");
                                    ForegroundColor = ConsoleColor.Red;
                                    WriteLine(item);

                                    valid = false;
                                    break;
                                }
                                else if (!paranthesisCloseToOpen[item].Equals(theStack.Peek()))
                                {
                                    ForegroundColor = ConsoleColor.White;
                                    Write("Malformed input. Expected " + paranthesisOpenToClose[theStack.Peek()].ToString() + " got ");
                                    ForegroundColor = ConsoleColor.Red;
                                    WriteLine(item);

                                    WriteAndHighLightCharacter(i,value);

                                    valid = false;
                                    break;
                                }

                                theStack.Pop();
                            }

                            
                        }

                        if (theStack.Count != 0)
                        {
                            ForegroundColor = ConsoleColor.White;
                            Write("Malformed input. Expected closing parantesis for ");
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine(theStack.Peek());
                        }else if (valid)
                        {
                            ForegroundColor = ConsoleColor.Green;
                            WriteLine("Validation complete! Input was wellformed");
                        }
                 
                        break;
                    case 'e':
                        running = false;
                        break;
                    default:
                        WriteLine("Unknown option, try again!");
                        continue;
                }         
            }
        }

        static void WriteAndHighLightCharacter(int index, String text)
        {
            for (int j = 0; j < text.Length; j++)
            {
                ForegroundColor = ConsoleColor.White;

                if (j == index)
                {
                    ForegroundColor = ConsoleColor.Red;
                }

                Write(text[j]);
            }

            WriteLine();
        }
    }

}
