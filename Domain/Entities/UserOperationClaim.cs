using Core.Domain.Concrete;
using System;

namespace Domain.Entities
{
    public class UserOperationClaim : Entity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public OperationClaim OperationClaim { get; set; }
    }
}