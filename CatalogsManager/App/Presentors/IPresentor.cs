namespace CatalogManager.Presentors
{
    public interface IPresentor<TResponce, TRequest>
    {
        TResponce Get(TRequest request);
    }
}
