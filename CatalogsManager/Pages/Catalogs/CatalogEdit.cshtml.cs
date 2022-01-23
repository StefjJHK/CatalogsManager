using System;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Services.Abstractions.Commands;
using CatalogManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogManager.Pages.Catalogs
{
    public class CatalogEditModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public CatalogViewModel Catalog { get; set; }

        private readonly ICatalogsCommandsService _catalogsCommandsService;
        private readonly IMapper _mapper;

        public CatalogEditModel(ICatalogsCommandsService catalogsCommandsService, IMapper mapper)
        {
            _catalogsCommandsService = catalogsCommandsService ??
                throw new ArgumentNullException(nameof(catalogsCommandsService));
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

            _catalogsCommandsService.Update(mappedCatalog);
            return RedirectToPage(nameof(CatalogsView));
        }

        public IActionResult OnPostDelete()
        {
            _catalogsCommandsService.DeleteById(Catalog.CatalogId);
            return RedirectToPage(nameof(CatalogsView));
        }
    }
}
