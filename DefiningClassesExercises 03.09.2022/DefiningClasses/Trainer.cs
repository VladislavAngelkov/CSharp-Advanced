using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            pokemons = new List<Pokemon>();
            numberOfBadges = 0;
        }

        private string name;
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int NumberOfBadges
        {
            get { return numberOfBadges; }
        }
        public List<Pokemon> Pokemons
        {
            get { return pokemons; }
        }

        public void AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }
        public void Fight(string element)
        {
            if (pokemons.Any(p=>p.Element == element))
            {
                numberOfBadges++;
            }
            else
            {
                foreach (var pokemon in this.pokemons)
                {
                    pokemon.Health -= 10;
                }
                pokemons = pokemons.Where(p => p.Health > 0).ToList();
            }
        }

    }
}
