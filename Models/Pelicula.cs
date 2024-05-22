using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Pelicula
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("titulo")] 
        public string titulo {get;set;}

        [BsonElement("genero")]
        public List<ObjectId> generoIds { get;set;} 
    }
    
}