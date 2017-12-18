using ChristmasApplication.Classes;
using System.Collections.Generic;

namespace ChristmasApplication.Tests.Mocks
{
    public class DatabaseMock : IDataBase
    {
        public User GetUserByEmailAndPassword(User user)
        {
            if (user == null)
                return null;
            else
                return user;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return new List<Order>();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            return new List<Toy>();
        }

        public Toy GetToyByName(string name)
        {
            Toy toy = new Toy();
            toy.Name = name;
            return toy;     
        }

        public Order GetOrderById(string id)
        {
            Order order = new Order();
            order.ID = id;
            return order;
        }

        public bool UpdateOrderStatus(Order order)
        {
            return true;
        }
    }
}
