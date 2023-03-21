using EmployeeApi.Model;
using FluentValidation;
using System.Drawing.Text;

namespace CompanyApi.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(v => v.Name).NotEmpty().WithMessage("Name is Required.").MaximumLength(50).WithMessage("Length Can't be More than 50");
            RuleFor(v => v.Email).EmailAddress().WithMessage("Invalid E-Mail Address").NotEmpty().WithMessage("E-Mail is required").MaximumLength(30).WithMessage("Length Can't be More than 30");
            RuleFor(v => v.ContactNo).Length(10).WithMessage("Length must be 10");
            RuleFor(v => v.Age).NotEmpty().WithMessage("Age is Required").GreaterThan(0).WithMessage("Age is always Greater than zero");
            RuleFor(v => v.Gender).Must(ValidateGender);
            RuleFor(v => v.DateofBirth).LessThan(DateTime.Now).NotEmpty().WithMessage("DateofBirth is Required");
        }

        private bool ValidateGender(string Gender)
        {
            if (Gender.ToLower() == "male" || Gender.ToLower() == "female")
            {
                return true;
            }
            return false;
        }
    }
}
