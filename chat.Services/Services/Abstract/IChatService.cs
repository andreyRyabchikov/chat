using chat.Services.Models;

namespace chat.Services.Abstract;

public interface IChatService
{
    ChatModel GetChat(Guid id);

    ChatModel UpdateChat(Guid id, UpdateChatModel Chat);

    void DeleteChat(Guid id);

    PageModel<ChatPreviewModel> GetChats(int limit = 20, int offset = 0);
    ChatModel AddChat(ChatModel ChatModel);
}