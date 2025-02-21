using System;
using System.Text;


namespace Moai
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RunApp();

        }
        static void RunApp()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("I will call you Stranger");
                name = "Stranger";
            }
            else
            {
                Console.WriteLine($"Thank you {name}. Now enter your Surname.");
                string surname = Console.ReadLine();
                Console.WriteLine($"Thank you {name} {surname}");
            }
            Console.WriteLine("Press any key to continiue....");
            Console.ReadKey(true);

            string[] level = {
            "#########",
            "#    #  #",
            "#   ##  #",
            "#    #  #",
            "#    #  #",
            "#       #",
            "#    #  #",
            "#########"
            };

            string[] scroll =
            {
            "     _______________",
            "()==(              (@==()",
            "     '______________'|",
            "       |             |",
            "       |             |",
            "     __)_____________|    ",
            "()==(               (@==()",
            "     '--------------'"
            };

            Console.Clear();
            Console.WriteLine("Wanna see a map? Press any key until it is revealed...");

            int scrollHalf = scroll.Length / 2;
            for (int i = 0; i < scrollHalf; i++)
            {
                Console.WriteLine(scroll[i]);
            }
            int nextMapRowPosition = Console.CursorTop;
            foreach (string row in level)
            {
                Console.SetCursorPosition(0, nextMapRowPosition);
                Console.WriteLine($"       | {row}   |");
                for (int i = scrollHalf; i < scroll.Length; i++)
                {
                    Console.WriteLine(scroll[i]);
                }
                nextMapRowPosition++;
                Console.ReadKey(true);
            }
            Console.Clear();
            foreach (string row in level)
            {
                Console.WriteLine(row);
            }

            int playeColumn = 2;
            int plalyerRow = 5;


            while (true) { 
            Console.SetCursorPosition(playeColumn, plalyerRow);
            Console.Write("@");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            Console.SetCursorPosition(playeColumn, plalyerRow);
            string currentCell = level[plalyerRow];
            char currentChar = currentCell[playeColumn];
            Console.Write(currentChar);

                if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                plalyerRow--;


            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                plalyerRow++;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                playeColumn--;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                playeColumn++;
            }
        }
            Console.SetCursorPosition(0, level.Length);

        }

    }
}





