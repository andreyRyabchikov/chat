using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class ContactService : IContactService
{
    private readonly IRepository<Contact> ContactsRepository;
    private readonly IMapper mapper;
    public ContactService(IRepository<Contact> ContactsRepository, IMapper mapper)
    {
        this.ContactsRepository = ContactsRepository;
        this.mapper = mapper;
    }

    public void DeleteContact(Guid id)
    {
        var ContactToDelete = ContactsRepository.GetById(id);
        if (ContactToDelete == null)
        {
            throw new Exception("Contact not found"); //   реализовать service exeption class const
        }

        ContactsRepository.Delete(ContactToDelete);
    }

    public ContactModel GetContact(Guid id)
    {
        var Contact = ContactsRepository.GetById(id);
         if (Contact == null)
        {
            throw new Exception("Contact not found"); //   реализовать service exeption class const
        }
        return mapper.Map<ContactModel>(Contact);
    }

    public PageModel<ContactModel> GetContacts(int limit = 20, int offset = 0)
    {
        var Contacts = ContactsRepository.GetAll();
        int totalCount = Contacts.Count();
        var chunk = Contacts.OrderBy(x => x.IdUser).Skip(offset).Take(limit);

        return new PageModel<ContactModel>()
        {
           
            Items = mapper.Map<IEnumerable<ContactModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public ContactModel UpdateContact(Guid id, ContactModel Contact)
    {
        var existingContact = ContactsRepository.GetById(id);
        if (existingContact == null)
        {
            throw new Exception("Contact not found");
        }

        existingContact.IdUser = Contact.IdUser;
        existingContact.IdUserContact = Contact.IdUserContact;

        existingContact = ContactsRepository.Save(existingContact);
        return mapper.Map<ContactModel>(existingContact);
    }
     ContactModel IContactService.AddContact(ContactModel ContactModel)
    {
        ContactsRepository.Save(mapper.Map<Contact>(ContactModel));
        return ContactModel;
    }
}