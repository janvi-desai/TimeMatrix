using System.ComponentModel.DataAnnotations;

namespace TimeMatrix.Models.Dtos
{
    public class SubjectHourAllocation
    {
        [Required]
        [Display(Name = "Subject Name")]
        public string SubjectName { get; set; } = string.Empty; 

        [Required]
        [Range(1, int.MaxValue)]
        [Display(Name = "Assign Hours")]
        public int Hours { get; set; }
    }
}