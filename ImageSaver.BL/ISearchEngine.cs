using System.Threading.Tasks;

namespace ImageSaver.BL
{
    public interface ISearchEngine
    {
        Task<string> FindResults(string searchTerm);
    }
}
