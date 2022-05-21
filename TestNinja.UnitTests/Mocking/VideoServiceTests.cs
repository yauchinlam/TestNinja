using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using TestNinja.Fundamentals;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class VideoServiceTests
    {
        private Mock<IFileReader> _fileReader;
        private VideoService _videoService;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            //Act
            var result = _videoService.ReadVideoTitle();

            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_RturnAnEmptyString()
        {
            //Arrange
            _repository.Setup(r=> r.GetUnprocessedVideos()).Returns(new List<Video>());

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo(String.Empty));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnprocessedVideos_RturnAStringWithIdOfUnrprocessedVideos()
        {
            //Arrange
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new List<Video> 
            { 
                new Video {Id =1},
                new Video {Id =2},
                new Video {Id =3},
            });

            //Act
            var result = _videoService.GetUnprocessedVideosAsCsv();

            //Assert
            Assert.That(result, Is.EqualTo("1,2,3"));
        }
    }
}
