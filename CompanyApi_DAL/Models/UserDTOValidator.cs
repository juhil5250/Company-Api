using CompanyApi.DTO;
using FluentValidation;

namespace CompanyApi.Models
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Name is Required.").MaximumLength(20).WithMessage("Length Can't be More than 20");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Enter Correct E-mail Address").MaximumLength(30).WithMessage("Length Can't be More than 30");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Password Must Be Greater than 6 digit");
        }
    }
}
