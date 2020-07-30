using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAgenda.Models
{
    public class Appointment
    {
        [Required]
        [NotNull]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

        [Required]
        [NotNull]
        [Display(Name = "Start")]
        public DateTime StartDateTime { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "End")]
        [NotNull]
        public DateTime EndDateTime { get; set; }

        [Display(Name = "Type of service")]
        public string TypeOfService { get; set; }

        // navigation properties 
        [Required]
        [Display(Name = "Patient")]
        [NotNull]
        public string PatientName { get; set; }
        [NotMapped]
        public Patient Patient { get; set; }

        [Required]
        [NotNull]
        [Display(Name = "Doctor's name")]
        [StringLength(maximumLength: 100)]
        public string DoctorsName { get; set; }
        [NotMapped]
        public Calendar Calendar { get; set; }
    }
}
