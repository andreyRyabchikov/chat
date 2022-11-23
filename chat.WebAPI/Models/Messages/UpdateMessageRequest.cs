using FluentValidation;
using FluentValidation.Results;

namespace chat.WebAPI.Models;

public class UpdateMessageRequest
{
    #region Model

    public string Text { get; set; }
    public DateTime SendTime { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateMessageRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Text)
                .MaximumLength(255).WithMessage("Length must be less than 256");
                 RuleFor(x => x.SendTime).InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateMessageRequestExtension
{
    public static ValidationResult Validate(this UpdateMessageRequest model)
    {
        return new UpdateMessageRequest.Validator().Validate(model);
    }
}