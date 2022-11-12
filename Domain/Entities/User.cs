using Core.Domain.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public ICollection<Post> Posts { get; set; }
    }
}