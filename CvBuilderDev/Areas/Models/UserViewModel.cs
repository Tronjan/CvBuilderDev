using System;
using System.ComponentModel.DataAnnotations;
using CvBuilderDev.Utils;

namespace CvBuilderDev.Areas.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }


    public class ResponseViewModel
    {
        public int Response { get; set; }

        public int UserId { get; set; }

        public string Email { get; set; }

        public string Jwt { get; set; }  
    }

}

