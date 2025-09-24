using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2OOPyTDD
{
    public class Squirtle : Pokemon
    {
        public Squirtle()
            : base("Squirtle", 1, 10, 10, 10, 10, new List<Type> { Type.Water })
        {
        }
    }
}
