using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWASP_Razor_Edition.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [RegularExpression("^OTO\\d\\d\\d\\d\\d$")]
        [Display(Name = "Loaner OTO # (OTO_____)")]
        [Required]
        public string? LoanerOTO { get; set; }

        [Display(Name = "Student Name (First Last)")]
        [Required]
        public string? StudentName { get; set; }

        [Display(Name = "Date Time")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LogTime { get; set; }

        [RegularExpression("^(Repair|Charge|Forgotten|Other)$")]
        [Display(Name = "Reason (Repair, Charge, Forgotten, Other)")]
        [Required]
        public string? Reason { get; set; }
    }
}
