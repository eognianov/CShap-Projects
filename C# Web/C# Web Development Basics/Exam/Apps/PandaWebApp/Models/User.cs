﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PandaWebApp.Models
{
    public class User
    {
        public User()
        {
            this.Receipts = new HashSet<Receipt>();
            this.Packages = new HashSet<Package>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public UserRole Role { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

    }
}
