using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.Inheritance.MultiInheritance.Interfaces;

namespace ThirdMiniProject.Inheritance.MultiInheritance
{
    public class Runner : Athlete, IRunner
    {
        private double _distanceRan;

        public Runner(string name, DateTime birthDate, double distanceRan) : base(name, birthDate)
        {
            DistanceRan = distanceRan;
        }

        public double DistanceRan { get => _distanceRan; set => _distanceRan = value; }

        public double GetRunningScore()
        {
            return _distanceRan * 2;
        }
    }
}
