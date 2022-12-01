using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class MessageService : IMessageService
{
    private readonly IRepository<Message> MessagesRepository;
         private readonly IRepository<User> usersRepository;
    private readonly IRepository<Chat> ChatsRepository;
    private readonly IMapper mapper;
    public MessageService(IRepository<Chat> ChatsRepository,IRepository<User> usersRepository,IRepository<Message> MessagesRepository, IMapper mapper)
    {
        this.MessagesRepository = MessagesRepository;
        this.mapper = mapper;
        this.usersRepository = usersRepository;
        this.ChatsRepository = ChatsRepository;
    }

    public void DeleteMessage(Guid id)
    {
        var MessageToDelete = MessagesRepository.GetById(id);
        if (MessageToDelete == null)
        {
            throw new Exception("Message not found"); //   реализовать service exeption class const
        }

        MessagesRepository.Delete(MessageToDelete);
    }

    public MessageModel GetMessage(Guid id)
    {
        var Message = MessagesRepository.GetById(id);
         if (Message == null)
        {
            throw new Exception("Message not found"); //   реализовать service exeption class const
        }
        return mapper.Map<MessageModel>(Message);
    }

    public PageModel<MessagePreviewModel> GetMessages(int limit = 20, int offset = 0)
    {
        var Messages = MessagesRepository.GetAll();
        int totalCount = Messages.Count();
        var chunk = Messages.OrderBy(x => x.IdChat).Skip(offset).Take(limit);

        return new PageModel<MessagePreviewModel>()
        {
           
            Items = mapper.Map<IEnumerable<MessagePreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public MessageModel UpdateMessage(Guid id, UpdateMessageModel Message)
    {
        var existingMessage = MessagesRepository.GetById(id);
        if (existingMessage == null)
        {
            throw new Exception("Message not found");
        }

        existingMessage.Text= Message.Text;
        existingMessage.SendTime = Message.SendTime;

        existingMessage = MessagesRepository.Save(existingMessage);
        return mapper.Map<MessageModel>(existingMessage);
    }
     Message IMessageService.AddMessage(MessageModel MessageModel)
    {
        MessagesRepository.Save(mapper.Map<Message>(MessageModel));
        Message modelCreate = new Message();
        modelCreate.Id=MessageModel.Id;
        modelCreate.CreationTime = MessageModel.CreationTime;
        modelCreate.ModificationTime= MessageModel.ModificationTime;
        modelCreate.IdChat = MessageModel.IdChat;
        modelCreate.IdUser = MessageModel.IdUser;
        modelCreate.User = usersRepository.GetAll(x => x.Id == modelCreate.IdUser).FirstOrDefault();
        modelCreate.Chat = ChatsRepository.GetAll(x => x.Id == modelCreate.IdChat).FirstOrDefault();
        modelCreate.Chat.Messages.Add(modelCreate);
        modelCreate.User.Messages.Add(modelCreate);

        return modelCreate;
    }
}