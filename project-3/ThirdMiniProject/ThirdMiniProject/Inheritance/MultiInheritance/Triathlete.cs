using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.Inheritance.MultiInheritance.Interfaces;

namespace ThirdMiniProject.Inheritance.MultiInheritance
{
    public class Triathlete : Swimmer, ICyclist, IRunner
    {
        private double _distanceRan;
        private double _distanceCycled;

        public Triathlete(string name, DateTime birthDate, double distanceSwam, double distanceRan, double distanceCycled) 
            : base(name, birthDate, distanceSwam)
        {
            DistanceRan = distanceRan;
            DistanceCycled = distanceCycled;
        }

        public double DistanceRan { get => _distanceRan; set => _distanceRan = value; }
        public double DistanceCycled { get => _distanceCycled; set => _distanceCycled = value; }

        public double GetCyclingScore()
        {
            return DistanceCycled * 0.25;         
        }

        public double GetRunningScore()
        {
            return DistanceRan * 2;        
        }

        public double GetTriathleteScore()
        {
            return GetCyclingScore() + GetRunningScore() + base.GetSwimmingScore();
        }
    }
}
