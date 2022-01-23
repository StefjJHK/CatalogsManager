using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DTO
{
    public class Title
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TitleId { get; set; }
        public int CatalogId { get; set; }
        
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Count { get; set; }

        public virtual Catalog Catalog { get; set; }
    }
}
