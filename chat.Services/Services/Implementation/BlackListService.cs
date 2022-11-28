using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class BlackListService : IBlackListService
{
    private readonly IRepository<BlackList> BlackListsRepository;
    private readonly IMapper mapper;
    public BlackListService(IRepository<BlackList> BlackListsRepository, IMapper mapper)
    {
        this.BlackListsRepository = BlackListsRepository;
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
}