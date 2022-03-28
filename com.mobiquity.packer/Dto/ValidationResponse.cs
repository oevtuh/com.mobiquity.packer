using System;
using System.Collections.Generic;
using System.Text;

namespace com.mobiquity.packer.Dto
{
    public class ValidationResponse
    {
        public ValidationResponse(bool isValid, string error = null)
        {
            IsValid = isValid;
            Error = error;
        }

        public bool IsValid { get; set; }

        public string Error { get; set; }
    }
}
