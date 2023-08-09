﻿using System.ComponentModel.DataAnnotations;

namespace SoccerClub.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword{ get; set; }
       
    }
}
