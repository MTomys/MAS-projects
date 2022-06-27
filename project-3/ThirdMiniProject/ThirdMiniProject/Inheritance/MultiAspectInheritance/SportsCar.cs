using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMiniProject.Inheritance.MultiAspectInheritance
{
    public class SportsCar : Car
    {
        public readonly bool IsV8Engine = true;

        public SportsCar(bool isCabriolet, string modelName, int numberOfDoors) : base(isCabriolet, modelName, numberOfDoors)
        {
        }
    }
}
