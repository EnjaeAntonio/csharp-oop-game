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
            Console.WriteLine($"{Hero.Name}'s turn!");
            Console.WriteLine("1. Light Attack");
            Console.WriteLine("2. Heavy Attack");
            Console.WriteLine("3. Use Potion");
            int choice = Int32.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    LightAttack();
                    break;
                case 2:
                    HeavyAttack();
                    break;
                case 3:
                    UsePotion();
                    break;
            }
        }

        public void LightAttack()
        {
            int heroDamage = Hero.BaseStrength + Hero.EquippedWeapon.WeaponPower;
            Monster.CurrentHealth -= heroDamage;
            Console.WriteLine("--- Hero ---");
            Console.WriteLine($"{Hero.Name} deals {heroDamage} damage to {Monster.Name}!");
            Console.WriteLine($"{Monster.Name} has {Monster.CurrentHealth} health remaining");
            Console.WriteLine();
        }
        
        public void HeavyAttack()
        {
            if (Hero.EquippedWeapon.NumOfSpecial > 0)
            {
                int specialAttack = Hero.EquippedWeapon.SpecialAttack;
                Monster.CurrentHealth -= specialAttack;
                Hero.EquippedWeapon.NumOfSpecial--;
                Console.WriteLine("--- Hero ---");
                Console.WriteLine($"{Hero.Name} deals {specialAttack} damage to {Monster.Name}!");
                Console.WriteLine($"{Monster.Name} has {Monster.CurrentHealth} health remaining");
                Console.WriteLine($" You have {Hero.EquippedWeapon.NumOfSpecial} Heavy Attacks left!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("You are out of special attacks!");

            }
        }

        public void ResetHeavyAttack()
        {
            Hero.EquippedWeapon.NumOfSpecial = Hero.EquippedWeapon.OriginalNumOfSpecial;
        }

        public void UsePotion()
        {
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
        }

        public void ResetHealth()
        {
            Hero.CurrentHealth = Hero.OriginalHealth;
            Monster.CurrentHealth = Monster.OriginalHealth;
        }
        public void MonsterTurn()
        {
            Console.WriteLine("--- Monster ---");
            int monsterDamage = Monster.Strength - (Hero.BaseDefence + Hero.EquippedArmour.ArmourPower);
            Hero.CurrentHealth -= monsterDamage;
            Console.WriteLine($"{Monster.Name} deals {monsterDamage} damage to {Hero.Name}!");
            Console.WriteLine($"{Hero.Name} has {Hero.CurrentHealth} health remaining");
            Console.WriteLine();
        }


        public void Win()
        {
            if (Monster.CurrentHealth <= 0)
            {
                Console.WriteLine($"{Hero.Name} has defeated {Monster.Name} in an epic battle!");
                Hero.Coins += Monster.CoinReward;
                Console.WriteLine($"You won the fight and earned {Monster.CoinReward} coins!");
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
