using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2OOPyTDD
{
    public enum Type
    {
        Fire,
        Water,
        Grass,
        Electric,
        Ground,
        Rock,
        Ghost,
        Poison,
        Psychic,
        Bug
    }

    public enum MoveType
    {
        Physical,
        Special
    }

    public class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public List<Type> Types { get; set; }
        public List<Move> Moves { get; set; }

        public Pokemon(string name, int level, int atk, int def, int spatk, int spdef, List<Type> types)
        {
            Name = name;
            Level = level;
            Attack = atk;
            Defense = def;
            SpecialAttack = spatk;
            SpecialDefense = spdef;
            Types = types;
            Moves = new List<Move>();
        }

        // Constructor por defecto (para las especies)
        public Pokemon()
        {
            Name = "Default";
            Level = 0;
            Attack = 0;
            Defense = 0;
            SpecialAttack = 0;
            SpecialDefense = 0;
            Types = new List<Type>();
            Moves = new List<Move>();
        }
    }
}
