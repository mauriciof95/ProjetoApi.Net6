using Api.Interfaces;
using Models;

namespace Api.Services
{
    public class BaseServices<TModel> : IBaseService<TModel> where TModel : BaseModel
    {
        private readonly IBaseRepository<TModel> _repository;
        public BaseServices(IBaseRepository<TModel> repository)
            => _repository = repository;

        public virtual async Task<ICollection<TModel>> GetAll() 
            => await _repository.GetAllAsync();
        
        public virtual async Task<TModel> FindByID(long id) 
            => await _repository.FindByIdAsync(id);
        
        public virtual async Task<TModel> Create(TModel model)
        {
            model.data_criacao = DateTime.Now;
            return await _repository.CreateAsync(model);
        }

        public virtual async Task Create(List<TModel> models) 
        { 
            foreach (TModel model in models) await Create(model); 
        }
        
        public virtual async Task<TModel> Update(TModel model, long id)
        {
            TModel old = await FindByID(id);

            if (model == null) return null;

            if(old != null)
            {
                model.data_edicao = DateTime.Now;
                model = await _repository.UpdateAsync(model, old);
            }

            return model;
        }
        
        public virtual async Task Delete(long id) 
        {
            TModel model = await FindByID(id);

            if(model == null) return;

            await _repository.DeleteAsync(model);
        }
    }
}
