using NUnit.Framework;

namespace Parcial2OOPyTDD
{
    [TestFixture] //sirve?
    public class Tests
    {
        private Pikachu _pikachu;
        private Charmander _charmander;
        private Squirtle _squirtle;
        private Bulbasaur _bulbasaur;
        private Gastly _gastly;

        [SetUp]
        public void SetUp()
        {
            _pikachu = new Pikachu();
            _charmander = new Charmander();
            _squirtle = new Squirtle();
            _bulbasaur = new Bulbasaur();
            _gastly = new Gastly();
        }

        [Test]
        public void CrearPokemon_ValoresPorDefectoCorrectos()
        {
            Assert.That(_pikachu.Level, Is.EqualTo(1));
            Assert.That(_pikachu.Attack, Is.EqualTo(10));
            Assert.That(_pikachu.Defense, Is.EqualTo(10));
            Assert.That(_pikachu.SpecialAttack, Is.EqualTo(10));
            Assert.That(_pikachu.SpecialDefense, Is.EqualTo(10));
        }

        [Test]
        public void CrearMovimiento_ValoresPorDefectoCorrectos()
        {
            Move impactrueno = new Move("Impactrueno", Type.Electric, MoveType.Special);

            Assert.That(impactrueno.Power, Is.EqualTo(100));
            Assert.That(impactrueno.Speed, Is.EqualTo(1));
            Assert.That(impactrueno.Type, Is.EqualTo(Type.Electric));
            Assert.That(impactrueno.MoveType, Is.EqualTo(MoveType.Special));
        }
    }

    [TestFixture]
    public class TypeModifierTests
    {
        private Charmander _fire;
        private Squirtle _water;
        private Pikachu _electric;
        private Bulbasaur _grass;
        private Gastly _ghost;

        [SetUp]
        public void SetUp()
        {
            _fire = new Charmander();   // Fire
            _water = new Squirtle();    // Water
            _electric = new Pikachu();  // Electric
            _grass = new Bulbasaur();   // Grass/Poison
            _ghost = new Gastly();      // Ghost/Poison
        }

        [Test]
        public void AguaContraFuego_EsEfectivoPorDos()
        {
            Move waterGun = new Move("Water Gun", Type.Water, MoveType.Special);
            double mod = TypeChart.GetModifier(waterGun.Type, _fire.Types);
            Assert.That(mod, Is.EqualTo(2.0));
        }

        [Test]
        public void AguaContraFuegoYGround_EsCuatroPorDos()
        {
            Pokemon mixto = new Pokemon("Custom", 50, 100, 100, 100, 100,
                                        new List<Type> { Type.Fire, Type.Ground });
            Move waterGun = new Move("Water Gun", Type.Water, MoveType.Special);

            double mod = TypeChart.GetModifier(waterGun.Type, mixto.Types);
            Assert.That(mod, Is.EqualTo(4.0));
        }

        [Test]
        public void ElectricoContraGround_NoHaceDaño()
        {
            Pokemon ground = new Pokemon("CustomGround", 10, 10, 10, 10, 10,
                                         new List<Type> { Type.Ground });
            Move thunderShock = new Move("ThunderShock", Type.Electric, MoveType.Special);

            double mod = TypeChart.GetModifier(thunderShock.Type, ground.Types);
            Assert.That(mod, Is.EqualTo(0.0));
        }
    }

    [TestFixture]
    public class DamageFormulaTests
    {
        [TestCase(1, 1, 1, 1, 1, 0, 0)]    // Caso 1
        [TestCase(1, 1, 1, 1, 1, 1, 1)]    // Caso 2
        [TestCase(1, 50, 100, 50, 1, 1, 16)] // Caso 3
        [TestCase(5, 50, 100, 50, 1, 1, 5)]  // Caso 4
        [TestCase(10, 20, 30, 15, 1, 1, 5)]  // Caso 5
        public void CalculoDeDaño_EsperadoCorrecto(
            int level, int pwr, int atk, int def, int spatk, int mod, int expected)
        {
            // Defensor con DEF y SpDEF = def
            Pokemon defender = new Pokemon("Dummy", 1, 10, def, spatk, def, new List<Type> { Type.Rock });

            // Atacante con ATK = atk y SpATK = spatk
            Pokemon attacker = new Pokemon("DummyAtk", level, atk, def, spatk, def, new List<Type> { Type.Rock });

            // Movimiento: si el test es par → Physical, si es impar → Special
            MoveType tipo = (expected % 2 == 0) ? MoveType.Physical : MoveType.Special;
            Move move = new Move("TestMove", Type.Rock, tipo) { Power = pwr };

            double dmg = DamageCalculator.Calculate(attacker, defender, move, mod);

            Assert.That(dmg, Is.EqualTo(expected));
        }
    }

}
