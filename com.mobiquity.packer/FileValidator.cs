using com.mobiquity.packer.Dto;
using com.mobiquity.packer.Interfaces;
using System.IO;
using System.Text;

namespace com.mobiquity.packer
{
    public class FileValidator : IFileValidator
    {
        public ValidationResponse Validate(string filePath)
        {
            var possiblePath = filePath.IndexOfAny(Path.GetInvalidPathChars()) == -1;
            if (!possiblePath)
            {
                return new ValidationResponse(false, "File path is not valid");
            }

            if (!File.Exists(filePath))
            {
                return new ValidationResponse(false, "File is not exists");
            }

            return new ValidationResponse(true);
        }
    }
}
