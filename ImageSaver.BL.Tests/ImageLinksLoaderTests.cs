using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSaver.BL.Tests
{
    [TestFixture]
    public class ImageLinksLoaderTests
    {
        private ImageLinksLoader imageLinksLoader;
        private Mock<IImagesLinksExtractor> imagesLinksExtractorMock = new Mock<IImagesLinksExtractor>();
        private Mock<ISearchEngine> searchEngineMock = new Mock<ISearchEngine>();

        [SetUp]
        public void SetUp()
        {
            imageLinksLoader = new ImageLinksLoader(searchEngineMock.Object, imagesLinksExtractorMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            imagesLinksExtractorMock.Reset();
            searchEngineMock.Reset();
        }

        [Test]
        public async Task LoadLinksForTerm_LinksLoaded()
        {
            string searchTerm = "stub";
            IEnumerable<string> expectedLinks = new[] { "https://images.com/im1", "https://images.com/im2" };
            searchEngineMock.Setup(s => s.FindResults(It.IsAny<string>())).Returns(Task.FromResult("stub"));
            imagesLinksExtractorMock.Setup(e => e.ExtractLinks(It.IsAny<string>())).Returns(Task.FromResult(expectedLinks));

            var links = await imageLinksLoader.LoadImagesLinks(searchTerm);

            imagesLinksExtractorMock.Verify(l => l.ExtractLinks(It.IsAny<string>()), Times.Once());
            searchEngineMock.Verify(s => s.FindResults(It.IsAny<string>()), Times.Once());
            CollectionAssert.AreEquivalent(expectedLinks, links);
        }

        [TestCase("")]
        [TestCase(null)]
        [TestCase("   ")]
        [Test]
        public void InvalidTerm_ArgumentException(string searchTerm)
        {
            Assert.Throws<ArgumentException>(() => imageLinksLoader.LoadImagesLinks(searchTerm));
        }
    }
}
