using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using ChristmasApplication.Classes;
using ChristmasApplicationDB = ChristmasApplication.Classes.MongoDB;

namespace ChristmasApplication.Tests.Integration
{
    [TestClass]
    public class Users
    {
        private IMongoDatabase db;
        private const string EMAIL = "test-email";
        private const string PASSWORD = "test-password";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            collection.InsertOne(new User
            {
                Email = EMAIL,
                Password = SHA512.GetSHA512(PASSWORD)
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("users");
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Return_An_User_Object()
        {
            ChristmasApplicationDB db = new ChristmasApplicationDB();
            User userTest = new User
            {
                Email = EMAIL,
                Password = PASSWORD
            };
            User user = db.GetUserByEmailAndPassword(userTest);
            Assert.IsNotNull(user);
            Assert.IsInstanceOfType(user, typeof(User));
        }
    }
}
