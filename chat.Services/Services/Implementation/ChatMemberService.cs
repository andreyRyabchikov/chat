using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class ChatMemberService : IChatMemberService
{
    private readonly IRepository<ChatMember> ChatMembersRepository;
     private readonly IRepository<User> usersRepository;
    private readonly IRepository<Chat> ChatsRepository;
    private readonly IMapper mapper;
    public ChatMemberService(IRepository<Chat> ChatsRepository,IRepository<User> usersRepository,IRepository<ChatMember> ChatMembersRepository, IMapper mapper)
    {
        this.ChatMembersRepository = ChatMembersRepository;
        this.mapper = mapper;
        this.usersRepository = usersRepository;
        this.ChatsRepository = ChatsRepository;
    }

    public void DeleteChatMember(Guid id)
    {
        var ChatMemberToDelete = ChatMembersRepository.GetById(id);
        if (ChatMemberToDelete == null)
        {
            throw new Exception("ChatMember not found"); //   реализовать service exeption class const
        }

        ChatMembersRepository.Delete(ChatMemberToDelete);
    }

    public ChatMemberModel GetChatMember(Guid id)
    {
        var ChatMember = ChatMembersRepository.GetById(id);
         if (ChatMember == null)
        {
            throw new Exception("ChatMember not found"); //   реализовать service exeption class const
        }
        return mapper.Map<ChatMemberModel>(ChatMember);
    }

    public PageModel<ChatMemberModel> GetChatMembers(int limit = 20, int offset = 0)
    {
        var ChatMembers = ChatMembersRepository.GetAll();
        int totalCount = ChatMembers.Count();
        var chunk = ChatMembers.OrderBy(x => x.IdUser).Skip(offset).Take(limit);

        return new PageModel<ChatMemberModel>()
        {
           
            Items = mapper.Map<IEnumerable<ChatMemberModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public ChatMemberModel UpdateChatMember(Guid id, ChatMemberModel ChatMember)
    {
        var existingChatMember = ChatMembersRepository.GetById(id);
        if (existingChatMember == null)
        {
            throw new Exception("ChatMember not found");
        }

        existingChatMember.IdUser= ChatMember.IdUser;
        existingChatMember.IdChat = ChatMember.IdChat;

        existingChatMember = ChatMembersRepository.Save(existingChatMember);
        return mapper.Map<ChatMemberModel>(existingChatMember);
    }
     ChatMember IChatMemberService.AddChatMember(ChatMemberModel ChatMemberModel)
    {
        ChatMembersRepository.Save(mapper.Map<ChatMember>(ChatMemberModel));
        ChatMember modelCreate = new ChatMember();
        modelCreate.Id=ChatMemberModel.Id;
        modelCreate.CreationTime = ChatMemberModel.CreationTime;
        modelCreate.ModificationTime= ChatMemberModel.ModificationTime;
        modelCreate.IdChat = ChatMemberModel.IdChat;
        modelCreate.IdUser = ChatMemberModel.IdUser;
        modelCreate.User = usersRepository.GetAll(x => x.Id == modelCreate.IdUser).FirstOrDefault();
        modelCreate.Chat = ChatsRepository.GetAll(x => x.Id == modelCreate.IdChat).FirstOrDefault();
        modelCreate.Chat.ChatMembers.Add(modelCreate);
        modelCreate.User.ChatMembers.Add(modelCreate);

        return modelCreate;
    }
}