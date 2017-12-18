using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChristmasApplication.Classes
{
    public class MongoDB : IDataBase
    {
        private IMongoDatabase database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }

        public User GetUserByEmailAndPassword(User user)
        {
            try
            {
                if (user.Email == String.Empty || String.IsNullOrWhiteSpace(user.Email) || user.Password == String.Empty || String.IsNullOrWhiteSpace(user.Password))
                    throw new ArgumentException();
            }
            catch (ArgumentException)
            {
                return null;
            }
            IMongoCollection<User> usersCollection = database.GetCollection<User>("users");
            return usersCollection.Find(_ => _.Email == user.Email && _.Password == (SHA512.GetSHA512(user.Password))).FirstOrDefault();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            IMongoCollection<Toy> toysCollection = database.GetCollection<Toy>("toys");
            return toysCollection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<Order> GetAllOrders()
        {
            IMongoCollection<Order> ordersCollection = database.GetCollection<Order>("orders");
            return ordersCollection.Find(new BsonDocument()).SortByDescending(o => o.RequestDate).ToList();
        }

        public Order GetOrderById(string id)
        {
            try
            {
                if (id == String.Empty || String.IsNullOrWhiteSpace(id) || id.Length != 24)
                    throw new ArgumentException();
                IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
                return orderCollection.Find(_ => _.ID == id).FirstOrDefault();
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch(FormatException)
            {
                return null;
            } 
        }

        public Toy GetToyByName(string name)
        {
            try
            {
                if (name == String.Empty || String.IsNullOrWhiteSpace(name))
                    throw new ArgumentException();
                IMongoCollection<Toy> toysCollection = database.GetCollection<Toy>("toys");
                return toysCollection.Find(_ => _.Name == name).FirstOrDefault();
            }
            catch (ArgumentException)
            {
                return null;
            }
            catch (FormatException)
            {
                return null;
            }

        }

        public bool UpdateOrderStatus(Order order)
        {
            try
            {
                if (order.ID == String.Empty || String.IsNullOrWhiteSpace(order.ID) || order.ID.Length != 24)
                    throw new ArgumentException();
                if (order.Status < (StatusType)0 || order.Status > Enum.GetValues(typeof(StatusType)).Cast<StatusType>().Last())
                    throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentException)
            {
                return false;
            }

            List<Toy> ListToys = new List<Toy>();
            foreach (Toy toy in order.ToysList)
                ListToys.Add(GetToyByName(toy.Name));
            
            if (IsUpdateble(ListToys, order))
            {
                IMongoCollection<Order> orderCollection = database.GetCollection<Order>("orders");
                var filterId = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(order.ID));
                var update = Builders<Order>.Update.Set("status", order.Status);
                try
                {
                    orderCollection.UpdateOne(filterId, update);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        private bool IsUpdateble(List<Toy> toysList, Order order)
        {
            foreach (Toy toy in toysList)
            {
                if (toy.Amount == 0 && order.Status != StatusType.In_progress)
                    return false;
            }
            return true;
        }
    }
}
