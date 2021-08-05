using System;
using Xunit;
using Xunit.Abstractions;

namespace xUnitTutorial
{
    [CollectionDefinition("Guid generator")]
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator>{}

    [Collection("Guid generator")]
    public class GuidGeneratorTestsOne
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestsOne(GuidGenerator guidGenerator, ITestOutputHelper output)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was: {guid}");
        }     

        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was: {guid}");
        }
        
    } 
    
    [Collection("Guid generator")]
    public class GuidGeneratorTestsTwo
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;

        public GuidGeneratorTestsTwo(GuidGenerator guidGenerator, ITestOutputHelper output)
        {
            _output = output;
            _guidGenerator = guidGenerator;
        }

        [Fact]
        public void GuidTestOne()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was: {guid}");
        }     

        [Fact]
        public void GuidTestTwo()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was: {guid}");
        }
        
    }
}