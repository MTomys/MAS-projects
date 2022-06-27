using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.Inheritance.MultiInheritance;
using ThirdMiniProject.Inheritance.MultiInheritance.Interfaces;
using Xunit;


namespace ThirdMiniProject.Tests.MultiInheritance
{
    public class MultiInheritanceTests
    {

        [Fact]
        public void Triathlete_CheckIfIsProperlySubclassed()
        {
            // Arrange
            Triathlete triathlete = new Triathlete("Michal T", new DateTime(2000, 8, 11), 5, 10, 15);

            // Act

            // Assert
            Assert.IsAssignableFrom<Athlete>(triathlete);
            Assert.IsAssignableFrom<Swimmer>(triathlete);
            Assert.IsAssignableFrom<IRunner>(triathlete);
            Assert.IsAssignableFrom<ICyclist>(triathlete);

            Assert.IsType<Triathlete>(triathlete);
        }
    }
}
