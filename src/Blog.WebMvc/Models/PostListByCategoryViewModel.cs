using Blog.Core.Models.Content;
using Blog.Core.Models;

namespace Blog.WebMvc.Models;

public class PostListByCategoryViewModel
{
    public PostCategoryDto Category { get; set; }
    public PagedResult<PostInListDto> Posts { get; set; }
}
