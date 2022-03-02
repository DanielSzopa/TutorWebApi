using FluentValidation;
using TutorWebApi.Application.Interfaces;
using TutorWebApi.Application.Models.Subject;

namespace TutorWebApi.Application.Validators.Subject
{
    public class NewSubjectDtoValidator : AbstractValidator<NewSubjectDto>
    {
        public NewSubjectDtoValidator(ISubjectService subjectService)
        {
            RuleFor(s => s.Subject)
                .MaximumLength(50).WithMessage("Subject can not have more letters than 50")
                .NotEmpty().WithMessage("Subject can not be empty");

            RuleFor(s => s.Subject)
                .MustAsync(async (value, cancelation) =>
                {
                    var isExist = await subjectService.IsSubjectExist(value);
                    return !isExist;
                })
                .WithMessage("Can not create the same subject");
        }
    }
}
