using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMiniProject.Inheritance.MultiAspectInheritance
{
    public class Limousine : Car
    {
        public readonly bool Has10Seats = true;

        public Limousine(bool isCabriolet, string modelName, int numberOfDoors) : base(isCabriolet, modelName, numberOfDoors)
        {
        }
    }
}
