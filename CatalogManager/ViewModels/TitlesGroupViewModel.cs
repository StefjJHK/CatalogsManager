using System.Collections.Generic;

namespace CatalogsManager.ViewModels
{
    public class TitlesGroupViewModel
    {
        public string LexicographicalSign { get; set; }
        public IEnumerable<TitleViewModel> Titles { get; set; }
    }
}
