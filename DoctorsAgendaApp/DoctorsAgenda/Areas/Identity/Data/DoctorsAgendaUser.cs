using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using DoctorsAgenda.Models;
using Microsoft.AspNetCore.Identity;

namespace DoctorsAgenda.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DoctorsAgendaUser class
    public class DoctorsAgendaUser : IdentityUser
    {
        [Required]
        [NotNull]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public override string Email { get => base.Email; set => base.Email = value; }
        [Required]
        [NotNull]
        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        [Display(Name ="Phone Number")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }
        [Required]
        [NotNull]
        public override string UserName { get => base.UserName; set => base.UserName = value; }

        [NotMapped]
        public Agenda Agenda { get; set; }
    }
}
