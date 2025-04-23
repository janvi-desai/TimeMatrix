using TimeMatrix.Models.Dtos;
using TimeMatrix.Models.ViewModels;

namespace TimeMatrix.Interfaces
{
    public interface ITimetableService
    {
        TimetableViewModel GenerateTimetable(TimetableAllocation model);
    }
}