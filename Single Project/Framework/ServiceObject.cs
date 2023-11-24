using Microsoft.Extensions.Logging;

namespace Gamer.Framework;

public class ServiceObject<T> where T : class
{

	public Guid InstanceId { get; } = Guid.NewGuid();
  public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
	protected internal ILogger Logger { get; init; }

	public ServiceObject(ILogger logger)
	{
		Logger = logger;
	}

}