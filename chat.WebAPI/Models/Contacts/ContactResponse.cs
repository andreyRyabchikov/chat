using FluentValidation;
using FluentValidation.Results;
namespace chat.WebAPI.Models;

public class ContactResponse
{
    #region Model
     public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }
    public virtual Guid IdUserContact { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<ContactResponse>
    {
        public Validator()
        {
                 RuleFor(x => x.AddTime).InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateContactRequestExtension
{
    public static ValidationResult Validate(this ContactResponse model)
    {
        return new ContactResponse.Validator().Validate(model);
    }
}