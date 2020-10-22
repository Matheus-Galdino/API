using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API.Models
{
    public class Photo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Label { get; set; }

        public string Url { get; set; }

        public Photo() { }

        public Photo(string label, string url)
        {
            Label = label;
            Url = url;
        }
    }
}
