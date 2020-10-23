namespace API.Models
{
    public class UnsplashDatabaseSettings : IUnsplashDatabaseSettings
    {
        public string PhotosCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUnsplashDatabaseSettings
    {
        string PhotosCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
