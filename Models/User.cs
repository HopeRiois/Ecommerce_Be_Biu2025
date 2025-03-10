﻿namespace ecommerce_biu.Models
{
    internal class User
    {
        public required long Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Password { get; set; }
        public required DateTime BornDate { get; set; }
        public string? Address { get; set; }
        public required Role Rol { get; set; }
    }
}
