namespace TWJobs.Core.Repositories;

public interface ICrudRepository<TModel, in TId>
{
    bool ExistsById(TId id);
    ICollection<TModel> FindAll();
    TModel Create(TModel model);
    TModel? FindById(TId id);
    TModel Update(TModel model);
    void DeleteById(TId id);
}
