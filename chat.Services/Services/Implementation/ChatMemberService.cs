using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class ChatMemberService : IChatMemberService
{
    private readonly IRepository<ChatMember> ChatMembersRepository;
    private readonly IMapper mapper;
    public ChatMemberService(IRepository<ChatMember> ChatMembersRepository, IMapper mapper)
    {
        this.ChatMembersRepository = ChatMembersRepository;
        this.mapper = mapper;
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
}