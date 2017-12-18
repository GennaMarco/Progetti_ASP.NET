using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using ChristmasApplication.Classes;
using ChristmasApplicationDB = ChristmasApplication.Classes.MongoDB;
using System.Linq;

namespace ChristmasApplication.Tests.Integration
{
    [TestClass]
    public class Toys
    {
        private IMongoDatabase db;
        private const string NAME_TOY = "test-name_toy";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Toy> collection = db.GetCollection<Toy>("toys");
            collection.InsertOne(new Toy
            {
                Name = NAME_TOY,
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("toys");
            }
        }

        [TestMethod]
        public void GetAllToys_Should_Return_A_List()
        {
            ChristmasApplicationDB db = new ChristmasApplicationDB();
            var toyList = db.GetAllToys();
            Assert.AreEqual(1, toyList.Count());
        }

        [TestMethod]
        public void GetToyByName_Should_Return_A_Toy_Object()
        {
            ChristmasApplicationDB db = new ChristmasApplicationDB();
            var toy = db.GetToyByName(NAME_TOY);
            Assert.IsNotNull(toy);
            Assert.IsInstanceOfType(toy, typeof(Toy));
        }
    }
}
