using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Rating
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("usuarioid")]
        public ObjectId UsuarioId { get; set; }
        [BsonElement("peliculaid")]
        public ObjectId PeliculaId { get; set; } // Referencia a documento de Película
        [BsonElement("calificacion")]
        public int Calificacion { get; set; }
    }

}