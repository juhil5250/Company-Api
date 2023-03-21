using EmployeeApi.Model;
using FluentValidation;

namespace CompanyApi.Validators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        public DepartmentValidator()
        {
            RuleFor(d => d.Name).NotEmpty().WithMessage("Name is Required.").MaximumLength(30).WithMessage("Length Can't be More than 30");
        }
    }
}
