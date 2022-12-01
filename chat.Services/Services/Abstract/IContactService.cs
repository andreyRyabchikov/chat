using chat.Services.Models;
using chat.Entity.Models;

namespace chat.Services.Abstract;

public interface IContactService
{
    ContactModel GetContact(Guid id);

    ContactModel UpdateContact(Guid id, ContactModel Contact);

    void DeleteContact(Guid id);

    PageModel<ContactModel> GetContacts(int limit = 20, int offset = 0);
    Contact AddContact(ContactModel ContactModel);
}