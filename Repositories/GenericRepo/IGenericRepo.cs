using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace TestDAW1.Repositories.GenericRepo
{
    public interface IGenericRepo<TEntity>
    {
        //get data
        //toti hairstilistii
       IQueryable<TEntity> GetAll();
        //hairstilist dupa id de ex
        Task<TEntity> GetByIdAsync(int id) ;

        //create
        void Create(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        //update
        void Update(TEntity entity);

        //delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //save in database

        Task<bool> SaveAsync();
    }
}
