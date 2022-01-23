using BusinessLogic.DTO;
using BusinessLogic.Services.Abstractions.Requests;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Linq;

namespace CatalogManager.ViewModels
{
    public class CatalogViewModel
    {
        public int CatalogId { get; set; }
        public string Kind { get; set; }
    }

    public class CatalogViewModelValidator : AbstractValidator<CatalogViewModel>
    {
        public CatalogViewModelValidator(IStringLocalizer<CatalogViewModel> localizer, ICatalogsRequestsService catalogsServices)
        {
            RuleFor(catalog => catalog.Kind)
               .NotEmpty()
               .WithName(localizer["CatalogType"])
               .MinimumLength(3)
               .Must((catalog, kind) => IsCatalogsWithTheSameKindHasDifferentId(catalogsServices, catalog))
                   .When(catalog => !IsCatalogKindUnqiue(catalogsServices, catalog.Kind), ApplyConditionTo.CurrentValidator)
                   .WithMessage(localizer["KindNotUnique"]);
        }

        private bool IsCatalogKindUnqiue(ICatalogsRequestsService catalogsServices, string value)
        {
            return catalogsServices.GetByKind(value) == null;
        }

        private bool IsCatalogsWithTheSameKindHasDifferentId(ICatalogsRequestsService catalogsServices, CatalogViewModel catalog)
        {
            var catalogDTO = catalogsServices.GetByKind(catalog.Kind);

            return catalogDTO.CatalogId == catalog.CatalogId;
        }
    }
}
