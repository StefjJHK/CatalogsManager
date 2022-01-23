using System;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Commands.Catalogs;
using BusinessLogic.Services.Commands;
using CatalogsManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogsManager.Pages.Catalogs
{
    [Authorize("AllowedEditCatalogs")]
    public class CatalogEditModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public CatalogViewModel Catalog { get; set; }

        private readonly ICommandHandler<UpdateCatalogCommand> _updateService;
        private readonly ICommandHandler<DeleteCatalogByIdCommand> _deleteService;

        private readonly IMapper _mapper;

        public CatalogEditModel(
            ICommandHandler<UpdateCatalogCommand> updateService,
            ICommandHandler<DeleteCatalogByIdCommand> deleteService,
            IMapper mapper)
        {
            _updateService = updateService ??
                throw new ArgumentNullException(nameof(updateService));
            _deleteService = deleteService ??
                throw new ArgumentNullException(nameof(deleteService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mappedCatalog = _mapper.Map<CatalogDTO>(Catalog);
            var command = new UpdateCatalogCommand() { Catalog = mappedCatalog };

            _updateService.Execute(command);

            return RedirectToPage(nameof(CatalogsView));
        }

        public IActionResult OnPostDelete()
        {
            var command = new DeleteCatalogByIdCommand() { Id = Catalog.CatalogId };

            _deleteService.Execute(command);

            return RedirectToPage(nameof(CatalogsView));
        }
    }
}
