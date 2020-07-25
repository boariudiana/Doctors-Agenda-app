using DoctorsAgenda.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAgenda.Models
{
    public class Patient
    {
        [Required]
        public int PatientId { get; set; }
        [Required]
        [Display( Name ="Patient's name")]
        public string PatientName { get; set; }
        [Display(Name = "Medical status")]
        public string MedicalStatus { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
        [NotMapped]
        public Appointment Appointment { get; set; }
        //nav properties
        [Required]
        [Display(Name = "Agendas's name")]
        public string AgendasName{ get; set; }
        [NotMapped]
        public Agenda Agenda { get; set; }

    }
}
