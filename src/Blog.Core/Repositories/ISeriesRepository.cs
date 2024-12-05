using Blog.Core.Models.Content;
using Blog.Core.Models;
using Blog.Core.SeedWorks;
using Blog.Core.Domain.Content;

namespace Blog.Core.Repositories;

public interface ISeriesRepository : IRepository<Series, Guid>
{
    Task<PagedResult<SeriesInListDto>> GetAllPaging(string? keyword, int pageIndex = 1, int pageSize = 10);
    Task AddPostToSeries(Guid seriesId, Guid postId, int sortOrder);
    Task RemovePostToSeries(Guid seriesId, Guid postId);
    Task<List<PostInListDto>> GetAllPostsInSeries(Guid seriesId);
    Task<bool> IsPostInSeries(Guid seriesId, Guid postId);
    Task<bool> HasPost(Guid seriesId);
}
