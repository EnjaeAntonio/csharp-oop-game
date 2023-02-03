using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Weapon
    {
        public string Name { get; set; }
        public int WeaponPower { get; set; }

        public Weapon (string name, int weaponPower)
        {
            Name = name;
            WeaponPower = weaponPower;
        }
    }
}
