using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.DataValidators.MultiInheritanceValidators;

namespace ThirdMiniProject.Inheritance.MultiInheritance
{
    public class Athlete
    {
        private readonly string _name;
        private readonly DateTime _birthDate;

        public Athlete(string name, DateTime birthDate)
        {
            _name = AthleteDataValidator.ValidateGeneralStrings(name) ? name : "";
            _birthDate = birthDate;        
        }

        public string Name => _name;
        public DateTime BirthDate => _birthDate;
    }
}
