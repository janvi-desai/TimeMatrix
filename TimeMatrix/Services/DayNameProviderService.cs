using TimeMatrix.Interfaces;

namespace TimeMatrix.Services
{
    public class DayNameProviderService : IDayNameProviderService
    {
        public List<string> GetDayNames(int count)
        {
            string[] weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            return weekDays.Take(count).ToList();
        }
    }
}
