﻿using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Blog.Core.Domain.Content;

namespace Blog.Core.Models.Content;

public class SeriesDto : SeriesInListDto
{
    [MaxLength(250)]
    public string? SeoDescription { get; set; }

    [MaxLength(250)]
    public string? Thumbnail { set; get; }

    public string? Content { get; set; }

    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Series, SeriesDto>();
        }
    }
}
