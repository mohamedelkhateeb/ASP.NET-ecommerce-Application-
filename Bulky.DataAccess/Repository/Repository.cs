using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _db;
        private DbSet<T> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> All()
        {
            return dbSet.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
