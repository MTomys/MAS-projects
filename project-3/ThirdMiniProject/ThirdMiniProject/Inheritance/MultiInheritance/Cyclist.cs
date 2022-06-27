using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.Inheritance.MultiInheritance.Interfaces;

namespace ThirdMiniProject.Inheritance.MultiInheritance
{
    public class Cyclist : Athlete, ICyclist
    {
        private double _distanceCycled;

        public Cyclist(string name, DateTime birthDate, double distanceCycled) : base(name, birthDate)
        {
            DistanceCycled = distanceCycled;
        }

        public double DistanceCycled { get => _distanceCycled; set => _distanceCycled = value; }

        public double GetCyclingScore()
        {
            return _distanceCycled * 5;
        }
    }
}
