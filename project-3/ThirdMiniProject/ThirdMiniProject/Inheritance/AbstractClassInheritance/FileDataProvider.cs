using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.DataValidators.AbstractClassInheritanceValidators;

namespace ThirdMiniProject.Inheritance.AbstractClassInheritance
{
    public class FileDataProvider : DataProvider
    {
        public FileDataProvider(string source)
        {
            Source = source;
        }

        public override string Source
        {
            get => base.Source;
            set => base.Source = value;       
        }

        public override string GetData()
        {
            FileDataProviderDataValidator.ValidateSource(Source);
            if (!File.Exists(Source))
            {
                throw new ArgumentException($"File {nameof(Source)} does not exist. Aborting reading...");
            }

            return File.ReadAllText(Source);
        }
    }
}

