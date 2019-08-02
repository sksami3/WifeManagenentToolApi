using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wmta.Repository.Base
{
    public interface BaseRepository<T>
    {
        IQueryable<T> All();
        T GetByID(int? id);
        bool Insert(T entity);
        bool Update(T entity);
        bool delete(int? id);
    }
}
