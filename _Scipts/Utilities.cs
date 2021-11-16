using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace f5_oop
{
    class Utilities
    {
        public static string ReadString(string prompt)
        {
            string tempStr = "";

            do
            {
                Console.WriteLine(prompt);
                tempStr = Console.ReadLine();
            } while (string.IsNullOrEmpty(tempStr) || string.IsNullOrWhiteSpace(tempStr));

            return tempStr;
        }

        public static bool WaitForEnter()
        {
            ConsoleKeyInfo ckInfo;
            while (true)
            {
                Console.WriteLine("Press ENTER to continue.");
                ckInfo = Console.ReadKey(false);

                if (ckInfo.Key == ConsoleKey.Enter)
                {
                    //Continue to the next round
                    Utilities.PrintSeparatorLines();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void PrintSeparatorLines()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
}
