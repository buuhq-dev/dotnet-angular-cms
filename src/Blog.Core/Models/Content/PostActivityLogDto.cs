﻿using AutoMapper;
using Blog.Core.Domain.Content;

namespace Blog.Core.Models.Content;

public class PostActivityLogDto
{
    public PostStatus FromStatus { set; get; }

    public PostStatus ToStatus { set; get; }

    public DateTime DateCreated { get; set; }

    public string? Note { set; get; }

    public string UserName { get; set; }

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PostActivityLog, PostActivityLogDto>();
        }
    }
}
