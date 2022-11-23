using FluentValidation;
using FluentValidation.Results;

namespace chat.WebAPI.Models;

public class ChatMemberResponse
{
    #region Model

    public virtual Guid IdUser { get; set; }
    public virtual Guid IdChat { get; set; }

    #endregion

}