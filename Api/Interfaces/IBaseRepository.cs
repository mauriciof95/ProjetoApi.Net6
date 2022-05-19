using System.Linq.Expressions;

namespace Api.Interfaces
{
    public interface IBaseRepository<TModel>
    {
        Task<TModel> CreateAsync(TModel model);
        Task<TModel> UpdateAsync(TModel updated, TModel outdated);
        Task DeleteAsync(TModel model);
        Task<TModel> FindByIdAsync(long id);
        Task<TModel> FirstSearchBy(Expression<Func<TModel, bool>> match);
        Task<ICollection<TModel>> FilterBy(Expression<Func<TModel, bool>> match);
        Task<ICollection<TModel>> GetAllAsync();
    }
}
