using com.mobiquity.packer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.mobiquity.packer.Interfaces
{
    /// <summary>
    /// Checks that file path is correct, file exists.
    /// </summary>
    public interface IFileValidator
    {
        ValidationResponse Validate(string filePath);
    }
}
