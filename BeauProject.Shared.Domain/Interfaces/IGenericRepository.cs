namespace BeauProject.Shared.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(long id);
        Task<TEntity> GetAsync(string id);
        Task<IQueryable<TEntity>> GetAll();
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
