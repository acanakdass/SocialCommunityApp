using Core.Domain.Concrete;
using System;

namespace Domain.Entities
{
    public class OperationClaim : Entity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}