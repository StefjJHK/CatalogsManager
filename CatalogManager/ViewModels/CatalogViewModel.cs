using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Requests.Catalogs;
using BusinessLogic.Services.Requests;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace CatalogsManager.ViewModels
{
    public class CatalogViewModel
    {
        public int CatalogId { get; set; }
        public string Kind { get; set; }
    }

    public class CatalogViewModelValidator : AbstractValidator<CatalogViewModel>
    {
        public CatalogViewModelValidator(IStringLocalizer<CatalogViewModel> localizer, 
            IRequestHandler<GetCatalogByKindRequest, CatalogDTO> service)
        {
            RuleFor(catalog => catalog.Kind)
               .NotEmpty()
               .WithName(localizer["CatalogType"])
               .MinimumLength(3)
               .Must((catalog, kind) => IsCatalogsWithTheSameKindHasDifferentId(service, catalog))
                   .When(catalog => !IsCatalogKindUnqiue(service, catalog.Kind), ApplyConditionTo.CurrentValidator)
                   .WithMessage(localizer["KindNotUnique"]);
        }

        private bool IsCatalogKindUnqiue(IRequestHandler<GetCatalogByKindRequest, CatalogDTO> service, string value)
        {
            var request = new GetCatalogByKindRequest() { Kind = value };

            return service.Execute(request) == null;
        }

        private bool IsCatalogsWithTheSameKindHasDifferentId(IRequestHandler<GetCatalogByKindRequest, CatalogDTO> service, CatalogViewModel catalog)
        {
            var request = new GetCatalogByKindRequest() { Kind = catalog.Kind };
            var catalogDTO = service.Execute(request);

            return catalogDTO.CatalogId == catalog.CatalogId;
        }
    }
}
