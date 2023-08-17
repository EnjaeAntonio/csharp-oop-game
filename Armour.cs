using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameAssignment
{
    public class Armour
    {
        public string Name { get; set; }
        public int ArmourPower { get; set; }

        public Armour(string name, int armourPower)
        {
            Name = name;
            ArmourPower = armourPower;
        }
    }
}
