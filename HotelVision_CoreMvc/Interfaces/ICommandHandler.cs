namespace HotelVision_CoreMvc.Services.Interfaces
{
    public interface ICommandHandler<out TReturn>
    {
        TReturn Handle();
    }
}
