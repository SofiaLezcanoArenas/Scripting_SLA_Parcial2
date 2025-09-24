using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2OOPyTDD
{
    public struct Move
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public Type Type { get; set; }
        public MoveType MoveType { get; set; }

        public Move(string name, Type type, MoveType moveType, int power = 100, int speed = 1)
        {
            Name = name;
            Type = type;
            MoveType = moveType;
            Power = 0; //espera power
            Speed = speed;
        }
    }
}
