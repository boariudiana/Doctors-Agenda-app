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

        [Required]
        [NotNull]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PatientId { get; set; }

        [Required]
        [NotNull]
        [Display(Name = "Patient's name")]
        [StringLength(100, MinimumLength = 3)]
        public string PatientName { get; set; }

        [NotNull]
        [Required(ErrorMessage = "Mobile no. is required")]
        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Medical status")]
        public string MedicalStatus { get; set; }

        //navigation properties
        [Required]
        [NotNull]
        [Display(Name = "Doctor's name")]
        [StringLength(100, MinimumLength = 3)]
        public string DoctorNameRef { get; set; }
        [NotMapped]
        public Agenda Agenda { get; set; }

    }
}
