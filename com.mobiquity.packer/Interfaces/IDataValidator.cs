using com.mobiquity.packer.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.mobiquity.packer.Interfaces
{
    /// <summary>
    /// Validates data according bussiness requirements
    /// </summary>
    public interface IDataValidator
    {
        ValidationResponse Validate(List<PackageData> data);
    }
}
