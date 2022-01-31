﻿using TutorWebApi.Domain.Common;

namespace TutorWebApi.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Profile Profile { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}