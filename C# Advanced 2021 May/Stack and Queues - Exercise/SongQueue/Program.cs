using System;
using System.Collections.Generic;
using System.Linq;

namespace SongQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            Queue<string> songList = new Queue<string>(songs);

            while (songList.Any())
            {
                string command = Console.ReadLine();

                switch (command)
                {
                    case "Play":
                        songList.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songList));
                        break;
                    default:
                        string song = command.Substring(4);
                        if (songList.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            songList.Enqueue(song);
                        }
                        break;

                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
