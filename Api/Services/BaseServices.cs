using Api.Data.Context;
using Infrastructure.Data.Repository;

using Models;

namespace Api.Services
{
    public class BaseServices<TModel, TRepository>
        where TModel : BaseModel
        where TRepository : BaseRepository<TModel>
    {
        protected TRepository _repository;
        public BaseServices(ApiContext context)
            => _repository = Activator.CreateInstance(typeof(TRepository), context) as TRepository;

        public async Task<ICollection<TModel>> GetAll() 
            => await _repository.GetAll();
        
        public async Task<TModel?> FindByID(long id) 
            => await _repository.FindById(id);
        
        public async Task<TModel> Create(TModel model)
        {
            model.data_criacao = DateTime.Now;
            return await _repository.Include(model);
        }

        public async Task Create(List<TModel> models) 
        { 
            foreach (TModel model in models) await Create(model); 
        }
        
        public async Task<TModel?> Update(TModel? model, long id)
        {
            TModel? old = await FindByID(id);

            if (model == null) return null;

            if(old != null)
            {
                model.data_edicao = DateTime.Now;
                model = await _repository.Update(model, old);
            }

            return model;
        }
        
        public async Task Delete(long id) 
        {
            TModel? model = await FindByID(id);

            if(model == null) return;

            await _repository.Delete(model);
        }
    }
}
