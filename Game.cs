using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Game
    {
        private Hero hero;
        private Monster monster;
        public List<Monster> Monster = new List<Monster>
    {
        new Monster("Goblin", 10, 5, 20, 20),
        new Monster("Orc", 20, 15, 40, 20),
        new Monster("Troll", 30, 15, 50, 50),
        new Monster("Dragon", 40, 50, 150, 150),
        new Monster("Demon", 50, 25, 200, 200)
    };
        private List<Weapon> Weapons = new List<Weapon>
    {
        new Weapon("Dagger", 5),
        new Weapon("Sword", 10),
        new Weapon("Mace", 15),
        new Weapon("Axe", 20),
        new Weapon("Greatsword", 25)
    };
        private List<Armour> Armours = new List<Armour>
    {
        new Armour("Leather", 5),
        new Armour("Chainmail", 10),
        new Armour("Plate", 15),
        new Armour("Demonic Plate", 20),
        new Armour("Divine Plate", 25)
    };
        public Fight Fight { get; set; }
        
        public Game (Hero hero)
        {
            this.hero = hero;
        }
        public void Start()
        {
            Console.WriteLine($"Welcome to the game!");
            Console.WriteLine("Please State your name!");
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
                Console.WriteLine("6. Quit");
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
                        Console.WriteLine("Exiting the game");
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
            int monsterChoice = Convert.ToInt32(Console.ReadLine());
            monster = Monster[monsterChoice - 1];
            Fight = new Fight(hero, monster);

            bool isRunning = true;

            while (isRunning)
            {
                while (hero.CurrentHealth > 0 && monster.CurrentHealth > 0)
                {
                    Fight.HeroTurn(monster);
                    if (monster.CurrentHealth > 0)
                    {
                        Fight.MonsterTurn();
                    }
                }
                if (hero.CurrentHealth <= 0)
                {
                    Fight.Lose();
                    isRunning= false;
                }
                else if (monster.CurrentHealth <= 0)
                {
                    Fight.Win();
                    isRunning= false;
                }
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
            int armourChoice= Int32.Parse(Console.ReadLine());
            hero.EquipArmor(Armours[armourChoice - 1]);
        }
    }
}
