using FluentValidation;
using FluentValidation.Results;
namespace chat.WebAPI.Models;

public class BlackListResponse
{
    #region Model
     public DateTime AddTime { get; set; }
    public virtual Guid IdUser { get; set; }
    public virtual Guid IdUserBlocked { get; set; }

    #endregion

    #region Validator

    public class Validator : AbstractValidator<BlackListResponse>
    {
        public Validator()
        {
                 RuleFor(x => x.AddTime).InclusiveBetween(DateTime.MinValue,DateTime.Today).WithMessage("Length must be less than 256");
        }
    }

    #endregion
}

public static class UpdateBlackListRequestExtension
{
    public static ValidationResult Validate(this BlackListResponse model)
    {
        return new BlackListResponse.Validator().Validate(model);
    }
}