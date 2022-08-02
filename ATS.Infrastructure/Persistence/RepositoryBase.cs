using ATS.Application.Contracts.Persistence;
using Dapper;

namespace ATS.Infrastructure.Persistence
{
    public class RepositoryBase<T> : IAsyncRepository<T> where T : class
    {
        protected readonly DbConnection _connection;
        protected readonly JobApplication_HRContext _HRContext;
        private readonly string _tableName;

        public RepositoryBase(JobApplication_HRContext hRContext, string tableName)
        {
            _connection = new DbConnection();
            _HRContext = hRContext;
            _tableName = tableName;
        }

        public async Task<T> AddAsync(T item, CancellationToken token)
        {
            var obj = await _HRContext.Set<T>().AddAsync(item, token);
            if (await _HRContext.SaveChangesAsync() > 0)
            {
                return obj.Entity;
            }
            return null;
        }

        public virtual async Task<bool> DeleteAsync(int id, CancellationToken token)
        {
            object[] keyValues = new object[1];
            keyValues[0] = id;
            var obj = await _HRContext.Set<T>().FindAsync(keyValues: keyValues, cancellationToken:token);
            if(obj == null)
            {
                return false;
            }
            _HRContext.Set<T>().Remove(obj);
            return await _HRContext.SaveChangesAsync(token) > 0;
        }

        public virtual async Task<List<T>> GetListAsync(CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var result = await conn.QueryAsync<T>(new CommandDefinition($"Select * from {_tableName}", cancellationToken: token));
                return result.ToList();
            }
        }

        public virtual async Task<T> GetAsync(int id, CancellationToken token)
        {
            using (var conn = _connection.CreateConnection())
            {
                var result = await conn.QueryAsync<T>(new CommandDefinition($"Select * from {_tableName} as t where t.ID = {id}", cancellationToken: token));
                return result.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateAsync(T item, CancellationToken token)
        {
            _HRContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _HRContext.SaveChangesAsync(token) > 0;
        }
    }
}
