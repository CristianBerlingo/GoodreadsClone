using System.Collections.Generic;

namespace GoodreadsCloneAPI.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        List<TEntity> Get();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Delete(int id);
        void Update(TEntity entity);
    }
}