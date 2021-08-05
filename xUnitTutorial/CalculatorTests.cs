using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace xUnitTutorial
{
    public class CalculatorTests
    {
        private readonly Calculator _sut; // system under test

        public CalculatorTests()
        {
            _sut = new Calculator();
        }

        [Fact(Skip = "This test sucks")]
        public void AddTwoNumbersShouldEqualTheirEqual()
        {
            _sut.Add(5);
            _sut.Add(8);
            Assert.Equal(13, _sut.Value);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(28.4, 14.2, 14.2)]
        [InlineData(13, 9.29, 3.71)]
        [InlineData(5928.2421, 5821, 107.2421)]
        public void AddTwoNumbersShouldEqualTheirEqualTheory(decimal expected, decimal firstToAdd, decimal secondToAdd)
        {
            _sut.Add(firstToAdd);
            _sut.Add(secondToAdd);
            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void AddManyNumbersShouldEqualTheirEqualTheory(decimal expected, params decimal[] valuesToAdd)
        {
            foreach (var val in valuesToAdd)
            {
                _sut.Add(val);
            }

            Assert.Equal(expected, _sut.Value);
        }

        [Theory]
        [ClassData(typeof(DivisionTestData))]
        public void DivideManyNumbersTheory(decimal expected, params decimal[] valuesToAdd)
        {
            foreach (var val in valuesToAdd)
            {
                _sut.Divide(val);
            }

            Assert.Equal(expected, _sut.Value);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { 15, new decimal[] { 10, 5 } };
            yield return new object[] { 15, new decimal[] { 5, 5, 5 } };
            yield return new object[] { -10, new decimal[] { -30, 20 } };
        }

        public class DivisionTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 30, new decimal[] { 60, 2 } };
                yield return new object[] { 0, new decimal[] { 0, 1 } };
                yield return new object[] { 1, new decimal[] { 4124, 4124 } };

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
