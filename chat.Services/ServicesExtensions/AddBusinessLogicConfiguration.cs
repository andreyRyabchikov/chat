using chat.Services.Abstract;
using chat.Services.Implementation;
using chat.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace chat.Services;

public static partial class ServicesExtensions
{
    public static void AddBusinessLogicConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAttachmentService, AttachmentService>();
        services.AddScoped<IChatService, ChatService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IChatMemberService, ChatMemberService>();
        services.AddScoped<IContactService, ContactService>();
        services.AddScoped<IBlackListService, BlackListService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}