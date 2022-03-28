using com.mobiquity.packer.Dto;
using com.mobiquity.packer.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace com.mobiquity.packer.Tests
{
    public class DataValidatorTests
    {
        [Theory]
        [InlineData(1, true, null)]
        [InlineData(99, true, null)]
        [InlineData(101, false, "Max weight that a package can take is ≤ 100")]
        public void ValidationResponseCheckMaxWeightTest(int maxWeight, bool isValid, string errorMessage)
        {
            // Arrange
            var packageData = new List<PackageData>();
            packageData.Add(new PackageData()
            {
                MaxWeight = maxWeight,
                Items = new List<Item>() {
                    new Item() { Index = 1, Weight = 53.38, Cost = 45}
                }
            });

            var validator = new DataValidator();

            // Acr
            var response = validator.Validate(packageData);

            // Assert
            Assert.Equal(isValid, response.IsValid);
            Assert.Equal(errorMessage, response.Error);
        }

        [Theory]
        [InlineData(1, true, null)]
        [InlineData(15, true, null)]
        [InlineData(16, false, "There might be up to 15 items you need to choose from")]
        public void ValidationResponseCheckItemsCountTest(int itemsCount, bool isValid, string errorMesssage)
        {
            // Arrange
            var packageData = new List<PackageData>();
            var dataItem = new PackageData()
            {
                MaxWeight = 70,
                Items = new List<Item>()
            };

            for (int i = 0; i < itemsCount; i++)
            {
                dataItem.Items.Add(new Item() { Index = 1, Weight = 53.38, Cost = 45 });
            }
            packageData.Add(dataItem);

            var validator = new DataValidator();

            // Acr & Assert
            var response = validator.Validate(packageData);
            Assert.Equal(isValid, response.IsValid);
            Assert.Equal(errorMesssage, response.Error);
        }

        [Theory]
        [InlineData(1, true, null)]
        [InlineData(99, true, null)]
        [InlineData(101, false, "Max weight of an item should be ≤ 100")]
        public void ValidationResponseCheckItemWeightTest(int itemWeight, bool isValid, string errorMessage)
        {
            // Arrange
            var packageData = new List<PackageData>();
            packageData.Add(new PackageData()
            {
                MaxWeight = 1,
                Items = new List<Item>() {
                    new Item() { Index = 1, Weight = itemWeight, Cost = 45}
                }
            });

            var validator = new DataValidator();

            // Acr
            var response = validator.Validate(packageData);

            // Assert
            Assert.Equal(isValid, response.IsValid);
            Assert.Equal(errorMessage, response.Error);
        }

        [Theory]
        [InlineData(1, true, null)]
        [InlineData(99, true, null)]
        [InlineData(101, false, "Max cost of an item  should be ≤ 100")]
        public void ValidationResponseCheckItemCostTest(int itemCost, bool isValid, string errorMessage)
        {
            // Arrange
            var packageData = new List<PackageData>();
            packageData.Add(new PackageData()
            {
                MaxWeight = 1,
                Items = new List<Item>() {
                    new Item() { Index = 1, Weight = 1, Cost = itemCost}
                }
            });

            var validator = new DataValidator();

            // Acr
            var response = validator.Validate(packageData);

            // Assert
            Assert.Equal(isValid, response.IsValid);
            Assert.Equal(errorMessage, response.Error);
        }
    }
}
