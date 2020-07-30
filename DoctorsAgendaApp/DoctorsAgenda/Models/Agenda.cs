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
        [StringLength(maximumLength: 100)]
        public string DoctorsName { get; set; }
        [NotMapped]
        public List<Patient> Patients { get; set; }
        [NotMapped]
        public Calendar Calendar { get; set; }


        //navigation properties
        [Required]
        [NotNull]
        public string UserName { get; set; }
        [NotMapped]
        public DoctorsAgendaUser User { get; set; }
    }
}
