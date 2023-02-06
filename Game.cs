using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Game
    {
        private Hero hero;
        private Monster monster;
        private List<Monster> Monster = new List<Monster>
    {
        new Monster("Goblin", 15, 10, 50, 50, 3),
        new Monster("Orc", 20, 20, 60, 60, 5),
        new Monster("Troll", 30, 25, 75, 75, 7),
        new Monster("Dragon", 50, 50, 150, 150, 12),
        new Monster("Demon", 75, 75, 200, 200, 18)
    };
        private List<Weapon> Weapons = new List<Weapon>
    {
        new Weapon("Dagger", 5, 15, 5, 5),
        new Weapon("Sword", 10, 20, 4, 4),
        new Weapon("Mace", 15, 30, 3, 3),
        new Weapon("Axe", 20, 40, 2, 2),
        new Weapon("Greatsword", 25, 75, 1, 1)
    };
        private List<Armour> Armours = new List<Armour>
    {
        new Armour("Leather", 5),
        new Armour("Chainmail", 10),
        new Armour("Armor Plate", 12),
        new Armour("Demonic Plate", 15),
        new Armour("Divine Plate", 20)
    };
        public Fight Fight { get; set; }
        
        public Game (Hero hero)
        {
            this.hero = hero;
        }
        public void Start()
        {
            Console.WriteLine($"Welcome to Edge's Conquerer!");
            Console.WriteLine("Enter your username!");
            hero.Name = Console.ReadLine();

            bool running = true;

            while (running)
            {
                Console.WriteLine("--- Main Menu ---");
                Console.WriteLine("1. Start Fight!");
                Console.WriteLine("2. Inventory");
                Console.WriteLine("3. Stats");
                Console.WriteLine("4. Change Weapon");
                Console.WriteLine("5. Change Armour");
                Console.WriteLine("6. Upgrade your Character");
                Console.WriteLine("7. Quit");
                Console.WriteLine("Enter your choice");

                int choice = Int32.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        FightSequence();
                        break;
                    case 2:
                        hero.GetInventory();
                        break;
                    case 3:
                        hero.DisplayStats();
                        break;
                    case 4:
                        ChooseWeapon();
                        break;
                    case 5:
                        ChooseArmour();
                        break;
                    case 6:
                        Upgrade();
                        break;
                    case 7:
                        Console.WriteLine("Exiting the game");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Error input try again");
                        choice = Int32.Parse(Console.ReadLine());
                        break;
                }
            }
        }

        private void FightSequence()
        {
            
            Console.WriteLine("Choose a monster to fight!");
            for (int i = 0; i < Monster.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Monster[i].Name}");
            }
            Console.WriteLine("Enter the number of the monster you want to fight:");
            int monsterChoice = Int32.Parse(Console.ReadLine());
            monster = Monster[monsterChoice - 1];
            Fight = new Fight(hero, monster);

            bool isRunning = true;

            while (isRunning)
            {
                hero.GamesPlayed++;
                while (hero.CurrentHealth > 0 && monster.CurrentHealth > 0)
                {
                    Console.WriteLine($"Now attacking {monster.Name}!");
                    Fight.HeroTurn(monster);
                    if (monster.CurrentHealth > 0)
                    {
                        Fight.MonsterTurn();
                    }
                }
                if (hero.CurrentHealth <= 0)
                {
                    hero.CurrentHealth= 0;
                    Fight.Lose();
                    isRunning = false;
                }
                else if (monster.CurrentHealth <= 0)
                {
                    monster.CurrentHealth = 0;
                    Fight.Win();
                    isRunning = false;
                }
                Fight.ResetHealth();
                Fight.ResetHeavyAttack();
            }
        }

        int coinsSpent = 0;
        private void Upgrade()
        {
            Console.WriteLine("--- Upgrade Your Character ---");
            Console.WriteLine("1. Increase Base Strength");
            Console.WriteLine("2. Increase Base Defence");
            Console.WriteLine("3. Increase Current Health");
            Console.WriteLine("4. Exit");
            int choice = Int32.Parse(Console.ReadLine());

            if(choice == 1)
            {
                Console.WriteLine($"Coins: {hero.Coins}");
                Console.WriteLine($"1 Coin = 1 Strength");
                Console.WriteLine("Enter how many coins you would like to spend");
                coinsSpent = Int32.Parse(Console.ReadLine());
                if (coinsSpent <= hero.Coins)
                {
                    hero.Coins -= coinsSpent;
                    hero.BaseStrength += coinsSpent;
                    Console.WriteLine($"Your strength is now {hero.BaseStrength}");
                    Console.WriteLine($"Current Balance: {hero.Coins}");

                }
                else
                {
                    Console.WriteLine($"Insufficient funds");
                    
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine($"Coins: {hero.Coins}");
                Console.WriteLine($"1 Coin = 1 Defence");
                Console.WriteLine("Enter how many coins you would like to spend");
                coinsSpent = Int32.Parse(Console.ReadLine());

                if (coinsSpent <= hero.Coins)
                {
                    hero.Coins -= coinsSpent;
                    hero.BaseDefence += coinsSpent;
                    Console.WriteLine($"Your defence is now {hero.BaseDefence}");
                    Console.WriteLine($"Current Balance: {hero.Coins}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Insufficient funds");
                    
                }
            } else if (choice == 3)
            {
                Console.WriteLine($"Coins: {hero.Coins}");
                Console.WriteLine($"1 Coin = 1 Health");
                Console.WriteLine("Enter how many coins you would like to spend");
                coinsSpent = Int32.Parse(Console.ReadLine());

                if (coinsSpent <= hero.Coins)
                {
                    hero.Coins -= coinsSpent;
                    hero.CurrentHealth += coinsSpent;
                    Console.WriteLine($"Your health is now {hero.CurrentHealth}");
                    Console.WriteLine($"Current Balance: {hero.Coins}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Insufficient funds");
                    
                }
            }else if (choice == 4)
            {
                Console.WriteLine("You did not spend any coins.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please choose a number between 1 and 4.");
            }
        }

        private void ChooseWeapon()
        {
            Console.WriteLine("--- Choose Weapon ---");
            for (int i = 0; i < Weapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Weapons[i].Name} ({Weapons[i].WeaponPower})");
            }
            Console.WriteLine("Enter the number of the weapon you want to equip");
            int weaponChoice = Int32.Parse(Console.ReadLine());
            hero.EquippedWeapon = Weapons[weaponChoice - 1];
        }

        private void ChooseArmour()
        {
            Console.WriteLine("--- Choose Armour ---");
            for (int i = 0; i < Armours.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Armours[i].Name} ({Armours[i].ArmourPower})");
            }
            Console.WriteLine("Enter the number of armour you want to equip");
            int armourChoice = Int32.Parse(Console.ReadLine());
            hero.EquipArmor(Armours[armourChoice - 1]);
        }
    }
}
