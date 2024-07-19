using System;
using System.ComponentModel.DataAnnotations;

namespace APE.DataAccess.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        [Required]
        public DateTime DateCreatedOn { get; set; }
        public DateTime DateUpdatedOn { get; set; }
        public DateTime DateLastLoginOn { get; set; }
    }
}
