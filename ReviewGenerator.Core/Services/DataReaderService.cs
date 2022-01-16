using Newtonsoft.Json;
using ReviewGenerator.Core.Interfaces;
using ReviewGenerator.Core.Models;
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace ReviewGenerator.Core.Services
{
    public class DataReaderService : IDataReaderService
    {
        private readonly IReviewRepository _reviewRepository;

        public DataReaderService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task ReadData(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException();

            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);

            if (!File.Exists(path))
                throw new FileNotFoundException();

            await Task.Run(async () =>
            {
                var serializer = new JsonSerializer();

                using (var s = File.Open(path, FileMode.Open))
                using (var zip = new GZipStream(s, CompressionMode.Decompress))
                using (var sr = new StreamReader(zip))
                using (var jsonTextReader = new JsonTextReader(sr))
                {
                    jsonTextReader.SupportMultipleContent = true;

                    while (await jsonTextReader.ReadAsync())
                    {
                        if (jsonTextReader.TokenType == JsonToken.StartObject)
                        {
                            var rawReview = serializer.Deserialize<Review>(jsonTextReader);
                            await _reviewRepository.Add(rawReview);
                        }
                    }
                }
            });
        }
    }
}
