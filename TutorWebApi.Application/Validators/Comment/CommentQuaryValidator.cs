using FluentValidation;
using TutorWebApi.Application.Models.Comment;

namespace TutorWebApi.Application.Validators.Comment
{
    public class CommentQuaryValidator : AbstractValidator<CommentQuery>
    {
        private int[] allowedPageSize = new int[] { 5, 10 };
        public CommentQuaryValidator()
        {
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1);

            RuleFor(c => c.PageSize)
                .Custom((value, context) =>
                {
                    if (!(allowedPageSize.Contains(value)))
                        context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSize)}]");
                });
        }
    }
}
