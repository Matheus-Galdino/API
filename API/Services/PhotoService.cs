using API.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace API.Services
{
    public class PhotoService
    {
        private readonly IMongoCollection<Photo> _photo;

        public PhotoService(IUnsplashDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _photo = database.GetCollection<Photo>(settings.PhotosCollectionName);
        }

        public List<Photo> Get() =>
            _photo.Find(Photo => true).ToList();

        public Photo Get(string id) => _photo.Find(Photo => Photo.Id == id).FirstOrDefault(); 

        public List<Photo> GetByLabel(string label) =>
            _photo.Find(Photo => Photo.Label.ToLower().Contains(label.ToLower())).ToList();

        public Photo Create(Photo Photo)
        {
            _photo.InsertOne(Photo);
            return Photo;
        }

        public void Update(string id, Photo PhotoIn) =>
            _photo.ReplaceOne(Photo => Photo.Id == id, PhotoIn);

        public void Remove(Photo PhotoIn) =>
            _photo.DeleteOne(Photo => Photo.Id == PhotoIn.Id);

        public void Remove(string id) =>
            _photo.DeleteOne(Photo => Photo.Id == id);
    }
}
