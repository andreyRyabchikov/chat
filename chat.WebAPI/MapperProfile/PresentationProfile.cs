using AutoMapper;
using chat.WebAPI.Models;
using chat.Services.Models;

namespace chat.WebAPI.MapperProfile;

public class PresentationProfile : Profile
{
    public PresentationProfile()
    {
        #region  Pages

        CreateMap(typeof(PageModel<>), typeof(PageResponse<>));
        CreateMap(typeof(PageResponse<>), typeof(PageModel<>));

        #endregion

        #region Users

        CreateMap<UserModel, UserResponse>().ReverseMap();
        CreateMap<UpdateUserRequest, UpdateUserModel>().ReverseMap();
        CreateMap<UserPreviewModel, UserPreviewResponse>().ReverseMap();
        CreateMap<UserResponse,UserPreviewModel>().ReverseMap();
        #endregion
         #region Chats

        CreateMap<ChatModel, ChatResponse>().ReverseMap();
        CreateMap<UpdateChatRequest, UpdateChatModel>().ReverseMap();
        CreateMap<ChatPreviewModel, ChatPreviewResponse>().ReverseMap();
        CreateMap<ChatResponse,ChatPreviewModel>().ReverseMap();
        #endregion
         #region ChatMembers

        CreateMap<ChatMemberModel, ChatMemberResponse>().ReverseMap();
        #endregion
         #region BlackList

        CreateMap<BlackListModel, BlackListResponse>().ReverseMap();
        #endregion
         #region Attachments

        CreateMap<AttachmentModel, AttachmentResponse>().ReverseMap();
        CreateMap<UpdateAttachmentRequest, UpdateAttachmentModel>().ReverseMap();
        CreateMap<AttachmentPreviewModel, AttachmentPreviewResponse>().ReverseMap();
        CreateMap<AttachmentResponse,AttachmentPreviewModel>().ReverseMap();
        #endregion
        #region Contact

        CreateMap<ContactModel, ContactResponse>().ReverseMap();
        #endregion

        #region Messages

        CreateMap<MessageModel, MessageResponse>().ReverseMap();
        CreateMap<UpdateMessageRequest, UpdateMessageModel>().ReverseMap();
        CreateMap<MessagePreviewModel, MessagePreviewResponse>().ReverseMap();
        CreateMap<MessageResponse,MessagePreviewModel>().ReverseMap();


        #endregion
    }
}