using FluentValidation;
using FluentValidation.Results;

namespace chat.WebAPI.Models;

public class UpdateChatRequest
{
    #region Model

public string Name {get;set;}
    public Guid Avatar{get;set;}

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateChatRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateChatRequestExtension
{
    public static ValidationResult Validate(this UpdateChatRequest model)
    {
        return new UpdateChatRequest.Validator().Validate(model);
    }
}