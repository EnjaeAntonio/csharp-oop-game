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
        public int BaseStrength { get; set; }
        public int BaseDefence { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armour EquippedArmour { get; set; }
        public int Coins { get; set; }

        public Game game { get; set; }
        public Hero(string name, int baseStrength, int baseDefence, int originalHealth, int currentHealth, Weapon equippedWeapon, Armour equippedArmor, int coins)
        {
            Name = name;
            OriginalHealth= originalHealth;
            CurrentHealth= currentHealth;
            BaseStrength = baseStrength;
            BaseDefence = baseDefence;
            EquippedWeapon = equippedWeapon;
            EquippedArmour = equippedArmor;
            Coins = coins;
        }
        public void DisplayStats()
        {
            Console.WriteLine("Stats");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Base Strength: {BaseStrength}");
            Console.WriteLine($"Base Defence: {BaseDefence}");
            Console.WriteLine($"Health: {CurrentHealth}");
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
