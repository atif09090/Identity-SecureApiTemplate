﻿namespace Identity_SecureApiTemplate.Models
{
    public class RegisterRequest
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Role { get; set; } = "User"; // Default to "User"
    }

}
