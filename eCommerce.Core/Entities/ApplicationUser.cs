namespace eCommerce.Core.Entities
{
    /// <summary>
    /// Defines the ApplicationUser entity which represents a user in the e-commerce system. This class includes properties such as UserID, PersonName, Email
    /// </summary>
    public class ApplicationUser
    {
        public Guid UserID { get; set; }
        public string PersonName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Gender { get; set; }

    }
}
