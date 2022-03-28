using com.mobiquity.packer.Dto;
using com.mobiquity.packer.Exceptions;
using com.mobiquity.packer.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace com.mobiquity.packer
{
    public class DataParser : IDataParser
    {
        private readonly IFileValidator _fileValidator;
        private readonly IDataValidator _dataValidator;

        public DataParser(IFileValidator fileValidator, IDataValidator dataValidator)
        {
            _fileValidator = fileValidator;
            _dataValidator = dataValidator;
        }

        public List<PackageData> Parse(string filePath)
        {
            var validatorResponse = _fileValidator.Validate(filePath);

            if (!validatorResponse.IsValid)
            {
                throw new APIException(validatorResponse.Error);
            }

            var packagesData = new List<PackageData>();

            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(filePath))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    var packageData = new PackageData();
                    string[] parts = line.Split(':');

                    packageData.MaxWeight = Int32.Parse(parts[0].Trim());
                    var things = parts[1].Trim().Split(' ');
                    foreach(var thing in things) {
                        var thingData = thing.Trim('(').Trim(')').Split(',');

                        packageData.Items.Add(new Item
                        {
                            Index = Int32.Parse(thingData[0]),
                            Weight = (int)(Double.Parse(thingData[1], CultureInfo.InvariantCulture)),
                            Cost = Int32.Parse(new String(thingData[2].Where(char.IsDigit).ToArray())),
                        });
                    }

                    packagesData.Add(packageData);
                }
            }

            var dataValidatorResponse = _dataValidator.Validate(packagesData);

            if (!dataValidatorResponse.IsValid)
            {
                throw new APIException(dataValidatorResponse.Error);
            }

            return packagesData;
        }
    }
}
