using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBookSpot.DataAccess.Data.Repository
{
   public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
    }
}
