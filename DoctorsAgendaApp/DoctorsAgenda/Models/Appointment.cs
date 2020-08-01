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
        [Display(Name = "Patient's name")]
        [StringLength(100, MinimumLength = 3)]
        public string PatientName { get; set; }

        [Required]
        [NotNull]
        [Display(Name = "Start")]
        public DateTime StartDateTime { get; set; } = DateTime.Now;

        [Required(ErrorMessage =" Add minutes ")]
        [NotNull]
        public double Minutes { get; set; }

        [Required]
        [NotNull]
        [NotMapped]
        public DateTime EndDateTime
        {
            get { return EndDateTime; }

            private set
            {
                if (Minutes < 0)
                {
                    throw new Exception("Minutes must have positive value");
                }
                this.EndDateTime = StartDateTime.AddMinutes(Minutes);
            }
        }

        [Display(Name = "Type of service")]
        public string TypeOfService { get; set; }

        // navigation properties 

        [Required]
        [NotNull]
        [Display(Name = "Doctor's name")]
        [StringLength(100, MinimumLength = 3)]
        public string CalendarNameRef { get; set; }
        [NotMapped]
        public Calendar Calendar { get; set; }
    }
}
