using FluentValidation;
using FluentValidation.Results;

namespace chat.WebAPI.Models;

public class UpdateAttachmentRequest
{
    #region Model

    public string Name { get; set; }
    public Guid Type { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateAttachmentRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateAttachmentRequestExtension
{
    public static ValidationResult Validate(this UpdateAttachmentRequest model)
    {
        return new UpdateAttachmentRequest.Validator().Validate(model);
    }
}