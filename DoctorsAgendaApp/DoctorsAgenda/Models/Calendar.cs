using DoctorsAgenda.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsAgenda.Models
{
    public class Calendar
    {
        [Required]
        public int CalendarId { get; set; }
        [Required]
        [Display(Name = "Calendar's name")]
        public string CalendarsName { get; set; }
        public List<Appointment> Appointments { get; set; }
        //navigation properties
        [Required]
        [Display(Name = "Agendas's name")]
        public string AgendasName { get; set; }
        public Agenda Agenda { get; set; }
    }
}
