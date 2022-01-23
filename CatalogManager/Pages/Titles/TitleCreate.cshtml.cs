using System;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.ParametrObjects.Commands.Titles;
using BusinessLogic.Services.Commands;
using CatalogsManager.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogsManager.Pages.Titles
{
    [Authorize("AllowedEditCatalogs")]
    public class TitleCreateModel : PageModel
    {
        [BindProperty]
        public TitleViewModel Title { get; set; } = new TitleViewModel();

        [BindProperty(SupportsGet = true)]
        public CatalogViewModel Catalog { get; set; }

        private readonly ICommandHandler<CreateTitleCommand> _service;
        private readonly IMapper _mapper;

        public TitleCreateModel(ICommandHandler<CreateTitleCommand> service, IMapper mapper)
        {
            _service = service ??
                throw new ArgumentNullException(nameof(service));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IActionResult OnPostUpdate()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mappedTitle = _mapper.Map<TitleDTO>(Title);
            var command = new CreateTitleCommand() { Title = mappedTitle };

            _service.Execute(command);

            return RedirectToPage("/Groups/GroupsView", new 
            {
                catalogId = Catalog.CatalogId,
                kind = Catalog.Kind
            });
        }
    }
}
