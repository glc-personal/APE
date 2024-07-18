﻿using APE.Core.Interfaces;

namespace APE.Core.Implementations
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
