namespace BusinessLogic.Services.Requests
{
    public interface IRequestHandler<TRequest, TResponce>
    {
        TResponce Execute(TRequest request);
    }
}
