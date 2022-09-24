using UTMMAX.Domain.Entities;

namespace UTMMAX.Service.RepositoriesServices;

public interface IGenericService<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetById(int id);
    Task           Insert(TEntity entity);
    Task           Update(TEntity entity);
    Task           Delete(TEntity entity);
}