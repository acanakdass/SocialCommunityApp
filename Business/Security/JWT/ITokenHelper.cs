using Domain.Entities;
using System.Collections.Generic;

namespace Business.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
