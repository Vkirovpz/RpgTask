using Microsoft.Extensions.DependencyInjection;
using RpgTask.Creatures;
using RpgTask.Data.RpgDbContext;
using RpgTask.Services;
using System.Text;

public class Program
{
    static int left = 0;
    static int right = 1;
    static int up = 2;
    static int down = 3;

    static int[,] matrix;

    static int PlayerDirection = 0;
    static int PlayerColumn = 1; // column
    static int PlayerRow = 1; // row
    static IHero player = null;
    static void PrintMenuSb(string input)
    {
        var sb = new StringBuilder();
        if (input == "mainMenu")
        {
            sb.AppendLine("Welcome! ");
            sb.AppendLine("Press any key to play.");
        }
        else if (input == "characterSelect")
        {
            sb.AppendLine("Choose character type:");
            sb.AppendLine("Options: ");
            sb.AppendLine("1) Warrior ");
            sb.AppendLine("2) Archer ");
            sb.AppendLine("3) Mage ");
            sb.AppendLine("Your pick: ");
        }
        else if (input == "pointRequest")
        {
            sb.AppendLine("Would you like to buff up your stats before starting ? (Limit: 3 points total);");
            sb.AppendLine("Response(Y\\N): ");
        }
        Console.WriteLine(sb.ToString());
    }
    static void PrintAddPointsSb(int points)
    {
        var responseY = new StringBuilder();
        responseY.AppendLine($"Remaining Points:{points}");
        responseY.AppendLine("Add to Strenght: ");
        responseY.AppendLine("Add to Agility: ");
        responseY.AppendLine("Add to Intelligence: ");
        Console.WriteLine(responseY.ToString());
    }

    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .AddSingleton<RpgTaskDbContext>()
            .AddSingleton<IHeroService, HeroService>()
            .BuildServiceProvider();


        var _service = serviceProvider.GetService<IHeroService>();

        PrintMenuSb("mainMenu");

        var pressAnyKey = Console.ReadLine();
        Console.Clear();
        if (pressAnyKey != null)
        {
            PrintMenuSb("characterSelect");

            bool IsCreated = false;

            var chooseRace = Console.ReadLine().ToLower();
            Console.Clear();

            while (!IsCreated)
            {
                if (chooseRace.Equals("warrior") || chooseRace.Equals("archer") || chooseRace.Equals("mage"))
                {

                    if (chooseRace == "warrior")
                    {
                        var warrior = HeroCreator.getHero(chooseRace);
                        player = warrior;

                        PrintMenuSb("pointRequest");

                        var response = Console.ReadLine().ToLower();
                        Console.Clear();
                        while (true)
                        {
                            if (response == "y")
                            {
                                warrior.AddPoints();

                                IsCreated = true;
                                break;
                            }
                            else if (response == "n")
                            {
                                IsCreated = true;
                                break;
                            }
                            else
                            {
                                PrintMenuSb("pointRequest");
                                response = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        _service.AddNewHero(player);
                        //_service.AddNewWarrior(warrior);

                    }
                    else if (chooseRace == "archer")
                    {
                        var archer = HeroCreator.getHero(chooseRace);
                        player = archer;
                        PrintMenuSb("pointRequest");

                        var response = Console.ReadLine().ToLower();
                        Console.Clear();
                        while (true)
                        {
                            if (response == "y")
                            {
                                archer.AddPoints();

                                IsCreated = true;
                                break;
                            }
                            else if (response == "n")
                            {
                                IsCreated = true;
                                break;
                            }
                            else
                            {
                                PrintMenuSb("pointRequest");
                                response = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        _service.AddNewHero(player);
                        //_service.AddNewArcher(archer);

                    }
                    else if (chooseRace == "mage")
                    {
                        var mage = HeroCreator.getHero(chooseRace);
                        player = mage;
                        PrintMenuSb("pointRequest");
                        var response = Console.ReadLine().ToLower();
                        Console.Clear();
                        while (true)
                        {
                            if (response == "y")
                            {
                                mage.AddPoints();

                                IsCreated = true;
                                break;
                            }
                            else if (response == "n")
                            {
                                IsCreated = true;
                                break;
                            }
                            else
                            {
                                PrintMenuSb("pointRequest");
                                response = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        _service.AddNewHero(player);
                        //_service.AddNewMage(mage);
                    }
                }
                else
                {
                    PrintMenuSb("characterSelect");
                    chooseRace = Console.ReadLine();
                    Console.Clear();
                }
            }
        }
        SetGameField();
        WritePlayerPosition(PlayerColumn, PlayerRow, player.Symbol);

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            ChangePlayerDirection(key);
            DeletePlayerOldPosition(PlayerColumn, PlayerRow, '▒');

            MovePlayer();

            WritePlayerPosition(PlayerColumn, PlayerRow, player.Symbol);

            Random rnd = new Random();
            int monsterCol = rnd.Next(0, 11);
            int monsterRow = rnd.Next(0, 10);
            SetMonsterPosition(monsterCol, monsterRow, 'M');
        }
    }

    static void SetGameField()
    {
        matrix = new int[10, 10];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("▒");
            }
            Console.WriteLine("▒");
        }
    }
    static void MovePlayer()
    {
        if (PlayerDirection == right && PlayerColumn <= matrix.GetLength(0) - 1)
        {
            PlayerColumn++;
        }
        if (PlayerDirection == left && PlayerColumn > 0)
        {
            PlayerColumn--;
        }
        if (PlayerDirection == up && PlayerRow > 0)
        {
            PlayerRow--;
        }
        if (PlayerDirection == down && PlayerRow <= matrix.GetLength(0) - 2)
        {
            PlayerRow++;
        }
    }

    static void ChangePlayerDirection(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.W)
        {
            PlayerDirection = up;
        }
        if (key.Key == ConsoleKey.A)
        {
            PlayerDirection = left;
        }
        if (key.Key == ConsoleKey.D)
        {
            PlayerDirection = right;
        }
        if (key.Key == ConsoleKey.S)
        {
            PlayerDirection = down;
        }
    }
    static void WritePlayerPosition(int x, int y, string ch)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(ch);
    }
    static void DeletePlayerOldPosition(int x, int y, char ch)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(ch);
    }
    static void SetMonsterPosition(int x, int y, char ch)
    {
        if (x != PlayerColumn || y != PlayerRow)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }
    }
}