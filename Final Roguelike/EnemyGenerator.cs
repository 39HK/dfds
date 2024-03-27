using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Roguelike
{
    internal class EnemyGenerator
    {
            private static Random random = new Random();
            private static char[,] maze;
            private static int playerX, playerY;
            private static int exitX = 18;
            private static int exitY = 18;
            private static List<Zombie> enemies;

            public EnemyGenerator(char[,] _maze, int _playerX, int _playerY, List<Zombie> _enemies)
            {
                maze = _maze;
                playerX = _playerX;
                playerY = _playerY;
                enemies = _enemies;
            }

            public void Generate()
            {
                int numberOfEnemies = random.Next(3, 7);

                for (int i = 0; i < numberOfEnemies; i++)
                {
                    int enemyX;
                    int enemyY;

                    do
                    {
                        enemyX = random.Next(2, 18);
                        enemyY = random.Next(2, 18);
                    } while (!IsCellValidForEnemy(enemyX, enemyY));

                    enemies.Add(new Zombie(enemyX, enemyY));
                }
            }

            private static bool IsCellValidForEnemy(int x, int y)
            {
                return maze[x, y] == '.' && !IsTooCloseToPlayerOrExit(x, y) && !IsEnemyOnCell(x, y);
            }

            private static bool IsTooCloseToPlayerOrExit(int x, int y)
            {
                return Math.Abs(x - playerX) < 2 || Math.Abs(y - playerY) < 2 || Math.Abs(x - exitX) < 2 || Math.Abs(y - exitY) < 2;
            }

            private static bool IsEnemyOnCell(int x, int y)
            {
                return enemies.Any(enemy => enemy.X == x && enemy.Y == y);
            }
        }
    }