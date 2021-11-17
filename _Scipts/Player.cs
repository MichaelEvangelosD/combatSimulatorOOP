using System;

namespace f5_oop
{
    enum PlayerState
    {
        Alive,
        Dead,
    }

    class PlayerStatics
    {
        public static int MAX_HEALTH;
        public static int MAX_ARMOR;
    }

    class Player
    {
        private string name;
        private int health;
        private int armor;
        private bool isArmorBroken;
        private PlayerState currentState;

        public string Name { get => name; set => name = value; }

        public int Health
        {
            get => health;

            set
            {
                if (value > PlayerStatics.MAX_HEALTH)
                {
                    health = PlayerStatics.MAX_HEALTH;
                }
                else
                {
                    this.health = value;
                }
            }
        }
        public int Armor
        {
            get => armor;

            set
            {
                if (value > PlayerStatics.MAX_ARMOR)
                {
                    armor = PlayerStatics.MAX_ARMOR;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        public PlayerState PlayerState { get => currentState; set => currentState = value; }
        public bool IsArmorBroken { get => isArmorBroken; }

        public Player() { } //Default constructor

        public Player(string name, int health, int armor)
        {
            Name = name;
            Health = health;
            Armor = armor;
            currentState = PlayerState.Alive;
        }

        public void ExecuteAttack(Player target)
        {
            Random randomizer = new Random();

            if (target.Armor <= 0)
            {
                Console.Write($"{target.Name} got his health damaged for ");
                target.DamageHealth(randomizer.Next(5, 11));
                Console.WriteLine($"\tRemaining health: {target.Health}");

                Scoreboard.CreateEntry(target.Name, target.Health, target.Armor);
            }
            else
            {
                Console.Write($"{target.Name} got his armor damaged for ");
                target.DamageArmor((randomizer.Next(5, 11)) - 1);
                Console.WriteLine($"\tRemaining armor: {target.Armor}");

                Scoreboard.CreateEntry(target.Name, target.Health, target.Armor);
            }
        }

        void DamageArmor(int value)
        {
            Armor -= value;

            if (this.armor <= 0)
            {
                this.isArmorBroken = true;
                this.armor = 0;
            }

            Console.WriteLine($"{value} points.");
        }

        void DamageHealth(int value)
        {
            Health -= value;

            if (this.health <= 0)
            {
                PlayerState = PlayerState.Dead;
                this.health = 0;
            }

            Console.WriteLine($"{value} points.");
        }

        public static bool IsDead(Player playerToCheck)
        {
            if (playerToCheck.PlayerState == PlayerState.Alive)
                return false;
            else
                return true;
        }

        //UTILITIES
        public string GetPlayerInfo()
        {
            return $"{this.Name} {this.Health} {this.Armor} " +
                $"{this.PlayerState} IsArmorBroken: {this.IsArmorBroken}";
        }
    }
}
