using Domain.Entities;
using System.Collections.Generic;

namespace Domain.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public string PhoneNumber { get; set; }
        public List<OperationClaim> Roles { get; set; }
    }
}
