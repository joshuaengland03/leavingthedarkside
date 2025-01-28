// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    public class Game
    {
        private Player player;
        private Dungeon dungeon;
        private bool gameRunning;

        public Game()
        {
            player = new Player("Hero", 100, 10, 5);
            dungeon = new Dungeon(10, 10);
            gameRunning = true;
        }

        public void Start()
        {
            Console.CursorVisible = false;
            while (gameRunning)
            {
                Render();
                HandleInput();
            }
        }

        private void Render()
        {
            Console.Clear();
            dungeon.Render();
            player.Render();
            Console.SetCursorPosition(0, dungeon.Height + 2);
            Console.WriteLine($"Health: {player.Health} | Attack: {player.Attack} | Defense: {player.Defense}");
        }

        private void HandleInput()
        {
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    player.Move(0, -1);
                    break;
                case ConsoleKey.S:
                    player.Move(0, 1);
                    break;
                case ConsoleKey.A:
                    player.Move(-1, 0);
                    break;
                case ConsoleKey.D:
                    player.Move(1, 0);
                    break;
                case ConsoleKey.Escape:
                    gameRunning = false;
                    break;
            }

            // Check if the player has encountered an enemy
            if (dungeon.HasEnemyAt(player.X, player.Y))
            {
                Combat();
            }
        }

        private void Combat()
        {
            Console.Clear();
            var enemy = dungeon.GetEnemyAt(player.X, player.Y);
            Console.WriteLine($"You encountered a {enemy.Name}! Prepare for battle!");
            Console.WriteLine("Press any key to start the fight...");
            Console.ReadKey(true);

            // Simple combat loop
            while (player.Health > 0 && enemy.Health > 0)
            {
                // Player attacks enemy
                enemy.TakeDamage(player.Attack);
                Console.WriteLine($"You hit the {enemy.Name} for {player.Attack} damage!");

                if (enemy.Health <= 0)
                {
                    Console.WriteLine($"You defeated the {enemy.Name}!");
                    dungeon.RemoveEnemy(enemy);
                    break;
                }

                // Enemy attacks player
                player.TakeDamage(enemy.Attack);
                Console.WriteLine($"The {enemy.Name} hits you for {enemy.Attack} damage!");

                if (player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated! Game Over!");
                    gameRunning = false;
                    break;
                }

                Console.WriteLine("Press any key to continue the fight...");
                Console.ReadKey(true);
            }
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Player(string name, int health, int attack, int defense)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            X = 0;
            Y = 0;
        }

        public void Render()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write("P"); // Player symbol
        }

        public void Move(int dx, int dy)
        {
            int newX = X + dx;
            int newY = Y + dy;
            // Ensure the player stays within dungeon bounds
            if (newX >= 0 && newY >= 0 && newX < 10 && newY < 10)
            {
                X = newX;
                Y = newY;
            }
        }

        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(0, damage - Defense);
            Health -= actualDamage;
        }
    }

    public class Dungeon
    {
        public int Width { get; }
        public int Height { get; }
        private List<Enemy> enemies;

        public Dungeon(int width, int height)
        {
            Width = width;
            Height = height;
            enemies = new List<Enemy>
            {
                new Enemy("Goblin", 30, 5, 2, 3),
                new Enemy("Orc", 50, 8, 4, 5)
            };
        }

        public void Render()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1)
                    {
                        Console.Write("#"); // Wall
                    }
                    else if (HasEnemyAt(x, y))
                    {
                        Console.Write("E"); // Enemy
                    }
                    else
                    {
                        Console.Write(" "); // Empty space
                    }
                }
                Console.WriteLine();
            }
        }

        public bool HasEnemyAt(int x, int y)
        {
            return enemies.Any(e => e.X == x && e.Y == y);
        }

        public Enemy GetEnemyAt(int x, int y)
        {
            return enemies.FirstOrDefault(e => e.X == x && e.Y == y);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            enemies.Remove(enemy);
        }
    }

    public class Enemy
    {
        public string Name { get; }
        public int Health { get; set; }
        public int Attack { get; }
        public int Defense { get; }
        public int X { get; set; }
        public int Y { get; set; }

        public Enemy(string name, int health, int attack, int defense, int x, int y)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Defense = defense;
            X = x;
            Y = y;
        }

        public void TakeDamage(int damage)
        {
            int actualDamage = Math.Max(0, damage - Defense);
            Health -= actualDamage;
        }
    }
}
