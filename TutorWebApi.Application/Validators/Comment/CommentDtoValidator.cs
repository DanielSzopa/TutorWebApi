using FluentValidation;

namespace TutorWebApi.Application
{
    public class CommentDtoValidator : AbstractValidator<CommentDto>
    {
        public CommentDtoValidator()
        {
            RuleFor(c => c.Comment)
                .NotEmpty().WithMessage("Comment can not be empty");
        }
    }
}
