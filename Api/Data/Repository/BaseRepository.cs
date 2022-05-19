using Api.Data.Context;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.Repository
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class
    {
        public ApiContext _context;
        public BaseRepository(ApiContext context) => _context = context;

        public virtual async Task<ICollection<TModel>> GetAllAsync() 
            => await _context.Set<TModel>().AsNoTracking().ToListAsync();

        public virtual async Task<TModel> FindByIdAsync(long id) 
            => await _context.Set<TModel>().FindAsync(id);

        public virtual async Task<TModel> FirstSearchBy(Expression<Func<TModel, bool>> match)
            => await _context.Set<TModel>().FirstOrDefaultAsync(match);

        public virtual async Task<ICollection<TModel>> FilterBy(Expression<Func<TModel, bool>> match)
            => await _context.Set<TModel>().Where(match).ToListAsync();

        public virtual async Task<TModel> CreateAsync(TModel model)
        {
            await _context.Set<TModel>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public virtual async Task<TModel> UpdateAsync(TModel updated, TModel outdated)
        {
            _context.Entry(outdated).CurrentValues.SetValues(updated);
            await _context.SaveChangesAsync();
            return updated;
        }

        public virtual async Task DeleteAsync(TModel model) 
        { 
            _context.Set<TModel>().Remove(model);
            await _context.SaveChangesAsync();
        }
    }
}
