using chat.Services.Models;

namespace chat.Services.Abstract;

public interface IBlackListService
{
    BlackListModel GetBlackList(Guid id);

    BlackListModel UpdateBlackList(Guid id, BlackListModel BlackList);

    void DeleteBlackList(Guid id);

    PageModel<BlackListModel> GetBlackLists(int limit = 20, int offset = 0);
    BlackListModel AddBlackList(BlackListModel BlackListModel);
}