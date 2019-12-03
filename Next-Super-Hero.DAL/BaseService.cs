using Next_Super_Hero.IDAL;
using Next_Super_Hero.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_Super_Hero.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        private readonly SuperHeroContext _db;
        public BaseService(SuperHeroContext db)
        {
            this._db = db;
        }
        public async Task CreateAsync(T model, bool saved = true)
        {
            _db.Set<T>().Add(model);
            if (saved)
                await _db.SaveChangesAsync();
        }

        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public IQueryable<T> GetAllAsync()
        {
            return _db.Set<T>().Where(m => !m.IsRemove).AsNoTracking();
        }

        public IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0)
        {
            return GetAllAsync().Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            return GetAllOrderAsync(asc).Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllOrderAsync(bool asc = true)
        {
            var datas = GetAllAsync();
            datas = asc ? datas.OrderBy(m => m.CreateTime) : datas.OrderByDescending(m => m.CreateTime);
            return datas;
        }

        public Task<T> GetOneByIdAsync(Guid guid)
        {
            return GetAllAsync().FirstAsync(m => m.Id == guid);
        }

        public async Task RemoveAsync(T model, bool saved = true)
        {
            await RemoveAsync(model.Id, saved);
        }

        public async Task RemoveAsync(Guid guid, bool saved = true)
        {
            _db.Configuration.ValidateOnSaveEnabled = false;
            var t = new T { Id = guid };
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemove = true;
            if (saved)
            {
                await _db.SaveChangesAsync();
                _db.Configuration.ValidateOnSaveEnabled = true;
            }
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
            _db.Configuration.ValidateOnSaveEnabled = true;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }
}
