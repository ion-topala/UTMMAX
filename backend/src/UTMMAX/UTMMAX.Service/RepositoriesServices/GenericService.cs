using UTMMAX.Domain.Entities;
using UTMMAX.Repository.Repositories;

namespace UTMMAX.Service.RepositoriesServices;

public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : BaseEntity
{
    protected readonly IRepository<TEntity> Repository;

    protected GenericService(IRepository<TEntity> repository)
    {
        Repository = repository;
    }

    public async Task<TEntity?> GetById(int id)
    {
        return await Repository.GetById(id);
    }

    public async Task Insert(TEntity entity)
    {
        await Repository.Insert(entity);
    }

    public async Task Update(TEntity entity)
    {
        await Repository.Update(entity);
    }

    public async Task Delete(TEntity entity)
    {
        await Repository.Delete(entity);
    }
}