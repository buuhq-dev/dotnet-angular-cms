using Blog.Core.Models.Content;

namespace Blog.WebMvc.Models;

public class PostDetailViewModel
{
    public PostDto Post { get; set; }
    public PostCategoryDto Category { get; set; }
}
