using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int isRows = int.Parse(Console.ReadLine());

            char[][] beach = new char[isRows][];

            for (int row = 0; row < beach.Length; row++)
            {
                char[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[row] = input;
                
            }

            int myTokenCount = 0;
            int oppTokenCount = 0;

            while (true)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];

                if (command == "Gong")
                {
                    break;
                }


                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                bool isCoordinates = (row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length);
                if (tokens[0] == "Find" && isCoordinates)
                {
                    if (beach[row][col] == 'T')
                    {
                        myTokenCount++;
                        beach[row][col] = '-';
                    }

                }
                else if (tokens[0] == "Opponent" && isCoordinates)
                {
                    string move = tokens[3];
                    if (beach[row][col] == 'T')
                    {
                        oppTokenCount++;
                        beach[row][col] = '-';
                    }

                    for (int i = 0; i < 3; i++)
                    {
                        if (move == "up")
                        {
                            row--;
                            isCoordinates = (row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].GetLength(0));
                            if (isCoordinates)
                            {
                                if (beach[row][col] == 'T')
                                {
                                    oppTokenCount++;
                                    beach[row][col] = '-';
                                }
                            }
                            else if(!isCoordinates)
                            {
                                break;
                            }
                        }
                        else if (move == "down")
                        {
                            row++;
                            isCoordinates = (row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].GetLength(0));
                            if (isCoordinates)
                            {
                                if (beach[row][col] == 'T')
                                {
                                    oppTokenCount++;
                                    beach[row][col] = '-';
                                }
                            }
                            else if (!isCoordinates)
                            {
                                break;
                            }
                        }
                        else if (move == "left")
                        {
                            col--;
                            isCoordinates = (row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].GetLength(0));
                            if (isCoordinates)
                            {
                                if (beach[row][col] == 'T')
                                {
                                    oppTokenCount++;
                                    beach[row][col] = '-';
                                }
                            }
                            else if (!isCoordinates)
                            {
                                break;
                            }
                        }
                        else if (move == "right")
                        {
                            col++;
                            isCoordinates = (row >= 0 && row < beach.GetLength(0) && col >= 0 && col < beach[row].GetLength(0));
                            if (isCoordinates)
                            {
                                if (beach[row][col] == 'T')
                                {
                                    oppTokenCount++;
                                    beach[row][col] = '-';
                                }
                            }
                            else if (!isCoordinates)
                            {
                                break;
                            }
                        }
                    }

                }
            }

            for (int row = 0; row < beach.Length; row++)
            {                               
                Console.WriteLine(string.Join(" ", beach[row]));                
            }

            Console.WriteLine($"Collected tokens: {myTokenCount}");

            Console.WriteLine($"Opponent's tokens: {oppTokenCount}");
        }
    }
}
