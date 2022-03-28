using com.mobiquity.packer.Dto;
using com.mobiquity.packer.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace com.mobiquity.packer.Tests
{
    public class SolverTests
    {
        private readonly IPresenter _presenter;

        public SolverTests()
        {
            _presenter = new Presenter();
        }

        [Fact]
        public async Task SuccessfulSolverTest()
        {
            // Arrange
            var solver = new Solver(_presenter);

            // Act
            var response = solver.Solve(GetCorrectData());

            // Assert
            Assert.Equal(GetCorrectAnswer(), response);
        }

        private List<PackageData> GetCorrectData()
        {
            var packageData = new List<PackageData>();
            packageData.Add(new PackageData()
            {
                MaxWeight = 81,
                Items = new List<Item>() { 
                    new Item() { Index = 1, Weight = 53.38, Cost = 45},
                    new Item() { Index = 2, Weight = 88.62, Cost = 98},
                    new Item() { Index = 3, Weight = 78.48, Cost = 3},
                    new Item() { Index = 4, Weight = 72.30, Cost = 76},
                    new Item() { Index = 5, Weight = 30.18, Cost = 9},
                    new Item() { Index = 6, Weight = 46.34, Cost = 48}
                }
            });
            packageData.Add(new PackageData()
            {
                MaxWeight = 8,
                Items = new List<Item>() {
                    new Item() { Index = 1, Weight = 15.30, Cost = 34}
                }
            });
            packageData.Add(new PackageData()
            {
                MaxWeight = 75,
                Items = new List<Item>() {
                    new Item() { Index = 1, Weight = 85.31, Cost = 29},
                    new Item() { Index = 2, Weight = 14.55, Cost = 74},
                    new Item() { Index = 3, Weight = 3.98, Cost = 16},
                    new Item() { Index = 4, Weight = 26.24, Cost = 55},
                    new Item() { Index = 5, Weight = 63.69, Cost = 52},
                    new Item() { Index = 6, Weight = 76.25, Cost = 75},
                    new Item() { Index = 7, Weight = 60.02, Cost = 74},
                    new Item() { Index = 8, Weight = 93.18, Cost = 35},
                    new Item() { Index = 9, Weight = 89.95, Cost = 78},
                }
            });
            packageData.Add(new PackageData()
            {
                MaxWeight = 56,
                Items = new List<Item>() {
                    new Item() { Index = 1, Weight = 90.72, Cost = 13},
                    new Item() { Index = 2, Weight = 33.80, Cost = 40},
                    new Item() { Index = 3, Weight = 43.15, Cost = 10},
                    new Item() { Index = 4, Weight = 37.97, Cost = 16},
                    new Item() { Index = 5, Weight = 46.81, Cost = 36},
                    new Item() { Index = 6, Weight = 48.77, Cost = 79},
                    new Item() { Index = 7, Weight = 81.80, Cost = 45},
                    new Item() { Index = 8, Weight = 19.36, Cost = 79},
                    new Item() { Index = 9, Weight = 6.76, Cost = 64},
                }
            });

            return packageData;
        }

        private static string GetCorrectAnswer()
        {
            return "4\n-\n2,7\n8,9\n";
        }
    }
}
