namespace Api.Interfaces
{
    public interface IBaseService<TModel>
    {
        Task <ICollection<TModel>> GetAll();

        Task<TModel> FindByID(long id);

        Task<TModel> Create(TModel model);

        Task Create(List<TModel> models);

        Task <TModel> Update(TModel model, long id);

        Task Delete(long id);
    }
}
