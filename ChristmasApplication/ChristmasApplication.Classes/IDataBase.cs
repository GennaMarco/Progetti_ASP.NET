using System.Collections.Generic;

namespace ChristmasApplication.Classes
{
    public interface IDataBase
    {
        User GetUserByEmailAndPassword(User user);

        IEnumerable<Order> GetAllOrders();

        IEnumerable<Toy> GetAllToys();

        Order GetOrderById(string id);

        Toy GetToyByName(string name);

        bool UpdateOrderStatus(Order order);
    }
}
