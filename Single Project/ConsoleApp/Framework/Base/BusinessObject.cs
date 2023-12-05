namespace Gamer.Framework.Base;

public abstract class BusinessObject
{
    public int Id { get; init; }

    public Guid InstanceId { get; } = Guid.NewGuid();
    public DateTime Timestamp { get; } = DateTime.Now;
}