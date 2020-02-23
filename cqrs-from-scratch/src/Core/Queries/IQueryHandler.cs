using System.Threading.Tasks;

namespace CQRS.Queries
{
    public interface IQueryHandler<in TQueryParameters, TResult>
        where TQueryParameters : IQuery
    {
        Task<TResult> ExecuteQueryAsync(TQueryParameters queryParameters);
    }
}
