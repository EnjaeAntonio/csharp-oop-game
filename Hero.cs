using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Hero
    {
        public string Name { get; set; }
        public int BaseStrength { get; set; } = 10;
        public int BaseDefence { get; set; } = 10;
        public int OriginalHealth { get; set; } = 100;
        public int CurrentHealth { get; set; } = 100;
        public Weapon EquippedWeapon { get; set; }
        public Armour EquippedArmour { get; set; }

        public Game game { get; set; }
        public Hero(string name, int baseStrength, int baseDefence, Weapon equippedWeapon, Armour equippedArmor)
        {
            Name = name;
            BaseStrength = baseStrength;
            BaseDefence = baseDefence;
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
            Console.WriteLine($"Equipped Weapon: {EquippedWeapon.Name} Damage: {EquippedWeapon.WeaponPower}");
            Console.WriteLine($"Equipped Armour: {EquippedArmour.Name} Defence: {EquippedArmour.ArmourPower}");
        }
        public void EquipWeapon(Weapon weapon)
        {
            EquippedWeapon = weapon;
        }

        public void EquipArmor(Armour armour)
        {
            EquippedArmour = armour;
            BaseDefence += armour.ArmourPower;
        }
    }
}
