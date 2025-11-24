namespace eCommerce.Core.Entities
{
  /// <summary>
  /// Defines the ApplicationUser entity with properties for user identification and personal details.
  /// </summary>
  public class ApplicationUser
  {
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public string? Gender { get; set; }
  }
}
