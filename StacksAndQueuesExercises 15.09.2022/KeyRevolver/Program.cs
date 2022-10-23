using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bulletsInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] locksInfo = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int value = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>(locksInfo);
            Stack<int> bullets = new Stack<int>(bulletsInfo);
            int usedBullets = 0;
            int bulletsInBarrel = Math.Min(barrelSize, bullets.Count);

            while (bullets.Any() && locks.Any())
            {
                int currentBullet = bullets.Pop();
                bulletsInBarrel--;
                usedBullets++;
                int currentLock = locks.Peek();

                if (currentLock>=currentBullet)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (bulletsInBarrel==0 && bullets.Any())
                {
                    bulletsInBarrel += Math.Min(barrelSize, bullets.Count);
                    Console.WriteLine("Reloading!");
                }
            }

            if (locks.Any())
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                int earnedMoney = value - usedBullets * bulletPrice;
                Console.WriteLine($"{bulletsInfo.Length - usedBullets} bullets left. Earned ${earnedMoney}");
            }
        }
    }
}
