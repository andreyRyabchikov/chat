using AutoMapper;
using chat.Entity.Models;
using chat.Services.Models;

namespace chat.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        #region Users

        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>().ReverseMap();  

        #endregion
    }
}