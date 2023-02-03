using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Fight
    {
        private Hero _hero;
        private Monster _monster;
        public Hero Hero { get { return _hero; } }
        public Monster Monster { get { return _monster; } }
        int potion = 5;
        public Fight(Hero hero, Monster monster)
        {
            _hero = hero;
            _monster = monster;
        }
        public void HeroTurn(Monster monsterObject)
        {
            Console.WriteLine("Hero's turn");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Use Potion");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    int damage = Hero.BaseStrength + Hero.EquippedWeapon.WeaponPower;
                    Monster.CurrentHealth -= damage;
                    Console.WriteLine($"{Hero.Name} deals {damage} damage to {Monster.Name}!");
                    Console.WriteLine($"{Monster.Name} has {Monster.CurrentHealth} health remaining");
                    break;
                case 2:
                    if (potion > 0)
                    {
                        Hero.CurrentHealth += 20;
                        Console.WriteLine($"{Hero.Name} uses a potion and restores 20 health.");
                        Console.WriteLine($"{Hero.Name} now has {Hero.CurrentHealth} health.");
                        potion--;
                    }
                    else
                    {
                        Console.WriteLine("No more potions left.");
                    }   
                    break;
            }
        }

        public void ResetHealth()
        {
            Hero.CurrentHealth = Hero.OriginalHealth;
            Monster.CurrentHealth = Monster.OriginalHealth;
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
                Hero.Coins += Monster.CoinReward;
                Console.WriteLine($"You won the fight and earned {Monster.CoinReward}");
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
