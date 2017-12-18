using MongoDB.Driver;

namespace ChristmasApplication.Tests.Mocks
{
    public class MongoConnectionMock 
    {
        public string DBName { get; set; }
        public IMongoDatabase GetDatabase()
        {
            MongoClientSettings settings = new MongoClientSettings();

            // settings.Credentials
            MongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase(DBName);
            return db;
        }
    }
}
