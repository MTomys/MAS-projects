using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThirdMiniProject.DataValidators.AbstractClassInheritanceValidators;

namespace ThirdMiniProject.Inheritance.AbstractClassInheritance
{
    public class WebDataProvider : DataProvider
    {
        public WebDataProvider(string source)
        {
            Source = source;
        }

        public override string Source
        {
            get => base.Source;
            set => base.Source = (WebDataProviderDataValidator.ValidateSource(value)) ? value : "";
        }

        public override string GetData()
        {
            using var client = new WebClient();
            string content = client.DownloadString(Source);
            return content;
        }
    }
}

