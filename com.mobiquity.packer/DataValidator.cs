using com.mobiquity.packer.Dto;
using com.mobiquity.packer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace com.mobiquity.packer
{
    public class DataValidator : IDataValidator
    {
        public ValidationResponse Validate(List<PackageData> data)
        {
            foreach (PackageData dataItem in data)
            {
                if(dataItem.MaxWeight > 100)
                {
                    return new ValidationResponse(false, "Max weight that a package can take is ≤ 100");
                }

                if (dataItem.Items.Count > 15)
                {
                    return new ValidationResponse(false, "There might be up to 15 items you need to choose from");
                }

                foreach (var item in dataItem.Items)
                {
                    if (item.Weight > 100)
                    {
                        return new ValidationResponse(false, "Max weight of an item should be ≤ 100");
                    }

                    if (item.Cost > 100)
                    {
                        return new ValidationResponse(false, "Max cost of an item  should be ≤ 100");
                    }
                }
            }

            return new ValidationResponse(true);
        }
    }
}
