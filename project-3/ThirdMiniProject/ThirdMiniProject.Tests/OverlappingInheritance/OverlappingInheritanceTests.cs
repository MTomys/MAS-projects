using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.Inheritance.OverlappingInheritance;
using Xunit;
using static System.Collections.Specialized.BitVector32;

namespace ThirdMiniProject.Tests.OverlappingInheritance
{
    public class OverlappingInheritanceTests
    {

        [Fact]
        public void UniversityMember_CheckFunctionalitiesForGivenRoles()
        {
            // Arrange
            HashSet<UniversityMemberRole> noRoles = new();

            HashSet<UniversityMemberRole> studentRole = new();
            studentRole.Add(UniversityMemberRole.Student);

            HashSet<UniversityMemberRole> professorRole = new();
            professorRole.Add(UniversityMemberRole.Professor);

            HashSet<UniversityMemberRole> mixedRole = new();
            mixedRole.Add(UniversityMemberRole.Student);
            mixedRole.Add(UniversityMemberRole.Professor);

            UniversityMember universityMemberNoRoles = new UniversityMember("firstName", "lastName", noRoles);
            UniversityMember student = new UniversityMember("firstName", "lastName", studentRole);
            UniversityMember professor = new UniversityMember("firstName", "lastName", professorRole);
            UniversityMember studentAndProfessor = new UniversityMember("firstName", "lastName", mixedRole);

            // Act
            Action noRolesAction = () => universityMemberNoRoles.Courses.Add("abc");
            Action tryingToGetProfessorAttributesFromStudent = () => student.CoursesToTeach.Add("abc");
            Action tryingToGetStudentAttributesFromProfessor = () => professor.Courses.Add("abc");
            
            // Assert
            Assert.Throws<InvalidOperationException>(noRolesAction);
            Assert.Throws<InvalidOperationException>(tryingToGetProfessorAttributesFromStudent);
            Assert.Throws<InvalidOperationException>(tryingToGetStudentAttributesFromProfessor);
        }

    }
}
