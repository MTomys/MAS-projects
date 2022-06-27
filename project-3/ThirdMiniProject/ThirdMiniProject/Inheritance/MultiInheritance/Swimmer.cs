using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMiniProject.Inheritance.MultiInheritance
{
    public class Swimmer : Athlete
    {
        private double _distanceSwam;

        public Swimmer(string name, DateTime birthDate, double distanceSwam) : base(name, birthDate)
        {
            DistanceSwam = distanceSwam;
        }

        public double DistanceSwam { get => _distanceSwam; set => _distanceSwam = value; }

        public double GetSwimmingScore()
        {
            return _distanceSwam * 5;
        }
    }
}
