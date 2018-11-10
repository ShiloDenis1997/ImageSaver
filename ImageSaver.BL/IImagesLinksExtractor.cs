using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImageSaver.BL
{
    public interface IImagesLinksExtractor
    {
        Task<IEnumerable<string>> ExtractLinks(string searchResults);
    }
}
