﻿namespace Study.TFA.Domain.Authentication
{
    public class RecognisedUser
    {
        public Guid UserId { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
    }
}