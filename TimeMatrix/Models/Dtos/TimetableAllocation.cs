namespace TimeMatrix.Models.Dtos
{
    public class TimetableAllocation
    {
        public int TotalHours { get; set; }
        public List<SubjectHourAllocation> Subjects { get; set; } = new List<SubjectHourAllocation>();  
        public TimetableConfiguration TimetableConfiguration { get; set; } = new TimetableConfiguration();
    }
}