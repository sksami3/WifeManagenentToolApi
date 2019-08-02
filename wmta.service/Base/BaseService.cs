using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmta.domain.Base;
using wmta.Repository.Base;

namespace wmta.service.Base
{
    public class BaseService<T> : BaseRepository<T> 
    {
        public IQueryable<T> All()
        {
            throw new NotImplementedException();
        }

        public bool delete(int? id)
        {
            throw new NotImplementedException();
        }

        public T GetByID(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
