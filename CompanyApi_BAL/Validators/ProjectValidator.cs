using EmployeeApi.Model;
using FluentValidation;

namespace CompanyApi.Validators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.ProjectName).NotEmpty().WithMessage("TeamLeader is Required").MaximumLength(20).WithMessage("Length Can't be More than 50");
            RuleFor(x => x.ProjectLeader).NotEmpty().WithMessage("ProjectLeader is Required").MaximumLength(20).WithMessage("Length Can't be More than 50");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Language is Necessary").MaximumLength(15).WithMessage("Length Can't be More than 15");
        }
    }
}
