using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CatalogsManager.ViewModels;
using CatalogsManager.Presentors;
using CatalogsManager.Presentors.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogsManager.Pages.Groups
{
    public class GroupsView : PageModel
    {
        [BindProperty(SupportsGet=true), Required]
        public CatalogViewModel Catalog { get; set; }
        public IEnumerable<TitlesGroupViewModel> TitlesGroups { get; private set; }

        private readonly IPresentor<IEnumerable<TitlesGroupViewModel>, GetTitlesGroupsByCatalogId> _presentor;

        public GroupsView(IPresentor<IEnumerable<TitlesGroupViewModel>, GetTitlesGroupsByCatalogId> presentor)
        {
            _presentor = presentor ??
                throw new ArgumentNullException(nameof(presentor));
        }

        public void OnGet()
        {
            var request = new GetTitlesGroupsByCatalogId(Catalog.CatalogId);
            TitlesGroups = _presentor.Get(request);
        }
    }
}
