using System;
using System.Collections.Generic;
using System.Text;

namespace com.mobiquity.packer.Dto
{
    public class PackageData
    {
        public PackageData()
        {
            Items = new List<Item>();
        }
        public List<Item> Items { get; set; }
        public int MaxWeight { get; set; }
    }
}
