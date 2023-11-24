namespace Gamer.Framework;

public abstract class DataTransferObject
{

	public Guid InstanceId { get; } = Guid.NewGuid();
	public Guid Uuid { get; set; } = Guid.NewGuid();
	public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;

}