using APE.Core.Implementation;
using System;
using System.Collections.Generic;

namespace APE.Core.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Username { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        bool IsEmailConfirmed { get; set; }
        string Phone {  get; set; }
        bool IsPhoneConfirmed { get; set; }
        DateTime DateCreatedOn { get; set; }
        DateTime DateUpdatedOn { get; set; }
        DateTime DateLastLoginOn { get; set; }
    }
}
