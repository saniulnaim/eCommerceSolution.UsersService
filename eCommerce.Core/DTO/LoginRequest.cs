using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.DTO
{
    public record LoginRequest(
        string? Email,
        string? Password
        );
}
