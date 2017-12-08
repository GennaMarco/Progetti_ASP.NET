using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationName.Classes
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

        public IEnumerable<Category> GetAllCategories()
        {
            IMongoCollection<Category> categoryCollection = database.GetCollection<Category>("category");
            return categoryCollection.Find(new BsonDocument()).ToList();
        }
        public Category GetCategoryByName(string name)
        {
            IMongoCollection<Category> categoryCollection = database.GetCollection<Category>("category");
            return categoryCollection.Find(_ => _.Name == name).FirstOrDefault();
        }

        public bool InsertCategory(Category category)
        {
            IMongoCollection<Category> categoryCollection = database.GetCollection<Category>("category");
            try
            {
                categoryCollection.InsertOne(category);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateCategory(Category category)
        {
            IMongoCollection<Category> categoryCollection = database.GetCollection<Category>("category");
            var filter = Builders<Category>.Filter.Eq("_id", ObjectId.Parse(category.ID));
            var update = Builders<Category>.Update.Set("name", category.Name);
            try
            {
                categoryCollection.UpdateOne(filter, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveCategoryById(string id)
        {
            IMongoCollection<Category> categoryCollection = database.GetCollection<Category>("category");
            var filter = Builders<Category>.Filter.Eq("_id", ObjectId.Parse(id));
            try
            {
                categoryCollection.DeleteOne(filter);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
