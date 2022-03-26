using FluentValidation;
using TutorWebApi.Application.Models.User;

namespace TutorWebApi.Application.Validators.User
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(r => r.Country)
                 .NotEmpty().WithMessage("Country can not be empty")
                  .MaximumLength(50).WithMessage("Country can not have more letters than 50");

            RuleFor(r => r.City)
                 .NotEmpty().WithMessage("City can not be empty")
                  .MaximumLength(50).WithMessage("City can not have more letters than 50");

            RuleFor(r => r.PosteCode)
                .NotEmpty().WithMessage("PosteCode can not be empty")
                 .MaximumLength(10).WithMessage("PosteCode can not have more letters than 10");

            RuleFor(r => r.Street)
                  .MaximumLength(50).WithMessage("Street can not have more letters than 60");

            RuleFor(r => r.AccommodationNumber)
                  .MaximumLength(6).WithMessage("Accommodation Number can not have more letters than 6");
        }
    }
}
