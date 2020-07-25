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
        [Required]
        [NotNull]
        public int AgendaId { get; set; }
        public string AgendasName { get; set; }
        [Required]
        public Calendar Calendar { get; set; }
        [Required]
        public List<Patient> Patients { get; set; }

        //nav properties
        [Required]
        [NotNull]
        public string UserId { get; set; }
        [NotMapped]
        public DoctorsAgendaUser User { get; set; }


    }
}
