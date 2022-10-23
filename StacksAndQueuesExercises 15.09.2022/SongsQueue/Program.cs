using System;
using System.Collections.Generic;
using System.Linq;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsInfo = Console.ReadLine().Split(", ");

            Queue<string> songs = new Queue<string>(songsInfo);


            while (songs.Count > 0)
            {
                string[] command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    case "Add":
                        string songName = string.Join(" ", command.Skip(1));
                        if (songs.Contains(songName))
                        {
                            Console.WriteLine($"{songName} is already contained!");
                        }
                        else
                        {
                            songs.Enqueue(songName);
                        }
                        break;
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                }

            }

            Console.WriteLine("No more songs!");
        }
    }
}
