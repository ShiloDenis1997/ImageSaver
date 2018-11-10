using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageSaver.BL
{
    public class ImageLinksLoader
    {
        private readonly ISearchEngine searchEngine;
        private readonly IImagesLinksExtractor imagesLinksExtractor;

        public ImageLinksLoader(ISearchEngine searchEngine, IImagesLinksExtractor imagesLinksExtractor)
        {
            this.searchEngine = searchEngine ?? throw new ArgumentNullException(nameof(searchEngine));
            this.imagesLinksExtractor = imagesLinksExtractor ?? throw new ArgumentNullException(nameof(imagesLinksExtractor));
        }

        public Task<IEnumerable<string>> LoadImagesLinks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new ArgumentException(nameof(searchTerm));
            }

            return LoadImagesLinks();

            async Task<IEnumerable<string>> LoadImagesLinks()
            {
                string searchResults = await searchEngine.FindResults(searchTerm);
                return await imagesLinksExtractor.ExtractLinks(searchResults);
            }
        }
    }
}
