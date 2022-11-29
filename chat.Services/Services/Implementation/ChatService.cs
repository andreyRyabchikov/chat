using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class ChatService : IChatService
{
    private readonly IRepository<Chat> ChatsRepository;
    private readonly IMapper mapper;
    public ChatService(IRepository<Chat> ChatsRepository, IMapper mapper)
    {
        this.ChatsRepository = ChatsRepository;
        this.mapper = mapper;
    }

    public void DeleteChat(Guid id)
    {
        var ChatToDelete = ChatsRepository.GetById(id);
        if (ChatToDelete == null)
        {
            throw new Exception("Chat not found"); //   реализовать service exeption class const
        }

        ChatsRepository.Delete(ChatToDelete);
    }

    public ChatModel GetChat(Guid id)
    {
        var Chat = ChatsRepository.GetById(id);
         if (Chat == null)
        {
            throw new Exception("Chat not found"); //   реализовать service exeption class const
        }
        return mapper.Map<ChatModel>(Chat);
    }

    public PageModel<ChatPreviewModel> GetChats(int limit = 20, int offset = 0)
    {
        var Chats = ChatsRepository.GetAll();
        int totalCount = Chats.Count();
        var chunk = Chats.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<ChatPreviewModel>()
        {
           
            Items = mapper.Map<IEnumerable<ChatPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public ChatModel UpdateChat(Guid id, UpdateChatModel Chat)
    {
        var existingChat = ChatsRepository.GetById(id);
        if (existingChat == null)
        {
            throw new Exception("Chat not found");
        }

        existingChat.Name= Chat.Name;
        existingChat.Avatar = Chat.Avatar;

        existingChat = ChatsRepository.Save(existingChat);
        return mapper.Map<ChatModel>(existingChat);
    }
    ChatModel IChatService.AddChat(ChatModel ChatModel)
    {
        ChatsRepository.Save(mapper.Map<Chat>(ChatModel));
        return ChatModel;
    }
}