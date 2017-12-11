using ChristmasApplication.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChristmasApplication.Web.Models
{
    public class Users
    {
        public Users(List<User> entityList)
        {
            EntityList = entityList;
        }

        public List<User> EntityList { get; private set; }
    }
}