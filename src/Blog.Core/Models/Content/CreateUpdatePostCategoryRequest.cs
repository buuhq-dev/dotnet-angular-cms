﻿using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Blog.Core.Domain.Content;

namespace Blog.Core.Models.Content;

public class CreateUpdatePostCategoryRequest
{
    [MaxLength(250)]
    public required string Name { get; set; }

    public required string Description { get; set; }

    [MaxLength(250)]
    public required string Slug { get; set; }

    public bool IsActive { get; set; }
    public int SortOrder { get; set; }

    [MaxLength(250)]
    public string? SeoKeywords { get; set; }

    [MaxLength(250)]
    public string? SeoDescription { get; set; }

    [MaxLength(250)]
    public string? Thumbnail { set; get; }

    public string? Content { get; set; }
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateUpdateSeriesRequest, Series>();
        }
    }
}
