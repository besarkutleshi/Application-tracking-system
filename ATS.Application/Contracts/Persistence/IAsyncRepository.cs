namespace ATS.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T>
    {
        Task<T> GetAsync(int id, CancellationToken token);
        Task<List<T>> GetListAsync(CancellationToken token);
        Task<bool> DeleteAsync(int id, CancellationToken token);
        Task<T> AddAsync(T item, CancellationToken token);
        Task<bool> UpdateAsync(T item, CancellationToken token);
    }
}
