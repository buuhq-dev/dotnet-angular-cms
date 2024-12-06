using Blog.Core.Models.Content;

namespace Blog.WebMvc.Models;

public class HomeViewModel
{
    public List<PostInListDto> LatestPosts { get; set; }
}
