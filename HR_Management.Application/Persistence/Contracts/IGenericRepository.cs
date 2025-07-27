namespace HR_Management.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> Get(int id);
        public Task<IReadOnlyList<T>> GetAll();
        public Task<T> Add(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
    }
}
