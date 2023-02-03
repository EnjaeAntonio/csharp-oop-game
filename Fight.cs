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
        }
        public void MonsterTurn()
        {
            int damage = Monster.Strength - Hero.BaseDefence - Hero.EquippedArmour.ArmourPower;
            Hero.CurrentHealth -= damage;
        }

        public void Win()
        {
            if (Monster.CurrentHealth <= 0)
            {
                Console.WriteLine("Hero wins!");
            }
        }

        public void Lose()
        {
            if (Hero.CurrentHealth <= 0)
            {
                Console.WriteLine("Hero loses.");
            }
        }
    }
}
