using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class BlackListService : IBlackListService
{
    private readonly IRepository<BlackList> BlackListsRepository;
     private readonly IRepository<User> usersRepository;
    private readonly IMapper mapper;
    public BlackListService(IRepository<User> usersRepository, IRepository<BlackList> BlackListsRepository, IMapper mapper)
    {
        this.BlackListsRepository = BlackListsRepository;
        this.usersRepository = usersRepository;
        this.mapper = mapper;
    }

    public void DeleteBlackList(Guid id)
    {
        var BlackListToDelete = BlackListsRepository.GetById(id);
        if (BlackListToDelete == null)
        {
            throw new Exception("BlackList not found"); //   реализовать service exeption class const
        }

        BlackListsRepository.Delete(BlackListToDelete);
    }

    public BlackListModel GetBlackList(Guid id)
    {
        var BlackList = BlackListsRepository.GetById(id);
         if (BlackList == null)
        {
            throw new Exception("BlackList not found"); //   реализовать service exeption class const
        }
        return mapper.Map<BlackListModel>(BlackList);
    }

    public PageModel<BlackListModel> GetBlackLists(int limit = 20, int offset = 0)
    {
        var BlackLists = BlackListsRepository.GetAll();
        int totalCount = BlackLists.Count();
        var chunk = BlackLists.OrderBy(x => x.IdUser).Skip(offset).Take(limit);

        return new PageModel<BlackListModel>()
        {
           
            Items = mapper.Map<IEnumerable<BlackListModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public BlackListModel UpdateBlackList(Guid id, BlackListModel BlackList)
    {
        var existingBlackList = BlackListsRepository.GetById(id);
        if (existingBlackList == null)
        {
            throw new Exception("BlackList not found");
        }

        existingBlackList.IdUser= BlackList.IdUser;
        existingBlackList.IdUserBlocked = BlackList.IdUserBlocked;

        existingBlackList = BlackListsRepository.Save(existingBlackList);
        return mapper.Map<BlackListModel>(existingBlackList);
    }
    BlackList IBlackListService.AddBlackList(BlackListModel BlackListModel)
    {
        BlackListsRepository.Save(mapper.Map<BlackList>(BlackListModel));
        BlackList modelCreate = new BlackList();
        modelCreate.Id=BlackListModel.Id;
        modelCreate.CreationTime = BlackListModel.CreationTime;
        modelCreate.ModificationTime= BlackListModel.ModificationTime;
        modelCreate.AddTime = BlackListModel.AddTime;
        modelCreate.IdUser = BlackListModel.IdUser;
        modelCreate.IdUserBlocked = BlackListModel.IdUserBlocked;
        modelCreate.User = usersRepository.GetAll(x => x.Id == modelCreate.IdUser).FirstOrDefault();
        modelCreate.UserBlocked = usersRepository.GetAll(x => x.Id == modelCreate.IdUserBlocked).FirstOrDefault();
        modelCreate.User.ThemBanned.Add(modelCreate);
        modelCreate.UserBlocked.ThatBanned.Add(modelCreate);
        return modelCreate;
    }
}