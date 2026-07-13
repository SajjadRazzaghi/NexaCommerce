using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexaCommerce.Modules.Identity.Domain.Entities
{
    public sealed record LoginTokens(
    string AccessToken,
    string RefreshToken,
    DateTime ExpiresOnUtc);
}
