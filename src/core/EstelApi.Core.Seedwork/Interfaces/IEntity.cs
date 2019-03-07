namespace EstelApi.Core.Seedwork.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}