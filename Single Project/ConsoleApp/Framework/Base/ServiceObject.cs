namespace Gamer.Framework.Base;

public abstract class ServiceObject<T> where T : class
{
    public int Id { get; init; }
    public Guid InstanceId { get; } = Guid.NewGuid();
    public DateTime CreatedOn { get; } = DateTime.Now;
}