using System;
using System.ComponentModel.DataAnnotations;

namespace Models
    {
    public class User
        {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9]+$")]
        public string Username { get; set; }
        }
    }
