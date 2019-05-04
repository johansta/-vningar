using System;
using System.Text;

namespace Övning_5_Tools
{
    public static class ConsoleWrapper
    {

        public static String ReadLine(ConsoleColor color, ConsoleColor @default = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            String input = Console.ReadLine();
            Console.ForegroundColor = @default;

            return input;
        }

        public static void Write(string sentence, ConsoleColor color, ConsoleColor @default = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(sentence);
            Console.ForegroundColor = @default;
        }

        public static void WriteLine(string sentence, ConsoleColor color, ConsoleColor @default = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(sentence);
            Console.ForegroundColor = @default;
        }

        public static void WritePreLine(string sentence, ConsoleColor color, int preLineCount = 1, ConsoleColor @default = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            WritePreLine(sentence, preLineCount);
            Console.ForegroundColor = @default;         
            
        }

        public static void WritePostLine(string sentence, ConsoleColor color, int postLineCount = 1, ConsoleColor @default = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            WritePreLine(sentence, postLineCount);
            Console.ForegroundColor = @default;
        }
       

        public static void WritePreLinePostLine(string sentence, ConsoleColor color, int preLineCount = 1, int postLineCount = 1, ConsoleColor @default = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            WritePreLinePostLine(sentence, preLineCount, postLineCount);
            Console.ForegroundColor = @default;
        }

        public static void WriteLine(string sentence, object[] parameters, ConsoleColor[] parameterColors, ConsoleColor @default = ConsoleColor.White)
        {
            Write(sentence, parameters, parameterColors, @default);
            Console.WriteLine();
        }

        public static void WritePreLine(string sentence, int preLineCount = 1)
        {
            if (preLineCount < 0)
            {
                preLineCount = 0;
            }

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < preLineCount; i++)
            {
                stringBuilder.AppendLine();
            }

            stringBuilder.Append(sentence);

            Console.Write(stringBuilder);

        }

        public static void WritePostLine(string sentence, int postLineCount = 1)
        {
            StringBuilder stringBuilder = new StringBuilder();
           
            stringBuilder.Append(sentence);

            for (int i = 0; i < postLineCount; i++)
            {
                stringBuilder.AppendLine();
            }

            Console.Write(stringBuilder);

        }

        public static void WritePreLinePostLine(string sentence, int preLineCount = 1, int postLineCount = 1)
        {           
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < preLineCount; i++)
            {
                stringBuilder.AppendLine();
            }

            stringBuilder.Append(sentence);

            for (int i = 0; i < postLineCount; i++)
            {
                stringBuilder.AppendLine();
            }

            Console.Write(stringBuilder);

        }

        public static void Write(string sentence, object[] parameters, ConsoleColor[] parameterColors, ConsoleColor @default = ConsoleColor.White)
        {
            int startIndex = 0;

            for (int i = 0; i < parameters.Length; i++)
            {
                int openingBracesIndex = sentence.IndexOf("{");

                if (openingBracesIndex == -1)
                {
                    throw new FormatException("Opening braces is missing!");
                }

                Console.ForegroundColor = @default;
                Console.Write(sentence.Substring(0, openingBracesIndex));

                Console.ForegroundColor = parameterColors[i];
                Console.Write(parameters[i]);

                int closingBracesIndex = sentence.IndexOf("}");

                if (closingBracesIndex == -1)
                {
                    throw new FormatException("Closing braces is missing!");
                }

                startIndex = closingBracesIndex + 1;
                sentence = sentence.Substring(startIndex);
            }

            Console.ForegroundColor = @default;
            Console.Write(sentence);
        }
    }
}
