using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace backend.Models
{
    public class Usuario
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("Nombre")]
        public string nombre { get; set; }

        [BsonElement("Contrasena")]
        public string contrasena { get; set; }

    }

}