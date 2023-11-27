using Microsoft.Extensions.Logging;

namespace Gamer.Framework;

public class ServiceObject<T> where T : class
{

  public Guid InstanceId { get; } = Guid.NewGuid();
  public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;

  // ReSharper disable once InconsistentNaming
  protected internal ILogger logger { get; init; }

  public ServiceObject(ILogger logger)
  {
    this.logger = logger;
  }

}