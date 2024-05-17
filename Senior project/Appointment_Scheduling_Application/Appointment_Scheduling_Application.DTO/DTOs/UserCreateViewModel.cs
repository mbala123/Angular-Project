
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Appointment_Scheduling_Application.DTOs.DTOs
{
        public class UserCreateModel
        {
            public IFormFile file { get; set; }
            [Required]
            [RegularExpression(@"[A-Za-z]{5,13}", ErrorMessage = "Invalid FirstName")]
            public string FirstName { get; set; }
            [Required]
            //[RegularExpression(@"[A-Za-z]{5,13}", ErrorMessage = "Invalid LasrName")]
            public string LastName { get; set; }
            [Required]
            //[RegularExpression(@"[A-Za-z@$!%*#?&]{8,10}", ErrorMessage = "Password requirements not met")]
            public string Password { get; set; }
            [Compare("Password")]
            [Required]
            public string ConfirePassword { get; set; }
            [Required]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }
            [Required]
            [RegularExpression(@".{10,13}", ErrorMessage = "Invalid phone number")]
            public string PhoneNumber { get; set; }

    }
    public class UserViewModel
    {
        public string image { get; set; }
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
    public class UserUpdateModel
    {
        public IFormFile file { get; set; }
        public string Id { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{5,13}", ErrorMessage = "Invalid FirstName")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{5,13}", ErrorMessage = "Invalid LasrName")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required]
        [RegularExpression(@".{10,13}", ErrorMessage = "Invalid phone number")]
        public string PhoneNumber { get; set; }
    }
    


}
