using DoctorsAgenda.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAgenda.Models
{
    public class Agenda
    {
      
        [Key]
        [Required]
        [NotNull]
        [Display(Name = "Doctor's name")]
        [StringLength(100, MinimumLength = 3)]
        public string DoctorName { get; set; }
        [NotMapped]
        public List<Patient> Patients { get; set; }
        [NotMapped]
        public Calendar Calendar { get; set; }


        //navigation properties
        [Required]
        [NotNull]
        //[DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string EmailRef { get; set; }
        [NotMapped]
        public DoctorsAgendaUser User { get; set; }
    }
}
