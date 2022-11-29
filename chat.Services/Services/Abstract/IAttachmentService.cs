using chat.Services.Models;

namespace chat.Services.Abstract;

public interface IAttachmentService
{
    AttachmentModel GetAttachment(Guid id);

    AttachmentModel UpdateAttachment(Guid id, UpdateAttachmentModel Attachment);

    void DeleteAttachment(Guid id);

    PageModel<AttachmentPreviewModel> GetAttachments(int limit = 20, int offset = 0);
    AttachmentModel AddAttachment(AttachmentModel AttachmentModel);
}