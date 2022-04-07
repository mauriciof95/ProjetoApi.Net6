using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repository
{
    public class BaseRepository<TModel> where TModel : BaseModel
    {
        public ApiContext _context;
        public BaseRepository(ApiContext context) => _context = context;

        public virtual async Task<ICollection<TModel>> GetAll() 
            => await _context.Set<TModel>().AsNoTracking().ToListAsync();

        public virtual async Task<TModel?> FindById(long id) 
            => await _context.Set<TModel>().FindAsync(id);

        public virtual async Task<TModel?> FirstSearchBy(Expression<Func<TModel, bool>> match)
            => await _context.Set<TModel>().FirstOrDefaultAsync(match);

        public virtual async Task<ICollection<TModel>> SearchBy(Expression<Func<TModel, bool>> match)
            => await _context.Set<TModel>().Where(match).ToListAsync();

        public virtual async Task<TModel> Include(TModel model)
        {
            await _context.Set<TModel>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<TModel?> Update(TModel updated, TModel oldModel)
        {
            _context.Entry(oldModel).CurrentValues.SetValues(updated);
            await _context.SaveChangesAsync();
            return updated;
        }

        public virtual async Task Delete(TModel model) 
        { 
            _context.Set<TModel>().Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
