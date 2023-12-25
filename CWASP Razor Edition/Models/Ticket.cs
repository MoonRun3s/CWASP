using CWASP_Razor_Edition.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWASP_Razor_Edition.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [RegularExpression("^OTO\\d\\d\\d\\d\\d$", ErrorMessage = "Input must equal \"OTO#####\".")]
        [Display(Name = "OTO #")]
        [Required]
        public string? LoanerOTO { get; set; }

        [Display(Name = "Student Name")]
        [Required]
        public string? StudentName { get; set; }

        [Display(Name = "Date Time")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LogTime { get; set; }

        [RegularExpression("^(Home|Repair|Charge|Lost|Other)$", ErrorMessage = "Input must equal \"Home\", \"Repair\", \"Charge\", \"Lost\", or \"Other\".")]
        [Required]
        public string? Reason { get; set; }

        public string? Description { get; set; }
    }
}
