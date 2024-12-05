using Blog.Core.Models.Royalty;
using Blog.Core.Models;
using Blog.Core.SeedWorks;
using Blog.Core.Domain.Royalty;

namespace Blog.Core.Repositories;

public interface ITransactionRepository : IRepository<Transaction, Guid>
{
    Task<PagedResult<TransactionDto>> GetAllPaging(string? userName,
     int fromMonth, int fromYear, int toMonth, int toYear, int pageIndex = 1, int pageSize = 10);
}
