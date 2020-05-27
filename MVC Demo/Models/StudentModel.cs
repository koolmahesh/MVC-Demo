using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Demo.Models
{
    public class StudentModel
    {   
        public int StudentId { get; set; }

        [Display(Name="First Name")]    
        [Required(ErrorMessage ="Please Fill First Name")]
        public string FirstName { get; set; }

        [Display(Name="Middle Name")]
        [Required(ErrorMessage = "Please Fill Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name ="Last Name")]
        [Required(ErrorMessage = "Please Fill Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please Fill Middle Name")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public bool IsActive { get; set; }
        [Display(Name = "Email Id")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Required(ErrorMessage = "Enter your Email")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Fill Password")]
        public string Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please Fill Confirm Password")]
        [CompareAttribute("Password",ErrorMessage ="Password Not Matched")]
        public string CPassword { get; set; }

    }
}