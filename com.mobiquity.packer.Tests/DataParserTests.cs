using com.mobiquity.packer.Exceptions;
using com.mobiquity.packer.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace com.mobiquity.packer.Tests
{
    public class DataParserTests
    {
        private readonly Mock<IFileValidator> _fileValidator;
        private readonly Mock<IDataValidator> _dataValidator;

        public DataParserTests()
        {
            _fileValidator = new Mock<IFileValidator>();
            _dataValidator = new Mock<IDataValidator>();
        }

        [Fact]
        public void ThrowsExcptionIfFileValidatorReturnsFasle()
        {
            // Arrange
            var errorMessage = "ErrorMessage";
            var dataParser = new DataParser(_fileValidator.Object, _dataValidator.Object);
            _fileValidator.Setup(f => f.Validate(It.IsAny<string>()))
                .Returns(new Dto.ValidationResponse(false, errorMessage));

            // Act & Assert
            var ex = Assert.Throws<APIException>(() => dataParser.Parse("filePath"));
            Assert.Equal(errorMessage, ex.Message);
        }
    }
}
