using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HelloWorld
{


    struct Player
    {
        public int health;
        public float speed;
        public bool isAlive;
        public string name;
        public int defense;
        public int damage;
    }

    struct Item
    {
        public string itemName;
        public int statBoost;
        public int durability;
    }

    class Game
    {
        
        void Longsword(ref Item item)
        {
            item.itemName = "longsword";
            item.statBoost = 10;
        }
        void PlayerStats(ref Player player)
        {
            player.damage = 10;
            player.defense = 10;
            player.health = 100;
        }
        void SetName(Player player, ref string Newname)
        {
            int skillPoints = 10;
            char input = ' ';
            while (input != '1')
            {
                Console.Clear();
                Console.WriteLine("enter your name, player");
                Newname = Console.ReadLine();
                input = GetInput("yes", "no", "are you sure you like the name " + Newname + "?");
                if (input == '2')
                {
                    Console.WriteLine("try again");
                    Console.ReadKey();
                }
            }
            
           

        }

        
        void StartBattle(int arenaRoom)
        {

            arenaRoom = 1;
           
           
            while (player1.health > 0 && player2.health > 0)
            {
                char input = ' ';
                Console.WriteLine("\n" + player1.name + "chose your weapon");
                GetInput(out input, "sword", "big sword", "skinny sword");
                if (input == '1')
                {
                    Console.WriteLine("\nyou pick a sword");
                    player1.damage += 10;
                }
                else if (input == '2')
                {
                    player1.damage += 20;
                }
                else if (input == '3')
                {
                    player1.damage += 15;
                }
                

                Console.WriteLine("\nchose your weapon " + player2.name);
                GetInput(out input, "sword", "big sword", "skinny sword");
                if (input == '1')
                {
                    player2.damage += 10;
                }
                else if (input == '2')
                {
                    player2.damage += 20;
                }
                else if(input == '3')
                {
                    player2.damage += 15;
                }

                
                PrintStats(player1);
                PrintStats(player2);

                
                
                Console.Write("> ");
                Console.ReadKey();

                Console.WriteLine("it is " + player1.name + "'s turn.");
                GetInput(out input, "Attack", "Defend", "heal (+20 HP)");
                
                if (input == '1')
                {
                    player2.health -= player1.damage;
                    Console.WriteLine("\nYou dealt " + player1.damage + " damage.");
                    Console.WriteLine(player2.name + " has " + player2.health + " remaining");
                    Console.Write("> ");
                    Console.ReadKey();
                }
                
                
                else if (input == '2')
                {
                    player1.defense += 10;
                    player2.damage -= player1.defense;
                    player1.health -= player2.damage;
                    Console.WriteLine("\nYou prepare for the enemy's attack, you block for " + player1.defense + " points of defence");
                    Console.WriteLine("\n" + player2.name + " dealt " + player2.damage + " damage.");
                    player2.damage += player1.defense;
                    player1.defense -= 10;
                    Console.WriteLine("\n" + player1.name + " has " + player1.health + "  health remaining");
                    Console.Write("> ");
                    Console.ReadKey();
                }
                else if (input == '3')
                {
                    Console.WriteLine("\n"+ player1.name + " healed");
                    player1.health += 10;
                    if(player1.health >= 150)
                    {
                        player1.health = 150;
                    }
                    Console.Write("> ");
                    Console.ReadKey();
                }
                if(player1.health <= 0)
                {
                    Console.WriteLine(player1.name + " has been deafeated");
                    _gameOver = true;
                }
                else if(player2.health <= 0)
                {
                    Console.WriteLine(player2.name + " has been deafeated");
                    _gameOver = true;
                }

                PrintStats(player1);
                PrintStats(player2);


                Console.Write("> ");
                Console.ReadKey();
                Console.WriteLine("it is " + player2.name + "'s turn.");
                GetInput("Attack", "Defend", "heal (+20 HP)");
                
                if (input == '1')
                {
                    player1.health -= player2.damage;
                    Console.WriteLine("\nYou dealt " + player2.damage + " damage.");
                    Console.WriteLine(player1.name + " has " + player1.health + " remaining");
                    Console.Write("> ");
                    Console.ReadKey();
                }
                
                
                else if (input == '2')
                {
                    player2.defense += 10;
                    player1.damage -= player2.defense;
                    player2.health -= player1.damage;
                    Console.WriteLine("\nYou prepare for the enemy's attack, you block for " + player2.defense + " points of defence");
                    Console.WriteLine("\n" + player1.name + " dealt " + player1.damage + " damage.");
                    player1.damage += player2.defense;
                    player2.defense -= 10;
                    Console.WriteLine("\n" + player2 + " has " + player2.health + "  health remaining");
                    Console.Write("> ");
                    Console.ReadKey();
                }
                else if (input == '3')
                {
                    Console.WriteLine("\n" + player2.name + " healed");
                    player2.health += 10;
                    if (player2.health >= 150)
                    {
                        player2.health = 150;
                    }
                    Console.Write("> ");
                    Console.ReadKey();
                }
                if (player1.health <= 0)
                {
                    Console.WriteLine(player2.name + " has been deafeated");
                    _gameOver = true;
                }
                else if (player2.health <= 0)
                {
                    Console.WriteLine(player1.name + " has been deafeated");
                    _gameOver = true;
                }
                Console.Clear();
                

                

            }
        }
        bool _gameOver = false;
        Player player1;
        Player player2;

        
        public void Run()
        {
            Start();

            while (_gameOver == false)
            {
                Update();
            }
            End();
        }

        void GetInput(out char input, string option1, string option2, string option3)
        {
            
            input = ' ';

            
            while (input != '1' && input != '2' && input != '3')
            {

                Console.WriteLine("\n1." + option1);
                Console.WriteLine("2." + option2);
                Console.WriteLine("3." + option3);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
            }
        }

        
        public void Start()
        {
            
            SetName(player1, ref player1.name);
            SetName(player2, ref player2.name);
            PlayerStats(ref player1);
            PlayerStats(ref player2);
            Console.WriteLine("press any key to start");
            Console.ReadKey();
            Console.Clear();
        }

        void PrintStats(Player player)
        {
            Console.WriteLine("\n" + player.name);
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
            Console.WriteLine("Defense: " + player.defense);
        }

        char GetInput(string option1, string option2, string query)
        {
            char input = ' ';
            while (input != '1' && input != '2')
            {
                Console.WriteLine(query);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            return input;
        }

        
        public void Update()
        {
            StartBattle(1);
             _gameOver = true;
        }

        
        public void End()
        {
            
        }
    }
}
