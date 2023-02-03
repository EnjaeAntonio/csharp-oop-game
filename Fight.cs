using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Fight
    {
        private Hero _hero;
        private Monster _monster;
        public Hero Hero { get { return _hero; } }
        public Monster Monster { get { return _monster; } }
        public Fight(Hero hero, Monster monster)
        {
            _hero = hero;
            _monster = monster;
        }
        public void HeroTurn()
        {
            int damage = Hero.BaseStrength + Hero.EquippedWeapon.WeaponPower; 
            Monster.CurrentHealth -= damage;
            Console.WriteLine($"{Hero.Name} deals {damage} damage to {Monster.Name}!");
            Console.WriteLine($"{Monster.Name} has {Monster.CurrentHealth} health remaining");
        }
        public void MonsterTurn()
        {
            int damage = Monster.Strength - Hero.BaseDefence - Hero.EquippedArmour.ArmourPower;
            Hero.CurrentHealth -= damage;
            Console.WriteLine($"{Monster.Name} deals {damage} damage to {Hero.Name}!");
            Console.WriteLine($"{Hero.Name} has {Hero.CurrentHealth} health remaining");
        }

        public void Win()
        {
            if (Monster.CurrentHealth <= 0)
            {
                Console.WriteLine($"{Hero.Name} has defeated {Monster.Name} in an epic battle!");
            }
        }

        public void Lose()
        {
            if (Hero.CurrentHealth <= 0)
            {
                Console.WriteLine($"{Hero.Name} has been defeated by {Monster.Name}");
            }
        }
    }
}
