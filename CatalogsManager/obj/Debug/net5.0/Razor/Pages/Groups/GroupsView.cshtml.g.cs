#pragma checksum "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e56051d8912e196a3b2e4cf21465ca02d2ae6ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(CatalogManager.Pages.Groups.Pages_Groups_GroupsView), @"mvc.1.0.razor-page", @"/Pages/Groups/GroupsView.cshtml")]
namespace CatalogManager.Pages.Groups
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\_ViewImports.cshtml"
using CatalogManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\_ViewImports.cshtml"
using CatalogManager.Localization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e56051d8912e196a3b2e4cf21465ca02d2ae6ed", @"/Pages/Groups/GroupsView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ac33b83988febb7a67a09a3d6a9995a8342e82b5", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Groups_GroupsView : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Titles/TitleEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info cmn-btn-bottom_button cmn-item-bottom_item"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Titles/TitleCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
   
    var routeAllCatalogData = new Dictionary<string, string>()
    {
        ["CatalogId"] = Model.Catalog.CatalogId.ToString(),
        ["Kind"] = Model.Catalog.Kind,
    };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 13 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
Write(Localizer["PageDescription"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 13 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
                             Write(Model.Catalog.Kind);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<ul class=\"cmn-list-style\">\r\n");
#nullable restore
#line 15 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
     foreach (var titlesGroup in Model.TitlesGroups)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li style=\"list-style:none\">\r\n            <p class=\"cmn-item-discription-list\">");
#nullable restore
#line 18 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
                                            Write(titlesGroup.LexicographicalSign);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n");
#nullable restore
#line 20 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
             foreach (var title in titlesGroup.Titles)
            {
                var routeAllData = new Dictionary<string, string>()
                {
                    ["CatalogId"] = Model.Catalog.CatalogId.ToString(),
                    ["Kind"] = Model.Catalog.Kind,
                    ["TitleId"] = title.TitleId.ToString(),
                    ["Name"] = title.Name,
                    ["Tag"] = title.Tag,
                    ["Count"] = title.Count.ToString(),
                };


#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"d-flex justify-content-between list-group-item list-group-centre\">\r\n                    <div class=\"cmn-text-style_list-parent\">\r\n                        <p class=\"cmn-text-style-list-inner\">");
#nullable restore
#line 34 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
                                                         Write($"{title.Name} - {title.Tag}({title.Count})");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                   \r\n                    <div class=\"cmn-link-style-list-parent\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e56051d8912e196a3b2e4cf21465ca02d2ae6ed7864", async() => {
#nullable restore
#line 38 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
                                                                                                           Write(Localizer["Edit"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 38 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues = routeAllData;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-all-route-data", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 41 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </li>\r\n");
#nullable restore
#line 43 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e56051d8912e196a3b2e4cf21465ca02d2ae6ed10415", async() => {
#nullable restore
#line 47 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
                                                                       Write(Localizer["Add"]);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 47 "E:\My projects\VisualStudio\InProgress\CatalogsManager\CatalogsManager\Pages\Groups\GroupsView.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues = routeAllCatalogData;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-all-route-data", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IViewLocalizer Localizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CatalogManager.Pages.Groups.GroupsView> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CatalogManager.Pages.Groups.GroupsView> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<CatalogManager.Pages.Groups.GroupsView>)PageContext?.ViewData;
        public CatalogManager.Pages.Groups.GroupsView Model => ViewData.Model;
    }
}
#pragma warning restore 1591
