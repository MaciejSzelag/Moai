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
            "#       #",
            "#  ###  #",
            "#  # #  #",
            "#    #  #",
            "#       #",
            "#       #",
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

            int playerColumn = 2;
            int playerRow = 5;


            while (true) { 
         

            WriteAt(playerColumn, playerRow, "@");

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        
    
            char currentChar = level[playerRow][playerColumn];
        

            WriteAt(playerColumn, playerRow, currentChar);

            int targetColumn = playerColumn;
            int targetRow = playerRow;

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
               targetRow = playerRow - 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                    targetRow = playerRow + 1;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                    targetColumn = playerColumn - 1;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                    targetColumn = playerColumn + 1;
                }
                else
                {
                    break;
                }

            if (targetRow >= 0 && targetRow < level.Length)
                {
                    string targetRowString = level[targetRow];
                    if (targetColumn >= 0 && targetColumn < targetRowString.Length)
                    {
                        char targetCell = targetRowString[targetColumn];
                        if (targetCell != '#')
                        {
                            playerColumn = targetColumn;
                            playerRow = targetRow;
                        }
                    }

                }
            }
            Console.SetCursorPosition(0, level.Length);

        }

     static void WriteAt(int columnNumber, int rowNumber, string text)
        {
            Console.SetCursorPosition(columnNumber, rowNumber);
            Console.Write(text);
        }
        static void WriteAt(int columnNumber, int rowNumber, char sign)
        {
            Console.SetCursorPosition(columnNumber, rowNumber);
            Console.Write(sign);
        }
    }
}





