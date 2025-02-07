using Ans_Middleware.Models;

namespace Ans_Middleware.Repositories
{
    public interface IHeaderRepository
    {
        Task<List<Header>>GetHeadersAsync();
        Task SaveHeadersAsync(Header header);
    }
}
