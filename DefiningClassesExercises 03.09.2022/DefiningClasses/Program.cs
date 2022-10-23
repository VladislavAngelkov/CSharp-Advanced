using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (info[0] != "Tournament")
            {
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int health = int.Parse(info[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, health);

                if (!trainers.ContainsKey(trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainers.Add(trainerName, trainer);
                }

                trainers[trainerName].AddPokemon(pokemon);

                info = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Value.Fight(command);
                }

                command = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t=>t.Value.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Value.Name} {trainer.Value.NumberOfBadges} {trainer.Value.Pokemons.Count}");
            }
        }
    }
}
