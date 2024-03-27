using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Roguelike
{
        class StartGame
        {
            static char[,] Maze = new char[20, 20];
            static int playerX = 0;
            static int playerY = 0;
            static int exitX = 18;
            static int exitY = 18;
            static int playerHealth = 10;
            static bool inBattle = false;
            static List<Zombie> enemies = new List<Zombie>();

            public void Start()
            {
                GenerateMaze maze = new GenerateMaze();
                maze.Generate();
                Maze = maze.getMaze();

                EnemyGenerator enemy = new EnemyGenerator(Maze, playerX, playerY, enemies);
                enemy.Generate();


            }

            public async void Update()
            {

                while (true)
                {
                    Controller control = new Controller(Maze, playerX, playerY, enemies, inBattle);
                    Drawer drawer = new Drawer(Maze, playerX, playerY, enemies, playerHealth, inBattle);
                    Console.Clear();
                    drawer.DrawMaze();
                    drawer.DrawPlayer();
                    drawer.DrawPlayerHealth();
                    control.MoveEnemies();
                    drawer.DrawEnemies();
                    CheckCollisions();
                    drawer.DrawBattleStatus();
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    await control.HandleKeyPressAsync(keyInfo, drawer);
                    Maze = control.GetMaze();
                    playerX = control.GetPlayerX();
                    playerY = control.GetPlayerY();
                    inBattle = control.IsInBattle();
                    enemies = control.GetEnemies();
                }
            }
            static void CheckCollisions()
            {
                // Проверка на выигрыш
                if (playerX == exitX && playerY == exitY)
                {
                    Console.Clear();
                    Console.WriteLine("Ура, победа!");
                    Environment.Exit(0);
                }
            }
        }
    }