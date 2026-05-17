using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.DTO
{
    public record UserDTO(Guid UserID, string? PersonName, string? Email, string Gender);
}
