using ReviewGenerator.Core.Services;
using System;
using Xunit;
using Moq;
using ReviewGenerator.Core.Interfaces;
using System.IO;

namespace ReviewGenerator.Tests
{
    public class DataReaderServiceTestFixture
    {
        private DataReaderService dataReaderService;
        private Mock<IReviewRepository> reviewRepositoryMock;

        public DataReaderServiceTestFixture()
        {
            reviewRepositoryMock = new Mock<IReviewRepository>();
            dataReaderService = new DataReaderService(reviewRepositoryMock.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ReadData_Throws_ArgumentException_NullOrEmptyFile(string fileName)
        {
            Assert.ThrowsAsync<ArgumentException>(() => dataReaderService.ReadData(fileName));
        }

        [Theory]
        [InlineData("invalidFile.json")]
        public void ReadData_Throws_FileNotFoundException_InvalidFile(string fileName)
        {
            Assert.ThrowsAsync<FileNotFoundException>(() => dataReaderService.ReadData(fileName));
        }
    }
}
