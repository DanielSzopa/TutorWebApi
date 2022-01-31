using FluentValidation;
using TutorWebApi.Application.Models.Comment;

namespace TutorWebApi.Application.Validators.Comment
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
