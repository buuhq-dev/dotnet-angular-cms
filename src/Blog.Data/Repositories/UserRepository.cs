﻿using Blog.Core.Domain.Identity;
using Blog.Core.Repositories;
using Blog.Data.SeedWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Repositories;

public class UserRepository : RepositoryBase<AppUser, Guid>, IUserRepository
{
    public UserRepository(BlogContext context) : base(context)
    {
    }

    public async Task RemoveUserFromRoles(Guid userId, string[] roleNames)
    {
        if (roleNames == null || roleNames.Length == 0)
            return;
        foreach (var roleName in roleNames)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Name == roleName);
            if (role == null)
            {
                return;
            }
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == userId);
            if (userRole == null)
            {
                return;
            }
            _context.UserRoles.Remove(userRole);
        }
    }
}
