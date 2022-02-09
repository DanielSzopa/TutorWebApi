using FluentValidation;
using TutorWebApi.Application.Models.Advert;

namespace TutorWebApi.Application.Validators.Advert
{
    public class NewAdvertContactDtoValidator : AbstractValidator<NewAdvertContact>
    {
        public NewAdvertContactDtoValidator()
        {
            RuleFor(a => a.Mail)
                .MaximumLength(100).WithMessage("Mail can not have more letters than 100")
                .NotEmpty().WithMessage("Mail can not be empty");
        }
    }
}
