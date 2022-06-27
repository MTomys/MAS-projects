using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMiniProject.Inheritance.MultiAspectInheritance
{
    public class Car
    {
        private readonly bool _isCabriolet;
        private readonly string _modelName;
        private readonly int _numberOfDoors;
        public Car(bool isCabriolet, string modelName, int numberOfDoors)
        {
            _isCabriolet = isCabriolet;
            _modelName = modelName;
            _numberOfDoors = numberOfDoors;
        }
        public bool IsCabriolet => _isCabriolet;
        public string ModelName => _modelName;
        public int NumberOfDoors => _numberOfDoors;

        public void CloseRoof()
        {
            if (!IsCabriolet)
            {
                throw new InvalidOperationException("Cannot open retractable roof in a coupe!");
            }
            Console.WriteLine("Closing retractable rooftop...");
        }

        public void OpenRoof()
        {
            if (!IsCabriolet)
            {
                throw new InvalidOperationException("Cannot open retractable roof in a coupe!");
            }
            Console.WriteLine("Opening retractable rooftop...");
        }

        public void ClosePanoramicRooftop()
        {
            if (IsCabriolet)
            {
                throw new InvalidOperationException("Cannot open panoramic roof in a cabrio!");
            }
            Console.WriteLine("Closing panoramic roof...");
        }

        public void OpenPanoramicRooftop()
        {
            if (IsCabriolet)
            {
                throw new InvalidOperationException("Cannot open panoramic roof in a cabrio!");
            }
            Console.WriteLine("Opening panoramic roof...");
        }
    }
}
