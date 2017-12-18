using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChristmasApplication.Classes;
using ChristmasApplication.Tests.Mocks;
using System.Collections.Generic;
using System.Linq;

namespace ChristmasApplication.Tests
{
    [TestClass]
    public class MongoDBTest
    {
        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Throw_Exception_When_User_Is_Null()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = null;
            try
            {
                if (dbm.GetUserByEmailAndPassword(userMock) == null)
                    throw new ArgumentNullException("user is null");
                Assert.Fail("user is not null");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Throw_Exception_When_Email_Is_Null()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = new User();
            try
            {
                User user = dbm.GetUserByEmailAndPassword(userMock);
                if (user.Email == null)
                    throw new ArgumentNullException("email is null");
                Assert.Fail("email is not null");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Throw_Exception_When_Email_Is_Empty()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = new User();
            userMock.Email = "";
            try
            {
                User user = dbm.GetUserByEmailAndPassword(userMock);
                if (user.Email == String.Empty)
                    throw new ArgumentException("email is empty");
                Assert.Fail("email is not empty");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Throw_Exception_When_Email_Is_WhiteSpace()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = new User();
            userMock.Email = " ";
            try
            {
                User user = dbm.GetUserByEmailAndPassword(userMock);
                if (String.IsNullOrWhiteSpace(user.Email))
                    throw new ArgumentException("email is whitespace");
                Assert.Fail("email is not whitespace");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Throw_Exception_When_Password_Is_Null()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = new User();
            try
            {
                User user = dbm.GetUserByEmailAndPassword(userMock);
                if (user.Password == null)
                    throw new ArgumentNullException("password is null");
                Assert.Fail("password is not null");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Throw_Exception_When_Password_Is_Empty()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = new User();
            userMock.Password = "";
            try
            {
                User user = dbm.GetUserByEmailAndPassword(userMock);
                if (user.Password == String.Empty)
                    throw new ArgumentException("password is empty");
                Assert.Fail("password is not empty");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Throw_Exception_When_Password_Is_WhiteSpace()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = new User();
            userMock.Password = " ";
            try
            {
                User user = dbm.GetUserByEmailAndPassword(userMock);
                if (String.IsNullOrWhiteSpace(user.Password))
                    throw new ArgumentException("password is whitespace");
                Assert.Fail("password is not whitespace");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetUserByEmailAndPassword_Should_Return_An_User_Object()
        {
            DatabaseMock dbm = new DatabaseMock();
            User userMock = new User();
            Assert.IsInstanceOfType(dbm.GetUserByEmailAndPassword(userMock), typeof(User));
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_A_Mongo_List_Of_Orders()
        {
            DatabaseMock dbm = new DatabaseMock();
            Assert.IsInstanceOfType(dbm.GetAllOrders(), typeof(IEnumerable<Order>));
        }

        [TestMethod]
        public void GetAllToys_Should_Return_A_Mongo_List_Of_Toys()
        {
            DatabaseMock dbm = new DatabaseMock();
            Assert.IsInstanceOfType(dbm.GetAllToys(), typeof(IEnumerable<Toy>));
        }

        [TestMethod]
        public void GetToyByName_Should_Throw_Exception_When_Name_Is_Null()
        {
            DatabaseMock dbm = new DatabaseMock();
            string toyNameMock = null;
            try
            {
                Toy toy = dbm.GetToyByName(toyNameMock);
                if (toy.Name == null)
                    throw new ArgumentNullException("name is null");
                Assert.Fail("name is not null");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void GetToyByName_Should_Throw_Exception_When_Name_Is_Empty()
        {
            DatabaseMock dbm = new DatabaseMock();
            string toyNameMock = "";
            try
            {
                Toy toy = dbm.GetToyByName(toyNameMock);
                if (toy.Name == String.Empty)
                    throw new ArgumentException("name is empty");
                Assert.Fail("name is not empty");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetToyByName_Should_Throw_Exception_When_Name_Is_WhiteSpace()
        {
            DatabaseMock dbm = new DatabaseMock();
            string toyNameMock = " ";
            try
            {
                Toy toy = dbm.GetToyByName(toyNameMock);
                if (String.IsNullOrWhiteSpace(toy.Name))
                    throw new ArgumentException("name is whitespace");
                Assert.Fail("name is not whitespace");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetToyByName_Should_Return_A_Toy_Object()
        {
            DatabaseMock dbm = new DatabaseMock();
            string toyNameMock = "";
            Assert.IsInstanceOfType(dbm.GetToyByName(toyNameMock), typeof(Toy));
        }

        [TestMethod]
        public void GetOrderById_Should_Throw_Exception_When_Id_Is_Null()
        {
            DatabaseMock dbm = new DatabaseMock();
            string idOrderMock = null;
            try
            {
                Order order = dbm.GetOrderById(idOrderMock);
                if (order.ID == null)
                    throw new ArgumentNullException("id is null");
                Assert.Fail("id is not null");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void GetOrderById_Should_Throw_Exception_When_Id_Is_Empty()
        {
            DatabaseMock dbm = new DatabaseMock();
            string idOrderMock = "";
            try
            {
                Order order = dbm.GetOrderById(idOrderMock);
                if (order.ID == String.Empty)
                    throw new ArgumentException("id is empty");
                Assert.Fail("id is not empty");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetOrderById_Should_Throw_Exception_When_Id_Is_WhiteSpace()
        {
            DatabaseMock dbm = new DatabaseMock();
            string idOrderMock = " ";
            try
            {
                Order order = dbm.GetOrderById(idOrderMock);
                if (String.IsNullOrWhiteSpace(order.ID))
                    throw new ArgumentException("id is whitespace");
                Assert.Fail("id is not whitespace");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void UpdateOrderStatus_Should_Throw_Exception_When_Id_Is_Null()
        {
            DatabaseMock dbm = new DatabaseMock();
            Order orderMock = new Order();
            orderMock.ID = null;
            try
            {
                bool result = dbm.UpdateOrderStatus(orderMock);
                if (orderMock.ID == null)
                    throw new ArgumentNullException("id is null");
                Assert.Fail("id is not null");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestMethod]
        public void UpdateOrderStatus_Should_Throw_Exception_When_Id_Is_Empty()
        {
            DatabaseMock dbm = new DatabaseMock();
            Order orderMock = new Order();
            orderMock.ID = "";
            try
            {
                bool result = dbm.UpdateOrderStatus(orderMock);
                if (orderMock.ID == String.Empty)
                    throw new ArgumentException("id is empty");
                Assert.Fail("id is not empty");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void UpdateOrderStatus_Should_Throw_Exception_When_Id_Is_Whitespace()
        {
            DatabaseMock dbm = new DatabaseMock();
            Order orderMock = new Order();
            orderMock.ID = " ";
            try
            {
                bool result = dbm.UpdateOrderStatus(orderMock);
                if (String.IsNullOrWhiteSpace(orderMock.ID))
                    throw new ArgumentException("id is whitespace");
                Assert.Fail("id is not whitespace");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void Update_Order_Should_Throw_Exception_When_Status_Is_Out_Of_Range()
        {
            DatabaseMock dbm = new DatabaseMock();
            Order orderMock = new Order();
            orderMock.Status = (StatusType)(3);
            try
            {
                bool result = dbm.UpdateOrderStatus(orderMock);
                if (orderMock.Status < (StatusType)0 || orderMock.Status > Enum.GetValues(typeof(StatusType)).Cast<StatusType>().Last())
                    throw new ArgumentOutOfRangeException("status is out of range");
                Assert.Fail("status is not out of range");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentOutOfRangeException));
            }
        }
    }
}
