using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace API1.IntegrationTests.Attributes
{
    [ExcludeFromCodeCoverage]
    [AttributeUsage(AttributeTargets.Property)]
    public class SeedDataAttribute : Attribute
    {
        public SeedDataAttribute(string file)
        {
            File = file;
        }

        public string File { get; }
    }
}
