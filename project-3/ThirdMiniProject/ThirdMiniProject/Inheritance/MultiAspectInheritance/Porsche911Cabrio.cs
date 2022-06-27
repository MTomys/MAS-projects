using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMiniProject.Inheritance.MultiAspectInheritance
{
    public class Porsche911Cabrio : SportsCar    
    {
        private int _horsePower;

        public Porsche911Cabrio(int numberOfDoors) : base(true, "Porsche 911", numberOfDoors)
        {
            HorsePower = 550;        
        }
        public int HorsePower { get => _horsePower; set => _horsePower = value; }
    }
}
