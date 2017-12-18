using ChristmasApplication.Classes;
using System.Collections.Generic;
using ChristmasApplicationMongoDB = ChristmasApplication.Classes.MongoDB;

namespace ChristmasApplication.Web.Models
{
    public class Orders 
    {
        public List<Order> OrdersList;
        public ChristmasApplicationMongoDB instanceDB;

        public decimal GetTotalPriceOfOrder(Order order)
        {
            decimal totalPriceToysList = 0;
            Toy toy;
            for (int i = 0; i < order.ToysList.Count; i++)
            {
                toy = instanceDB.GetToyByName(order.ToysList[i].Name);
                if (toy != null)
                    totalPriceToysList += toy.Cost;
                else
                    return 0;
            }
            return totalPriceToysList;
        }
    }
}