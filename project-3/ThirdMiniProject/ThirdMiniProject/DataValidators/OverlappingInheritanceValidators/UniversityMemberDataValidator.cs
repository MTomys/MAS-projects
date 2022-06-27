using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.Inheritance.OverlappingInheritance;

namespace ThirdMiniProject.DataValidators.OverlappingInheritanceValidators
{
    public class UniversityMemberDataValidator
    {
        public static bool ValidateGeneralStrings(string someString)
        {
            if (String.IsNullOrEmpty(someString))
            {
                throw new ArgumentException($"Argument is null or empty: {nameof(someString)}");
            }
            return true;
        }

        public static bool ValidateGeneralIds(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException($"Argument must be more than zero: {nameof(id)}");
            }
            return true;
        }

        public static bool ValidateRole(UniversityMember universityMember, UniversityMemberRole universityMemberRole)
        {
            if (!universityMember.Roles.Contains(universityMemberRole))
            {
                throw new InvalidOperationException($"The university member {nameof(universityMember)} does not have the required role {nameof(universityMemberRole)}");
            }

            return true;
        }
    }
}

