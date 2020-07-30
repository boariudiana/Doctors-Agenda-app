using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAgenda.Models
{
    public class Patient
    {
        [Key]
        [Required]
        [NotNull]
        [Display (Name ="Patient's name")]
        [StringLength(maximumLength: 100)]
        public string PatientsName { get; set; }

        [Required]
        [NotNull]
        [Display(Name = "Phone number")]
        [StringLength(maximumLength: 50)]
        public string PhoneNumber { get; set; }

        [Display(Name = "Medical status")]
        public string MedicalStatus { get; set; }
        [NotMapped]
        public List<Appointment> Appointments { get; set; }

        //navigation properties
        [Required]
        [NotNull]
        [Display(Name = "Doctor's name")]
        [StringLength(maximumLength: 100)]
        public string DoctorsName { get; set; }
        [NotMapped]
        public Agenda Agenda { get; set; }


    }
}
