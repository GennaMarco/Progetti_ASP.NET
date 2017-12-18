using ChristmasApplication.Classes;
using ChristmasApplication.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ChristmasApplicationMongoDB = ChristmasApplication.Classes.MongoDB;

namespace ChristmasApplication.Web.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult IndexOrders(bool? error)
        {
            if (Session["ScreenName"] != null)
            {
                if (error == true)
                    ModelState.AddModelError("", "l'id dell'ordine risulta null/empy/whitespace o non esistente");
                ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
                var orders = db.GetAllOrders();
                Orders modelOrders = new Orders();
                modelOrders.OrdersList = orders.ToList();
                modelOrders.instanceDB = db;
                return View(modelOrders);
            }
            else
                return RedirectToAction("Index", "Home", null);
        }

        public ActionResult DetailsOrder(string id, bool? result)
        {
            if (Session["ScreenName"] != null && Session["ScreenName"].ToString() == "FabulousZiggy")
            {
                if(result == false)
                    ModelState.AddModelError("", "Non è stato possibile modificare lo status");
                ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
                var order = db.GetOrderById(id);
                if (order != null)
                {
                    Order modelOrder = new Order();
                    modelOrder.ID = order.ID;
                    modelOrder.Kid = order.Kid;
                    modelOrder.RequestDate = order.RequestDate;
                    modelOrder.Status = order.Status;
                    List<Toy> ToysOrder = new List<Toy>();
                    for (int i = 0; i < order.ToysList.Count; i++)
                        ToysOrder.Add(db.GetToyByName(order.ToysList[i].Name));
                    modelOrder.ToysList = ToysOrder;
                    return View(modelOrder);
                }
                else
                    return RedirectToAction("IndexOrders", "Orders", new { error = true });
            }
            else
                return RedirectToAction("Index", "Home", null);      
        }

        public ActionResult UpdateOrderStatus(string id)
        {
            if (Session["ScreenName"] != null && Session["ScreenName"].ToString() == "FabulousZiggy")
            {
                ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
                var order = db.GetOrderById(id);
                if (order != null)
                {
                    Order modelOrder = new Order();
                    modelOrder.ID = order.ID;
                    modelOrder.Kid = order.Kid;
                    modelOrder.RequestDate = order.RequestDate;
                    modelOrder.Status = order.Status;
                    List<Toy> ToysOrder = new List<Toy>();
                    for (int i = 0; i < order.ToysList.Count; i++)
                        ToysOrder.Add(db.GetToyByName(order.ToysList[i].Name));
                    modelOrder.ToysList = ToysOrder;
                    return View(modelOrder);
                }
                else
                    return RedirectToAction("IndexOrders", "Orders", new { error = true });
            }
            else
                return RedirectToAction("Index", "Home", null);
        }

        public ActionResult SaveOrderStatus(string id, StatusType statusType)
        {    
            ChristmasApplicationMongoDB db = new ChristmasApplicationMongoDB();
            Order order = db.GetOrderById(id);
            if (order != null)
            {
                bool result = db.UpdateOrderStatus(new Order
                {
                    ID = id,
                    Status = statusType,
                    ToysList = order.ToysList
                });
                return RedirectToAction("DetailsOrder", new { id = id, result = result });
            }
            else
                return RedirectToAction("IndexOrders", "Orders", new { error = true });
        }
    }
}