using BusinessLogic.DTO;
using BusinessLogic.Services.Abstractions.Requests;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogManager.ViewModels
{
    public class TitleViewModel
    {
        public int TitleId { get; set; }
        public int CatalogId { get; set; }

        public string Name { get; set; }
        public string Tag { get; set; }
        public int Count { get; set; }
    }

    public class TitleViewModelValidator : AbstractValidator<TitleViewModel>
    {
        public TitleViewModelValidator(IStringLocalizer<TitleViewModel> localizer, ITitlesRequestsService titlesService)
        {
            IEnumerable<TitleDTO> titles = Array.Empty<TitleDTO>();

            RuleFor(title => title.Name)
                .NotEmpty()
                .WithName(localizer["Name"])
                .MinimumLength(1)
                .Must((title, name) =>
                {
                    return titles
                        .First(value => string.Equals(value.Name, name, System.StringComparison.InvariantCultureIgnoreCase))
                        .TitleId == title.TitleId;
                })
                    .When(title =>
                    {
                        titles = titlesService.GetAllByCatalogId(title.CatalogId);

                        return titles
                            .Select(title => title.Name)
                            .Any(value => string.Equals(value, title.Name, System.StringComparison.InvariantCultureIgnoreCase));
                    }, ApplyConditionTo.CurrentValidator)
                    .WithMessage(localizer["Unique"]);

            RuleFor(title => title.Tag)
                .NotEmpty()
                .WithName(localizer["Tag"])
                .MinimumLength(2);

            RuleFor(title => title.Count)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .WithName(localizer["Count"]);
        }
    }
}
