using Api.App;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Infra.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public ApiDbContext _context;
        private DbSet<TEntity> _db;

        public BaseRepository(ApiDbContext context)
        {
            _context = context;
            if(context != null)
                _db = context.Set<TEntity>();
            
        }

        public void Save() => _context.SaveChanges();
        public async Task SaveAsync() => await _context.SaveChangesAsync();



        public TEntity GetById(Guid id) 
            => _db.Find(id);

        public IEnumerable<TEntity> GetAll()
            => _db.ToList();

        public IEnumerable<TEntity> SearchBy(Expression<Func<TEntity, bool>> search = null)
            => _db.Where(search).ToList();

        public TEntity FindBy(Expression<Func<TEntity, bool>> find = null)
            => _db.FirstOrDefault(find);

        public bool Any(Expression<Func<TEntity, bool>> any = null)
            => _db.Any(any);

        public void Create(TEntity entity)
            => _db.Add(entity);

        public void Create(IEnumerable<TEntity> entities)
            => _db.AddRange(entities);

        public void Update(TEntity entity)
            => _context.Entry(entity).State = EntityState.Modified;
        
        public void Delete(TEntity entity)
            => _db.Remove(entity);
    }
}
