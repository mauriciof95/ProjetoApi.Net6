using System.Linq.Expressions;

namespace Api.App
{
    public interface IBaseRepository<TEntity>
    {
        public void Save();
        public Task SaveAsync();

        public TEntity GetById(Guid id);

        public IEnumerable<TEntity> GetAll();

        public IEnumerable<TEntity> SearchBy(Expression<Func<TEntity, bool>> search = null);

        public TEntity FindBy(Expression<Func<TEntity, bool>> find = null);

        public bool Any(Expression<Func<TEntity, bool>> any = null);

        public void Create(TEntity entity);

        public void Create(IEnumerable<TEntity> entities);

        public void Update(TEntity entity);

        public void Delete(TEntity entity);
    }
}
