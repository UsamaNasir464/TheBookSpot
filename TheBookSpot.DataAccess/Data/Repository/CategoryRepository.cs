using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookSpot.DataAccess.Data.Repository.IRepository;

namespace TheBookSpot.DataAccess.Data.Repository
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository( ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Category category)
        {
            var result = _db.Categories.FirstOrDefault(s => s.Id == category.Id);
            if (result != null)
            {
                _db.Categories.Update(result);
            }
            _db.SaveChanges();
        }
    }
}
