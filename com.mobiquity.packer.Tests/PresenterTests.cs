using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace com.mobiquity.packer.Tests
{
    public class PresenterTests
    {
        [Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, "1,2,3\n" })]
        [InlineData(new object[] { new int[] { }, "-\n" })]
        public void PresentedTests(params object[] data)
        {
            // Arrange 
            var presenter = new Presenter();
            // Act 
            var result = presenter.Present(((int[])data[0]).OfType<int>().ToList());

            // Assert
            Assert.Equal(data[1], result);
        }
    }
}
