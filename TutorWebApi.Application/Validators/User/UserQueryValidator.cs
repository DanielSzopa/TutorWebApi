using FluentValidation;
using TutorWebApi.Application.Models.User;

namespace TutorWebApi.Application.Validators.User
{
    public class UserQueryValidator : AbstractValidator<UserQuery>
    {
        private int[] allowedPageSizes = new int[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(UserDto.FullName), nameof(UserDto.City), nameof(UserDto.Role) };

        public UserQueryValidator()
        {
            RuleFor(u => u.PageNumber)
                .GreaterThanOrEqualTo(1);

            RuleFor(u => u.PageSize)
                .Custom((value, context) =>
                {
                    if(!allowedPageSizes.Contains(value))
                    {
                        var pageSize = nameof(UserQuery.PageSize);
                        context.AddFailure(pageSize, $"{pageSize} must be in [{string.Join(",", allowedPageSizes)}]");
                    }                        
                });

            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value)
                || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
