using System;
using System.IO;
using Xunit;

namespace XUnitDemo_ClassLibrary.Tests
{
    public class ExamplesTests
    {
        [Fact]
        public void ExampleLoadTextFile_ValidNameShouldWork()
        {
            string actual = Examples.ExampleLoadTextFile("This is a valid file name.");

            Assert.True(actual.Length > 0);
        }  
        
        [Fact]
        public void ExampleLoadTextFile_InvalidNameShouldFail()
        {
            Assert.Throws<ArgumentException>("file",() => Examples.ExampleLoadTextFile(""));
        }
    }
}