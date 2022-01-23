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
    public class TitleEditModel : PageModel
    {
        [BindProperty(SupportsGet=true)]
        public TitleViewModel Title { get; set; }

        [BindProperty(SupportsGet=true)]
        public CatalogViewModel Catalog { get; set; }

        private readonly ICommandHandler<UpdateTitleCommand> _updateService;
        private readonly ICommandHandler<DeleteTitleByIdCommand> _deleteService;
        private readonly IMapper _mapper;

        public TitleEditModel(
            ICommandHandler<UpdateTitleCommand> updateService,
            ICommandHandler<DeleteTitleByIdCommand> deleteService,
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

            var mappedTitle = _mapper.Map<TitleDTO>(Title);
            var command = new UpdateTitleCommand() { Title = mappedTitle };

            _updateService.Execute(command);

            return RedirectToPage("/Groups/GroupsView", new
            {
                catalogId = Catalog.CatalogId,
                kind = Catalog.Kind
            });
        }

        public IActionResult OnPostDelete()
        {
            var command = new DeleteTitleByIdCommand() { Id = Title.TitleId };

            _deleteService.Execute(command);

            return RedirectToPage("/Groups/GroupsView", new
            {
                catalogId = Catalog.CatalogId,
                kind = Catalog.Kind
            });
        }
    }
}
