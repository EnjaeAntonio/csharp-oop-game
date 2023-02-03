using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Monster(string name, int strength, int defense, int originalHealth, int currentHealth)
        {
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHealth = originalHealth;
            CurrentHealth = currentHealth;
        }
    }
}
