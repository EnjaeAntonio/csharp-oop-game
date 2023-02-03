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
        public List<Monster> Monster = new List<Monster>
    {
        new Monster("Goblin", 10, 5, 20),
        new Monster("Orc", 20, 10, 20),
        new Monster("Troll", 30, 15, 50),
        new Monster("Dragon", 40, 20, 150),
        new Monster("Demon", 50, 25, 200)
    };
        private List<Weapon> weapons = new List<Weapon>
    {
        new Weapon("Dagger", 5),
        new Weapon("Sword", 10),
        new Weapon("Mace", 15),
        new Weapon("Axe", 20),
        new Weapon("Greatsword", 25)
    };
        private List<Armour> armours = new List<Armour>
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
        }

        private void MainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Display Statistics");
            Console.WriteLine("2. Display Inventory");
            Console.WriteLine("3. Fight");
            Console.WriteLine("Please choose an option:");

        }

    }
}
