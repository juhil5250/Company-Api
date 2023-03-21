using EmployeeApi.Model;
using FluentValidation;

namespace CompanyApi.Validators
{
    public class EmployeeAddressValidator : AbstractValidator<EmployeeAddress>
    {
        public EmployeeAddressValidator()
        {
            RuleFor(x => x.AddressLine1).NotEmpty().WithMessage("Name is Required.").Length(20,150);
            RuleFor(x => x.AddressLine2).MaximumLength(40).WithMessage("Length Can't be More than 40");
            RuleFor(x => x.city).NotEmpty().WithMessage("City is Must");
            RuleFor(x => x.State).NotEmpty().WithMessage("State is Must");
            RuleFor(x => x.ZipCode).Must(ValidZipCode).WithMessage("ZipCode length must be equal to 6");
        }

        private bool ValidZipCode(string zipCode)
        {
            if(zipCode.Length == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
