using EmployeeApi.Model;
using FluentValidation;

namespace CompanyApi.Validators
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.TeamLeader).NotEmpty().WithMessage("TeamLeader is Required").MaximumLength(20).WithMessage("Length Can't be More than 50");
        }
    }
}
