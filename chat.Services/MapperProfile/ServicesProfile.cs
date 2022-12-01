using AutoMapper;
using chat.Entity.Models;
using chat.Services.Models;

namespace chat.Services.MapperProfile;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
      #region Student
        CreateMap<User, UserModel>().ReverseMap();
        CreateMap<User, UserPreviewModel>().ReverseMap();
        #endregion

             #region Chats

        CreateMap<Chat, ChatModel>().ReverseMap();
        CreateMap<Chat, ChatPreviewModel>().ReverseMap();
        #endregion
         #region ChatMembers

        CreateMap<ChatMember, ChatMemberModel>().ReverseMap();
        CreateMap<ChatMember, ChatPreviewModel>().ReverseMap();
        #endregion
         #region BlackList

        CreateMap<BlackList, BlackListModel>().ReverseMap();
        #endregion
         #region Attachments

        CreateMap<Attachment, AttachmentModel>().ReverseMap();
        CreateMap<Attachment, AttachmentPreviewModel>().ReverseMap();
        #endregion
        #region Contact

        CreateMap<Contact, ContactModel>().ReverseMap();
        #endregion

        #region Messages

         CreateMap<Message, MessageModel>().ReverseMap();
         CreateMap<Message, MessagePreviewModel>().ReverseMap();


        #endregion


    }
}