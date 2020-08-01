using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAgenda.Models
{
    public class Calendar
    {
        [Required]
        [NotNull]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CalendarId { get; set; }

        [NotMapped]
        public List<Appointment> Appointments { get; set; }

        //navigation propertie
        [Required]
        [NotNull]
        [Display(Name = "Doctor's name")]
        [StringLength(100, MinimumLength = 3)]
        public string DoctorCalendarName { get; set; }
        [NotMapped]
        public Agenda Agenda { get; set; }
    }
}
