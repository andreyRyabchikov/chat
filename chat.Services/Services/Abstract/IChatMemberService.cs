using chat.Services.Models;

namespace chat.Services.Abstract;

public interface IChatMemberService
{
    ChatMemberModel GetChatMember(Guid id);

    ChatMemberModel UpdateChatMember(Guid id, ChatMemberModel ChatMember);

    void DeleteChatMember(Guid id);

    PageModel<ChatMemberModel> GetChatMembers(int limit = 20, int offset = 0);
   ChatMemberModel AddChatMember(ChatMemberModel ChatMemberModel);
    
}