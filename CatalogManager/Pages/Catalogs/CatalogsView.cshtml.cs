using System;
using System.Collections.Generic;
using CatalogsManager.ViewModels;
using CatalogsManager.Presentors;
using CatalogsManager.Presentors.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CatalogsManager.Pages.Catalogs
{
    public class CatalogsView : PageModel
    {
        public IEnumerable<CatalogViewModel> Catalogs { get; private set; }

        private readonly IPresentor<IEnumerable<CatalogViewModel>, GetAllCatalogs> _presentor;

        public CatalogsView(IPresentor<IEnumerable<CatalogViewModel>, GetAllCatalogs> presentor)
        {
            _presentor = presentor ??
                throw new ArgumentNullException(nameof(presentor));
        }

        public IActionResult OnGet()
        {
            var request = new GetAllCatalogs();
            Catalogs = _presentor.Get(request);

            return Page();
        }
    }
}
