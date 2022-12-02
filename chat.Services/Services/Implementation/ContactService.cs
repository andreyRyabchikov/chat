using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class ContactService : IContactService
{
    private readonly IRepository<Contact> ContactsRepository;
    private readonly IRepository<User> usersRepository;
    private readonly IMapper mapper;
    public ContactService(IRepository<User> usersRepository,IRepository<Contact> ContactsRepository, IMapper mapper)
    {
        this.ContactsRepository = ContactsRepository;
        this.mapper = mapper;
        this.usersRepository = usersRepository;
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
     Contact IContactService.AddContact(ContactModel ContactModel)
    {
        if (ContactsRepository.GetAll(x => x.Id == ContactModel.Id).FirstOrDefault()!=null)
            throw new Exception("create not uniqe subject");
   
        Contact modelCreate = new Contact();
        modelCreate.Id=ContactModel.Id;
        modelCreate.CreationTime = ContactModel.CreationTime;
        modelCreate.ModificationTime= ContactModel.ModificationTime;
        modelCreate.AddTime = ContactModel.AddTime;
        modelCreate.IdUser = ContactModel.IdUser;
        modelCreate.IdUserContact = ContactModel.IdUserContact;
        modelCreate.User = usersRepository.GetAll(x => x.Id == modelCreate.IdUser).FirstOrDefault();
        modelCreate.UserContact = usersRepository.GetAll(x => x.Id == modelCreate.IdUserContact).FirstOrDefault();
        modelCreate.User.ThatContacts.Add(modelCreate);
        modelCreate.UserContact.ThemContacts.Add(modelCreate);
        ContactsRepository.Save(mapper.Map<Contact>(modelCreate));
        return modelCreate;
    }
}