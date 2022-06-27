using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdMiniProject.Inheritance.AbstractClassInheritance
{
    public abstract class DataProvider
    {
        private string _source;

        public virtual string Source
        {
            get => _source;

            set => _source = value ?? throw new ArgumentNullException(nameof(value));
        }

        public abstract string GetData();
    }
}

