using System.Collections.Generic;

namespace CatalogManager.ViewModels
{
    public class TitlesGroupViewModel
    {
        public string LexicographicalSign { get; set; }
        public IEnumerable<TitleViewModel> Titles { get; set; }
    }
}
