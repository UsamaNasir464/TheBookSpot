using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBookSpot.DataAccess.Data.Repository.IRepository;

namespace TheBookSpot.DataAccess.Data.Repository
{
    public  interface ICategoryRepository:IRepository<Category>
    {
        void update(Category category);

    }

}
