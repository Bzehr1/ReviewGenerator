using NUnit.Framework;
using Moq;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Services;
using System;
using System.Threading.Tasks;
using System.IO;

namespace ReviewGenerator.Test
{
    public class DataReaderServiceTestFixture
    {
        private DataReaderService dataReaderService;
        private Mock<IReviewRepository> reviewRepositoryMock;

        [SetUp]
        public void Setup()
        {
            reviewRepositoryMock = new Mock<IReviewRepository>();
            dataReaderService = new DataReaderService(reviewRepositoryMock.Object);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]

        public void ReadData_Throws_ArgumentException_NullOrEmptyFile(string fileName)
        {
            Assert.ThrowsAsync<ArgumentException>(() => dataReaderService.ReadData(fileName));
        }

        [Test]
        [TestCase("invalidFile.json")]

        public void ReadData_Throws_FileNotFoundException_InvalidFile(string fileName)
        {
            Assert.ThrowsAsync<FileNotFoundException>(() => dataReaderService.ReadData(fileName));
        }
    }
}