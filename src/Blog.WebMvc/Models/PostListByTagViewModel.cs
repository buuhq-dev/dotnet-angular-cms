using Blog.Core.Models.Content;
using Blog.Core.Models;

namespace Blog.WebMvc.Models;

public class PostListByTagViewModel
{
    public TagDto Tag { get; set; }
    public PagedResult<PostInListDto> Posts { get; set; }
}