using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2OOPyTDD
{
    internal class Pikachu: Pokemon
    {
        public Pikachu()
            : base("Pikachu", 0, 10, 10, 10, 10, new List<Type> { Type.Electric })
        {
        }
    }
}
