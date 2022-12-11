using System;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Chat.WebAPI.AppConfiguration;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_LOGIN = "master";
    public const string MASTER_ADMIN_PASSWORD = "master";
    public const string MASTER_ADMIN_NAME = "master";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new chat.Services.Models.RegisterUserModel()
        {
            Login = MASTER_ADMIN_LOGIN,
            Password = MASTER_ADMIN_PASSWORD,
            Name = MASTER_ADMIN_NAME
        });
    }

     public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
        {
            var usersRepository = (IRepository<User>)scope.ServiceProvider.GetRequiredService(typeof(IRepository<User>));
            var user = usersRepository.GetAll().Where(x => x.Login == MASTER_ADMIN_LOGIN).FirstOrDefault();
            if (user == null)
            {
                var authService = (IAuthService)scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                await CreateGlobalAdmin(authService);
            }
        }
    }
}