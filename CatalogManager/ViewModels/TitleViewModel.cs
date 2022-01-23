using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Requests.Titles;
using BusinessLogic.Services.Requests;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogsManager.ViewModels
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
        public TitleViewModelValidator(IStringLocalizer<TitleViewModel> localizer, 
            IRequestHandler<GetAllTitlesByCatalogIdRequest, IEnumerable<TitleDTO>> service)
        {
            RuleFor(title => title.Name)
                .NotEmpty()
                .WithName(localizer["Name"])
                .MinimumLength(1)
                .Must((title, name) =>
                {
                    var request = new GetAllTitlesByCatalogIdRequest() { Id = title.CatalogId };

                    return service.Execute(request)
                        .First(value => string.Equals(value.Name, name, StringComparison.InvariantCultureIgnoreCase))
                        .TitleId == title.TitleId;
                })
                    .When(title =>
                    {
                        var request = new GetAllTitlesByCatalogIdRequest() { Id = title.CatalogId };

                        return service.Execute(request)
                            .Select(title => title.Name)
                            .Any(value => string.Equals(value, title.Name, StringComparison.InvariantCultureIgnoreCase));
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
