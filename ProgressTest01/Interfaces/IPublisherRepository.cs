using ProgressTest01.Models;

namespace ProgressTest01.Interfaces
{
    public interface IPublisherRepository
    {
        public Task<List<Publisher>> GetAllAsync();
        public Task<Publisher> GetPublisherFromName(string publisherName);
    }
}
