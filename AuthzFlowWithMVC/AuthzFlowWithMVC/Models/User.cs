﻿namespace AuthzFlowWithMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; } //123456 --> BCrypt algoritması.... Y&!werp(
        public string Email { get; set; }
        public string Role { get; set; }


    }
}
