using System.ComponentModel.DataAnnotations;

namespace TimeMatrix.Models.Dtos
{
    public class TimetableConfiguration
    {
        [Required]
        [Range(1, 7)]
        [Display(Name = "Total Working Days")]
        public int WorkingDays { get; set; }

        [Required]
        [Range(1, 8)]
        [Display(Name = "Subjects Per Day")]
        public int SubjectsPerDay { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Total Subjects")]
        public int TotalSubjects { get; set; }
    }

}