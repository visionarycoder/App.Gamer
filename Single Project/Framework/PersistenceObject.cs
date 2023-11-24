namespace Gamer.Framework;

public class PersistenceObject
{

	public int Id { get; set; }
	public Guid Uuid { get; set; }
	public Guid InstanceId { get; set; } = Guid.NewGuid();

	public string CreatedBy { get; set; } = $"{Environment.UserDomainName}\\{Environment.UserName}";
	public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
	
	public string UpdatedBy { get; set; } = $"{Environment.UserDomainName}\\{Environment.UserName}";
	public DateTime UpdatedOnUtc { get; set; } = DateTime.UtcNow;

}