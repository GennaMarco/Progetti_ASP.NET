using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristmasApplication.Classes
{
    public interface IDataBase
    {
        /*IEnumerable<Category> GetAllCategories();
        bool InsertCategory(Category category);
        public bool UpdateCategory(Category category);
        public bool RemoveCategoryById(string id);*/
        User GetUser(User user);
    }
}
