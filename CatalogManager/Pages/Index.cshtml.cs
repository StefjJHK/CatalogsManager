using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;

namespace CatalogsManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return RedirectToPage("/Catalogs/CatalogsView");
        }

        public IActionResult OnPostChangeLocalization(string culture, string returnUrl)
        {
            var requestCulture = new RequestCulture(culture);
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(30)
            };

            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(requestCulture),
                cookieOptions);

            return LocalRedirect(returnUrl);
        }
    }
}
