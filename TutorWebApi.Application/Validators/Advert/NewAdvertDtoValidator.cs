using FluentValidation;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Advert;

namespace TutorWebApi.Application.Validators.Advert
{
    public class NewAdvertDtoValidator : AbstractValidator<NewAdvertDto>
    {
        private bool result;
        private List<int> Subjects { get; set; } = new List<int>();
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
                .MustAsync(async (value, cancelation) =>
                {
                    Subjects = await subjectService.GetAllSubjectsId();
                    bool isSubjectsContain = Subjects.Contains(value);
                    result = isSubjectsContain;
                    return isSubjectsContain;
                })
                .Custom((value, context) =>
                {
                    if(!result)
                        context.AddFailure(nameof(NewAdvertDto.SubjectId),$"Subject must be in [{string.Join(",", Subjects)}]");
                });

            RuleFor(a => a.AdvertContact)
               .SetValidator(new NewAdvertContactDtoValidator());
        }
    }
}
