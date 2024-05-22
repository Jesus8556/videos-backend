using MongoDB.Driver;

namespace backend.Data
{
    public class MongoDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoDBRepository()
        {
            client = new MongoClient("mongodb+srv://zaph:lhnnNWCOoC1jqLbQ@cluster0.awt8ftp.mongodb.net/");
            db = client.GetDatabase("Recomendacion");

        }
    }
}