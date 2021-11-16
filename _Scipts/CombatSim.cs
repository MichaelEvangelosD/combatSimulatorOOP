using System;
using System.Collections.Generic;
using System.Threading;

namespace f5_oop
{
    class CombatSim
    {
        static int numberOfPlayers = 2; //can be used in future expansion
        static List<Player> playerList;

        static void Main(string[] args)
        {
            OnAwake();
            Update();
            OnGameEnd();
        }

        static void OnAwake()
        {
            InitializePlayerList();
            SetGlobalPlayerValues();

            CreatePlayers(numberOfPlayers);
        }

        static void InitializePlayerList()
        {
            playerList = new List<Player>();
        }

        static void SetGlobalPlayerValues()
        {
            PlayerStatics.MAX_HEALTH = 100;
            PlayerStatics.MAX_ARMOR = 50;
        }

        static void CreatePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                string name = Utilities.ReadString("What's the name of your player?");

                Player newPlayer = new Player(name, 1312, 1312313);

                playerList.Add(newPlayer);
            }
        }

        static void Update()
        {
            Utilities.PrintSeparatorLines();
            Console.WriteLine($"Battle Started at: {DateTime.Now}");
            Utilities.PrintSeparatorLines();

            while (true)
            {
                //Player 1 attacks player 2
                playerList[0].ExecuteAttack(playerList[1]);

                if (Player.IsDead(playerList[1]))
                {
                    Console.WriteLine($"{playerList[1].Name} is dead.");
                    break;
                }

                //Player 2 attacks player 1
                playerList[1].ExecuteAttack(playerList[0]);

                if (Player.IsDead(playerList[0]))
                {
                    Console.WriteLine($"{playerList[0].Name} is dead.");
                    break;
                }
                while (!Utilities.WaitForEnter()) ;
            }

            Utilities.PrintSeparatorLines();
            Console.WriteLine($"Battle ended at {DateTime.Now}");
            while (!Utilities.WaitForEnter()) ;
        }

        private static void OnGameEnd()
        {
            Scoreboard.PrintScoreboard();

            TerminateGame();
        }

        private static void TerminateGame()
        {
            Console.WriteLine("Press any key to terminate the program.");
            Console.ReadKey();
        }
    }
}
