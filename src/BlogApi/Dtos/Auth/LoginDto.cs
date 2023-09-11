using System;

namespace BlogApp_webapi.Dtos.Auth;

    public class LoginDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
    }

