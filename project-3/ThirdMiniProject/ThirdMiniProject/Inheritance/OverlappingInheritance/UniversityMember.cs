using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.DataValidators.OverlappingInheritanceValidators;

namespace ThirdMiniProject.Inheritance.OverlappingInheritance
{
    public enum UniversityMemberRole
    {
        Student,
        Professor
    }

    public class UniversityMember
    {
        // Base attributes
        private string _firstName;
        private string _lastName;
        private readonly ISet<UniversityMemberRole> _roles;

        // Student attributes
        private int _studentId;
        private readonly ISet<string> _courses;
        private string _studies;

        // Professor attributes
        private int _professorId;
        private readonly ISet<string> _coursesToTeach;

        public UniversityMember(string firstName, string lastName, ISet<UniversityMemberRole> roles)
        {
            FirstName = firstName;
            LastName = lastName;
            _roles = new HashSet<UniversityMemberRole>(roles);
        }

        public string FirstName
        {
            get => _firstName;

            set => _firstName = (UniversityMemberDataValidator.ValidateGeneralStrings(value)) ? value : "";
        }

        public string LastName
        {
            get => _lastName;

            set => _lastName = (UniversityMemberDataValidator.ValidateGeneralStrings(value)) ? value : "";
        }

        public HashSet<UniversityMemberRole> Roles { get => new HashSet<UniversityMemberRole>(_roles); }

        public string FullName { get => $"{_firstName} {_lastName}"; }

        // Student methods, properties
        public int StudentId
        {
            get
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Student);
                return _studentId;
            }

            set
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Student);
                _studentId = (UniversityMemberDataValidator.ValidateGeneralIds(value)) ? value : -1;
            }
        }

        public string Studies
        {
            get
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Student);
                return _studies;
            }

            set
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Student);
                _studies = (UniversityMemberDataValidator.ValidateGeneralStrings(value)) ? value : "";
            }
        }

        public HashSet<string> Courses
        {
            get
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Student);
                return new HashSet<string>(_courses);
            }
        }

        public void AddCourse(string course)
        {
            UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Student);

            if (UniversityMemberDataValidator.ValidateGeneralStrings(course))
            {
                _courses.Add(course);
            }
        }

        public void RemoveCourse(string course)
        {
            UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Student);
            UniversityMemberDataValidator.ValidateGeneralStrings(course);
            if (!_courses.Contains(course))
            {
                throw new InvalidOperationException($"{nameof(course)} is not present in the courses set");
            }
            _courses.Remove(course);
        }

        // Professor methods, properties
        public int ProfessorId
        {
            get
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Professor);
                return _professorId;
            }

            set
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Professor);
                _professorId = (UniversityMemberDataValidator.ValidateGeneralIds(ProfessorId)) ? value : -1;
            }
        }

        public HashSet<string> CoursesToTeach
        {
            get
            {
                UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Professor);
                return new HashSet<string>(_coursesToTeach);
            }
        }

        public void AddCourseToTeach(string courseToTeach)
        {
            UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Professor);
            if (UniversityMemberDataValidator.ValidateGeneralStrings(courseToTeach))
            {
                _coursesToTeach.Add(courseToTeach);
            }
        }

        public void RemoveCourseToTeach(string course)
        {
            UniversityMemberDataValidator.ValidateRole(this, UniversityMemberRole.Professor);
            UniversityMemberDataValidator.ValidateGeneralStrings(course);
            if (!_courses.Contains(course))
            {
                throw new InvalidOperationException($"{nameof(course)} is not present in the courses set");
            }
            _courses.Remove(course);
        }
    }
}
