using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Services.Abstractions.Commands;
using CatalogManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogManager.Pages.Catalogs
{
    public class CatalogCreateModel : PageModel
    {
        [Required]
        [BindProperty]
        public CatalogViewModel Catalog { get; set; }

        private readonly ICatalogsCommandsService _catalogsCommandsService;
        private readonly IMapper _mapper;

        public CatalogCreateModel(ICatalogsCommandsService catalogsCommandsService, IMapper mapper)
        {
            _catalogsCommandsService = catalogsCommandsService ??
                throw new ArgumentNullException(nameof(catalogsCommandsService));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mappedCatalog = _mapper.Map<CatalogDTO>(Catalog);
            _catalogsCommandsService.Create(mappedCatalog);

            return RedirectToPage("CatalogsView");
        }
    }
}
