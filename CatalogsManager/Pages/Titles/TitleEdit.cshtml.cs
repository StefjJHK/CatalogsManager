using System;
using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Services.Abstractions.Commands;
using CatalogManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogManager.Pages.Titles
{
    public class TitleEditModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public TitleViewModel Title { get; set; }
        [BindProperty(SupportsGet=true)]
        public CatalogViewModel Catalog { get; set; }

        private readonly ITitlesCommandsService _titlesCommandsService;
        private readonly IMapper _mapper;

        public TitleEditModel(ITitlesCommandsService titlesCommandsService, IMapper mapper)
        {
            _titlesCommandsService = titlesCommandsService ??
                throw new ArgumentNullException(nameof(titlesCommandsService));
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
            _titlesCommandsService.Update(mappedTitle);

            return RedirectToPage("/Groups/GroupsView", new
            {
                catalogId = Catalog.CatalogId,
                kind = Catalog.Kind
            });
        }

        public IActionResult OnPostDelete()
        {
            _titlesCommandsService.DeleteById(Title.TitleId);

            return RedirectToPage("/Groups/GroupsView", new
            {
                catalogId = Catalog.CatalogId,
                kind = Catalog.Kind
            });
        }
    }
}
