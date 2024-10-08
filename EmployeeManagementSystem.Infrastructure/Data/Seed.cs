﻿using EmployeeManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagementSystem.Infrastructure.Data;

public static class Seed
{
    public static async void SeedAdmin(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        if ((await userManager.GetUsersInRoleAsync("Admin")).Any()) return;
        await roleManager.CreateAsync(new Role() { Name = "Admin" });

        var user = new User()
        {
            UserName = "Admin1",
            FirstName = "Admin",
            SecondName = "Admin",
            Email = "admin@gmail.com",
            RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
        };
        
        var user2 = new User()
        {
            UserName = "Admin2",
            FirstName = "Admin",
            SecondName = "Admin",
            Email = "admin2@gmail.com",
            RegistrationDate = DateOnly.FromDateTime(DateTime.Now),
        };

      
        var result = await userManager.CreateAsync(user, "password1");
        var result2 = await userManager.CreateAsync(user2, "password1");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }

        if (result2.Succeeded)
        {
            await userManager.AddToRoleAsync(user2, "Admin");
        }
    }
}