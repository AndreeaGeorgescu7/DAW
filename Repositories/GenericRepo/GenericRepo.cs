using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDAW1.Data;
using TestDAW1.Model;

namespace TestDAW1.Repositories.GenericRepo
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        //dependency injection( a programming technique that makes a class independent of its dependencies)
        protected readonly Project_context _context;
        protected readonly AppDbContext  context2;

        public GenericRepo(Project_context context)
        {
            _context = context;

        }

        public GenericRepo(AppDbContext context)
        {
            this.context2 = context;
        }

        public void Create(TEntity entity)
        {
            // throw new System.NotImplementedException();


            _context.Set<TEntity>().Add(entity);

        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> GetAll()
        { /*COLECTII
           * 
          *IQueryable- tine minte query catre db; accesarea lui se face prin query spre db
          *IEnumerable- lfl dar in memorie nu in db
          *List
            
           */
            ///se modifica doar in program nu si in db daca punem noTracking
           return _context.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}
