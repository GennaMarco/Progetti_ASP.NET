using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using ChristmasApplication.Classes;
using ChristmasApplicationDB = ChristmasApplication.Classes.MongoDB;
using System.Collections.Generic;
using System.Linq;

namespace ChristmasApplication.Tests.Integration
{
    [TestClass]
    public class Orders
    {
        private IMongoDatabase db;
        private const string ID_ORDER = "5a2e3f053ee013109cb98d7c";
        private static readonly Toy TOY = new Toy
        {
            Name = "test_toy_name",
            Amount = 4
        };
        private static readonly List<Toy> TOYSLIST = new List<Toy>()
        {
            TOY
        };
        

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Order> collectionOrder = db.GetCollection<Order>("orders");
            collectionOrder.InsertOne(new Order
            {
                ID = ID_ORDER,
                ToysList = TOYSLIST
            });
            IMongoCollection<Toy> collectionToy = db.GetCollection<Toy>("toys");
            collectionToy.InsertOne(TOY);
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("orders");
                db.DropCollection("toys");
            }
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_A_List()
        {
            ChristmasApplicationDB db = new ChristmasApplicationDB();
            var orderList = db.GetAllOrders();
            Assert.AreEqual(1, orderList.Count());
        }

        [TestMethod]
        public void GetOrderById_Should_Return_An_Order_Object()
        {
            ChristmasApplicationDB db = new ChristmasApplicationDB();
            var order = db.GetOrderById(ID_ORDER);
            Assert.IsNotNull(order);
            Assert.IsInstanceOfType(order, typeof(Order));
        }

        [TestMethod]
        public void UpdateOrderStatus_Should_Return_True()
        {
            ChristmasApplicationDB db = new ChristmasApplicationDB();
            var order = db.GetOrderById(ID_ORDER);
            order.Status = StatusType.Ready_to_be_sent;
            order.ToysList = TOYSLIST;
            Assert.IsTrue(db.UpdateOrderStatus(order));
        }
    }
}
