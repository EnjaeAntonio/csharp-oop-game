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
        private Weapon _equippedWeapon;
        private Armour _equippedArmour;
        
        public string Name { get; set; }
        public int BaseStrength { get { return _baseStrength ; } }
        public int BaseDefence { get { return _baseDefence ; } }
        public int OriginalHealth { get; set; } = 100;
        public int CurrentHealth { get; set; } = 100;
        public Weapon EquippedWeapon { get { return _equippedWeapon ; } }
        public Armour EquippedArmour { get { return _equippedArmour ; } }

        public Hero(string name, int baseStrength, int baseDefence, Weapon equippedWeapon, Armour equippedArmor)
        {
            _name = name;
            _baseStrength = baseStrength;
            _baseDefence = baseDefence;
            _equippedWeapon = equippedWeapon;
            _equippedArmour = equippedArmor;
        }
        public void getStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Base Strength: {BaseStrength}");
            Console.WriteLine($"Base Defence: {BaseDefence}");
            Console.WriteLine($"Current Health: {CurrentHealth}");
        }

        public void GetInventory()
        {
            Console.WriteLine($"Equipped Weapon: {EquippedWeapon}");
            Console.WriteLine($"Equipped Armour: {EquippedArmour}");
        }
        public void EquipWeapon(Weapon weapon)
        {
            _equippedWeapon = weapon;
        }

        public void EquipArmor(Armour armour)
        {
            _equippedArmour = armour;
        }
    }
}
