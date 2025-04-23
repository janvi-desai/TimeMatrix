using System;
using TimeMatrix.Interfaces;
using TimeMatrix.Models.Dtos;
using TimeMatrix.Models.ViewModels;

namespace TimeMatrix.Services
{
    public class TimetableService : ITimetableService
    {
        public readonly IDayNameProviderService _dayNameProviderService;

        public TimetableService(IDayNameProviderService dayNameProviderService)
        {
            _dayNameProviderService = dayNameProviderService;
        }

        public TimetableViewModel GenerateTimetable(TimetableAllocation model)
        {
            try
            {
                var allSubjects = new List<string>();
                var weekDays = _dayNameProviderService?.GetDayNames(model.TimetableConfiguration.WorkingDays);

                if (model?.Subjects != null)
                {
                    foreach (var subject in model.Subjects)
                    {
                        allSubjects.AddRange(Enumerable.Repeat(subject.SubjectName, subject.Hours));
                    }
                }

                var random = new Random();
                allSubjects = allSubjects?.OrderBy(x => random.Next())
                                         ?.ToList();

                int subjectsPerDay = model?.TimetableConfiguration?.SubjectsPerDay ?? 0;
                int workingDays = model?.TimetableConfiguration?.WorkingDays ?? 0;

                var timetable = new List<List<string>>();
                timetable.Add(weekDays ?? new List<string>());


                for (int row = 1; row <= subjectsPerDay; row++)
                {
                    var rowData = new List<string>();
                    for (int col = 0; col < workingDays; col++)
                    {
                        if (allSubjects?.Count > 0)
                        {
                            rowData?.Add(allSubjects[0]);
                            allSubjects?.RemoveAt(0);
                        }
                    }
                    if(rowData!=null)
                        timetable?.Add(rowData);
                }

                return new TimetableViewModel { Timetable = timetable };
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}