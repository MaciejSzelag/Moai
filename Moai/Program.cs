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

            Player player = new Player(2,5,"5");

            while (true) { 
         

            Display.WriteAt(player.x, player.y, player.avatar);

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

        
    
            char currentChar = level[player.y][player.x];
        

            Display.WriteAt(player.x, player.y, currentChar);

            int targetColumn = player.x;
            int targetRow = player.y;

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
               targetRow = player.y - 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                    targetRow = player.y + 1;
            }
            else if (keyInfo.Key == ConsoleKey.LeftArrow)
            {
                    targetColumn = player.x - 1;
            }
            else if (keyInfo.Key == ConsoleKey.RightArrow)
            {
                    targetColumn = player.x + 1;
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
                            player.x = targetColumn;
                            player.y = targetRow;
                        }
                    }

                }
            }
            Console.SetCursorPosition(0, level.Length);

        }

    }
}





