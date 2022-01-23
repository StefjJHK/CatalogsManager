using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DTO
{
    public class Catalog
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatalogId { get; set; }
        public string Kind { get; set; }

        public virtual ICollection<Title> Titles { get; set; } = new HashSet<Title>();
    }
}
