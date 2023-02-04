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
        public int SpecialAttack { get; set; }
        public int NumOfSpecial { get; set; }
        public int OriginalNumOfSpecial { get; set; }

        public Weapon (string name, int weaponPower, int specialAttack, int numOfSpecial, int originalNumOfSpecial )
        {
            Name = name;
            WeaponPower = weaponPower;
            SpecialAttack = specialAttack;
            NumOfSpecial = numOfSpecial;
            OriginalNumOfSpecial = originalNumOfSpecial;
        }
    }
}
