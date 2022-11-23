using AutoMapper;
using chat.Entity.Models;
using chat.Repository;
using chat.Services.Abstract;
using chat.Services.Models;

namespace chat.Services.Implementation;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> AttachmentsRepository;
    private readonly IMapper mapper;
    public AttachmentService(IRepository<Attachment> AttachmentsRepository, IMapper mapper)
    {
        this.AttachmentsRepository = AttachmentsRepository;
        this.mapper = mapper;
    }

    public void DeleteAttachment(Guid id)
    {
        var AttachmentToDelete = AttachmentsRepository.GetById(id);
        if (AttachmentToDelete == null)
        {
            throw new Exception("Attachment not found"); //   реализовать service exeption class const
        }

        AttachmentsRepository.Delete(AttachmentToDelete);
    }

    public AttachmentModel GetAttachment(Guid id)
    {
        var Attachment = AttachmentsRepository.GetById(id);
         if (Attachment == null)
        {
            throw new Exception("Attachment not found"); //   реализовать service exeption class const
        }
        return mapper.Map<AttachmentModel>(Attachment);
    }

    public PageModel<AttachmentPreviewModel> GetAttachments(int limit = 20, int offset = 0)
    {
        var Attachments = AttachmentsRepository.GetAll();
        int totalCount = Attachments.Count();
        var chunk = Attachments.OrderBy(x => x.Name).Skip(offset).Take(limit);

        return new PageModel<AttachmentPreviewModel>()
        {
           
            Items = mapper.Map<IEnumerable<AttachmentPreviewModel>>(chunk),
            TotalCount = totalCount
        };
    }

    public AttachmentModel UpdateAttachment(Guid id, UpdateAttachmentModel Attachment)
    {
        var existingAttachment = AttachmentsRepository.GetById(id);
        if (existingAttachment == null)
        {
            throw new Exception("Attachment not found");
        }

        existingAttachment.Name= Attachment.Name;
        existingAttachment.Type = Attachment.Type;

        existingAttachment = AttachmentsRepository.Save(existingAttachment);
        return mapper.Map<AttachmentModel>(existingAttachment);
    }
}