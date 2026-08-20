using Customer.Domain.Entities;
using Customer.Domain.EnumExtensions;
using Customer.Domain.Enums;
using Customer.Domain.Helpers;
using FluentValidation;

namespace Customer.Domain.Validators
{
    public class UpdateCustomerValidation : AbstractValidator<CustomerEntity>
    {
        public UpdateCustomerValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(CustomerEnum.CustomerRegistration_InvalidName.GetDescription());

            RuleFor(x => x.CPF)
               .Must(Utils.CpfIsValid)
               .WithMessage(CustomerEnum.Customer_InvalidCpf.GetDescription());
        }
    }
}
