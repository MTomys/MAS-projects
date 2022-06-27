using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ThirdMiniProject.Inheritance.AbstractClassInheritance;
using Xunit.Abstractions;
using System.IO;

namespace ThirdMiniProject.Tests.AbstractClassInheritance
{
    public class AbstractClassInheritanceTests
    {
        [Fact]
        public void DataProvider_ProvideDataFromDifferentSubclasses()
        {
            // Arrange
            DataProvider fileDataProvider = new FileDataProvider(@"c:\temp\MyTest.txt");
            DataProvider webDataProvider = new WebDataProvider("https://www.google.com/");

            // Act
            string someFileData = fileDataProvider.GetData();
            string someWebData = webDataProvider.GetData();

            // Assert
            Assert.IsAssignableFrom<DataProvider>(fileDataProvider);
            Assert.IsAssignableFrom<DataProvider>(webDataProvider);

            // Since it's impossible to predict current state of google.com we will just test if string is not empty
            Assert.Empty(someFileData);
            Assert.NotEmpty(someWebData);
        }
    }
}
