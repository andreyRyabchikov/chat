using chat.Services.Models;
using chat.Entity.Models;
namespace chat.Services.Abstract;

public interface IMessageService
{
    MessageModel GetMessage(Guid id);

    MessageModel UpdateMessage(Guid id, UpdateMessageModel Message);

    void DeleteMessage(Guid id);

    PageModel<MessagePreviewModel> GetMessages(int limit = 20, int offset = 0);
    MessageModel AddMessage(MessageModel MessageModel);
}