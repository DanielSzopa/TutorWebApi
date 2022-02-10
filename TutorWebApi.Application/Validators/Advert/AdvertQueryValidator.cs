using FluentValidation;
using TutorWebApi.Application.Models.Advert;

namespace TutorWebApi.Application.Validators.Advert
{
    public class AdvertQueryValidator : AbstractValidator<AdvertQuery>
    {
        private readonly int[] allowedPageSize = new int[] { 5, 10, 15, 20 };
        private readonly string[] allowedSortByColumnNames = new string[] { nameof(AdvertDto.City), nameof(AdvertDto.Subject)};
        public AdvertQueryValidator()
        {
            RuleFor(a => a.PageNumber)
                .GreaterThanOrEqualTo(1);

            RuleFor(a => a.PageSize)
                .Custom((value, context) =>
                {
                    if (!allowedPageSize.Contains(value))
                        context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSize)}]");
                });

            RuleFor(a => a.SortBy)
                .Must(value => string.IsNullOrEmpty(value)
                    || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");              

        }
    }
}
