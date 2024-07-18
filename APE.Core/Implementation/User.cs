using APE.Core.Interfaces;
using System.ComponentModel.DataAnnotations;
using System;

namespace APE.Core.Implementation
{
    public class User : IUser
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Phone {  get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public DateTime DateCreatedOn { get; set; }
        public DateTime DateUpdatedOn { get; set; }
        public DateTime DateLastLoginOn { get; set; }
    }
}
