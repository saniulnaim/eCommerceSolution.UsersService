using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.DTO
{
    public record AuthenticationResponse(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success)
    {
        // We need parameterless constructor for
        // needs to have a constructor with 0 args or only optional args. Validate your configuration for details
        public AuthenticationResponse() : this(default, default, default, default, default, default)
        {
        }
    }
}
