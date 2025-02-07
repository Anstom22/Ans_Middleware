using Ans_Middleware.Data;
using Ans_Middleware.Models;
using Microsoft.EntityFrameworkCore;

namespace Ans_Middleware.Repositories
{
    public class SQLHeaderRepository : IHeaderRepository
    {
        private readonly AppDbContext dbContext;

        public SQLHeaderRepository(AppDbContext dbContext) {
            this.dbContext = dbContext;
        }
        public async Task<List<Header>> GetHeadersAsync()
        {
           return await dbContext.Headers.ToListAsync();
            
        }

        public async Task SaveHeadersAsync(Header header)
        {
            await dbContext.Headers.AddAsync(header);
            await dbContext.SaveChangesAsync();
                        
        }
    }
}
