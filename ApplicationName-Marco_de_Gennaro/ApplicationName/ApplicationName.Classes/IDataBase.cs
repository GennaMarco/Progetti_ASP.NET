using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationName.Classes
{
    public interface IDataBase
    {
        IEnumerable<Category> GetAllCategories();
    }
}
