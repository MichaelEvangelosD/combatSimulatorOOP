using System;
using System.Collections.Generic;

//TODO: Make the sim work for multiple players
//TODO: After the battle has ended, create .txt file with a battle recap in desktop

namespace f5_oop
{
    class CombatSim
    {
        static int numberOfPlayers = 2; //can be used in future expansion
        static List<Player> playerList;

        static void Main(string[] args)
        {
            OnAwake();
            OnStart();
            Update();
            OnGameEnd();
        }

        static void OnAwake()
        {
            InitializePlayerList();
            SetGlobalPlayerValues();
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

        static void OnStart()
        {

            CreatePlayers(numberOfPlayers);

            Utilities.PrintSeparatorLines();
            Console.WriteLine($"Battle Started at: {DateTime.Now}");
            Utilities.PrintSeparatorLines();
        }

        static void CreatePlayers(int numberOfPlayers)
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                string name = Utilities.ReadString($"What's the name of your player {i + 1}?");

                //Εβαλα τιμες μεγαλυτερες των 100 και 50 για να δειξω το 
                //capparisma μεσα στη Player class
                Player newPlayer = new Player(name, 1312, 1312313);

                playerList.Add(newPlayer);
            }
        }

        static void Update()
        {
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
            Environment.Exit(0);
        }
    }
}
