using Blog.Core.Models.Content;
using Blog.Core.Models;

namespace Blog.WebMvc.Models;

public class SeriesDetailViewModel
{
    public SeriesDto Series { get; set; }
    public PagedResult<PostInListDto> Posts { get; set; }
}
