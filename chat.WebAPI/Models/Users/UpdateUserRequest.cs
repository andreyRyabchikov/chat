using FluentValidation;
using FluentValidation.Results;

namespace chat.WebAPI.Models;

public class UpdateUserRequest
{
    #region Model

    public string Name { get; set; }
    public bool Ban{ get;set;}

    #endregion

    #region Validator

    public class Validator : AbstractValidator<UpdateUserRequest>
    {
        public Validator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(255).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateUserRequestExtension
{
    public static ValidationResult Validate(this UpdateUserRequest model)
    {
        return new UpdateUserRequest.Validator().Validate(model);
    }
}