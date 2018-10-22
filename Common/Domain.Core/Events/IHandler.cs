namespace Common.Domain.Core.Events
{
    public interface IHandler<in T> where T : Message 
    {
        void Hander(T message);
    }
}
