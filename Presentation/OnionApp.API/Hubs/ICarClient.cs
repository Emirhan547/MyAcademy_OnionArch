namespace OnionApp.API.Hubs
{
    public interface ICarClient
    {
        Task ReceiveCarCount(int count);
    }
}
