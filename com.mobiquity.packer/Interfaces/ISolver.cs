using com.mobiquity.packer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.mobiquity.packer.Interfaces
{
    /// <summary>
    /// Solves the Knapsack problem by dynamic programming 
    /// </summary>
    public interface ISolver
    {
        string Solve(List<PackageData> data);
    }
}
