using FluentValidation;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Advert;

namespace TutorWebApi.Application.Validators.Advert
{
    public class NewAdvertDtoValidator : AbstractValidator<NewAdvertDto>
    {
        public NewAdvertDtoValidator(ISubjectService subjectService)
        {
            RuleFor(a => a.Title)
                .MaximumLength(150).WithMessage("Title can not have more letters than 150")
                .NotEmpty().WithMessage("Title can not be empty");

            RuleFor(a => a.Description)
                .MaximumLength(300).WithMessage("Title can not have more letters than 300");

            RuleFor(a => a.City)
                .MaximumLength(50).WithMessage("City can not have more letters than 50")
                .NotEmpty().WithMessage("City can not be empty");

            RuleFor(a => a.SubjectId)
                .CustomAsync(async (value, context, token) =>
                {
                    var subjects = await subjectService.GetAllSubjectsId();
                    bool isSubjectsContain = subjects.Contains(value);
                    if (!isSubjectsContain)
                        context.AddFailure(nameof(NewAdvertDto.SubjectId), $"Subject must be in [{string.Join(",", subjects)}]");
                });

            RuleFor(a => a.AdvertContact)
               .SetValidator(new NewAdvertContactDtoValidator());
        }
    }
}
