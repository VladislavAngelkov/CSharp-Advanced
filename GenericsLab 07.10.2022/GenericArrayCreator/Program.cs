using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] text = ArrayCreator.Create(10, "Pesho");
            int[] integeers = ArrayCreator.Create(10, 23);

            Console.WriteLine();
        }
    }
}
