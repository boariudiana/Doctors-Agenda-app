using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAgenda.Models
{
    public class Appointment
    {
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        [Display(Name = "Start")]
        public DateTime StartDateTime { get; set; } = DateTime.Now ;
        [Required]
        [Display(Name = "End")]
        public DateTime EndDateTime { get; set; } = DateTime.Now.AddMinutes(15);
        [Display(Name = "Type of service")]
        public string TypeOfService { get; set; }
        // nav prop  
        [Required]
        [Display(Name = "Patient")]
        public string PatientName { get; set; }
        [NotMapped]
        public Patient Patient { get; set; }
        [Required]
        [Display(Name = "Calendar's name")]
        public string CalendarsName { get; set; }
        public Calendar Calendar { get; set; }

    }
}
