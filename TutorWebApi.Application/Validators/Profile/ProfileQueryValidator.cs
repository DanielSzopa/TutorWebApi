using FluentValidation;
using TutorWebApi.Application.Models.Profile;

namespace TutorWebApi.Application.Validators.Profile
{
    public class ProfileQueryValidator : AbstractValidator<ProfileQuery>
    {
        private int[] allowedPageSizes = new int[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(SmallProfileDto.FullName), nameof(SmallProfileDto.City) };
        public ProfileQueryValidator()
        {
            RuleFor(r => r.PageNumber)
                .GreaterThanOrEqualTo(1);

            RuleFor(r => r.PageSize)
                .Custom((value, context) =>
                {
                    if (!allowedPageSizes.Contains(value))
                        context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                });

            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value)
                || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",",allowedSortByColumnNames)}]");
        }
    }
}
