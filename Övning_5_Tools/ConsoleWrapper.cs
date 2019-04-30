using System;

namespace Övning_5_Tools
{
    static class ConsoleWrapper
    {
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

                if(closingBracesIndex == -1)
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
