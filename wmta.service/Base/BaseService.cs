using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wmta.domain.Base;
using wmta.Infrustructure;
using wmta.Repository.Base;

namespace wmta.service.Base
{
    public class BaseService<T> : BaseRepository<T> where T: BaseModel
    {
        private WMDbContext _wMDbContext;
        DbSet<T> _innerDb;

        public BaseService()
        {
            _wMDbContext = new WMDbContext();
            _innerDb = _wMDbContext.Set<T>();


        }
        public IQueryable<T> All()
        {
            return _innerDb.Where(x => !x.IsDelete);
            //throw new NotImplementedException();
        }

        public bool delete(int? id)
        {
            if (id != null)
            {
                var entity = _innerDb.Find(id);
                _wMDbContext.Entry(entity).State = EntityState.Deleted;
                _innerDb.Remove(entity);
                Save();
                return true;
            }
            return false;
        }

        public T GetByID(int? id)
        {
            if(id != null)
            {
                var result = _innerDb.Where(x => x.id == id).First();
                return result;
            }
            return null;
        }

        public bool Insert(T entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            entity.UpdatedDate = DateTime.UtcNow;
            entity.IsDelete = false;
            _wMDbContext.Entry(entity).State = EntityState.Added;
            _innerDb.Add(entity);

            try
            {
                _wMDbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }



            return true;
        }

        public bool Update(T entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            _wMDbContext.Entry(entity).State = EntityState.Modified;
            _wMDbContext.Configuration.ValidateOnSaveEnabled = false;
            Save();
            _wMDbContext.Configuration.ValidateOnSaveEnabled = true;

            return true;
        }

        public void Save()
        {
            _wMDbContext.SaveChanges();
        }
    }
}
