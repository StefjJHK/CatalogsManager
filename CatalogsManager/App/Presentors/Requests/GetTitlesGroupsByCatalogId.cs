namespace CatalogManager.Presentors.Requests
{
    public class GetTitlesGroupsByCatalogId
    {
        public int CatalogId { get; init; }

        public GetTitlesGroupsByCatalogId(int catalogId)
        {
            CatalogId = catalogId;
        }
    }
}
