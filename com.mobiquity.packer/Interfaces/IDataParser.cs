using com.mobiquity.packer.Dto;
using System.Collections.Generic;

namespace com.mobiquity.packer.Interfaces
{
    /// <summary>
    /// Parses data from text file.
    /// </summary>
    public interface IDataParser
    {
        List<PackageData> Parse(string filePath);
    }
}
