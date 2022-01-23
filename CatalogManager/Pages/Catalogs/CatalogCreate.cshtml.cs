using System;
using System.ComponentModel.DataAnnotations;
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
    public class CatalogCreateModel : PageModel
    {
        [Required]
        [BindProperty]
        public CatalogViewModel Catalog { get; set; }

        private readonly ICommandHandler<CreateCatalogCommand> _service;
        private readonly IMapper _mapper;

        public CatalogCreateModel(ICommandHandler<CreateCatalogCommand> service, IMapper mapper)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
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
            var command = new CreateCatalogCommand() { Catalog = mappedCatalog };

            _service.Execute(command);

            return RedirectToPage("CatalogsView");
        }
    }
}
