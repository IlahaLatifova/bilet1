﻿using Microsoft.AspNetCore.Identity;

namespace Bilet1.Models
{
    public class AppUser:IdentityUser
    {
        public string FullName { get; set; }
    }
}
