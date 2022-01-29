using FluentValidation;

namespace TutorWebApi.Application
{
    public class CommentDtoValidator : AbstractValidator<NewCommentDto>
    {
        public CommentDtoValidator()
        {
            RuleFor(c => c.Comment)
                .NotEmpty().WithMessage("Comment can not be empty");
        }
    }
}
