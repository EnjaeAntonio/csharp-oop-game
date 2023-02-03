using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Hero
    {
        private int _baseStrength = 0;
        private int _baseDefence = 0;
        
        public string Name { get; set; }
        public int BaseStrength { get { return _baseStrength ; } }
        public int BaseDefence { get { return _baseDefence ; } }
        public int OriginalHealth { get; set; } = 100;
        public int CurrentHealth { get; set; } = 100;
        public Weapon EquippedWeapon { get; set; }
        public Armour EquippedArmour { get; set; }

        public Hero(string name, int baseStrength, int baseDefence, Weapon equippedWeapon, Armour equippedArmor)
        {
            Name = name;
            _baseStrength = baseStrength;
            _baseDefence = baseDefence;
            EquippedWeapon = equippedWeapon;
            EquippedArmour = equippedArmor;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Stats");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Base Strength: {BaseStrength}");
            Console.WriteLine($"Base Defence: {BaseDefence}");
            Console.WriteLine($"Original Health: {OriginalHealth}");
            Console.WriteLine($"Current Health: {CurrentHealth}");
        }
        public void GetInventory()
        {
            Console.WriteLine($"Equipped Weapon: {EquippedWeapon}");
            Console.WriteLine($"Equipped Armour: {EquippedArmour}");
        }
        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
        }

        public void EquipArmor(Armour armour)
        {
            EquippedArmour = armour;
        }
    }
}
