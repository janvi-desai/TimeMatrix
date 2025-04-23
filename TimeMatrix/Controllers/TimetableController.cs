using Microsoft.AspNetCore.Mvc;
using TimeMatrix.Interfaces;
using TimeMatrix.Models.Dtos;

namespace TimeMatrix.Controllers
{
    public class TimetableController : Controller
    {
        private readonly ITimetableService _timetableService;
        public static TimetableAllocation? CachedModel;

        public TimetableController(ITimetableService timetableService)
        {
            _timetableService = timetableService;
        }

        [HttpGet]
        public IActionResult TimetableConfiguration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimetableConfiguration(TimetableConfiguration model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int totalHours = model.WorkingDays * model.SubjectsPerDay;

            CachedModel = new TimetableAllocation
            {
                TotalHours = totalHours,
                Subjects = Enumerable.Range(1, model.TotalSubjects)
                                     .Select(i => new SubjectHourAllocation { SubjectName = $"Subject {i}" })
                                     .ToList(),
                TimetableConfiguration = model
            };

            return RedirectToAction("SubjectHourAllocation");
        }

        [HttpGet]
        public IActionResult SubjectHourAllocation()
        {
            if (CachedModel == null)
                return RedirectToAction("TimetableConfiguration");

            return View(CachedModel);
        }

        [HttpPost]
        public IActionResult SubjectHourAllocation(TimetableAllocation model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                int subjectHours = model.Subjects.Sum(s => s.Hours);
                if (subjectHours != model.TotalHours)
                {
                    ModelState.AddModelError("", $"Please ensure the total hours you assign ({subjectHours}) adds up to exactly {model.TotalHours}.");
                    return View(model);
                }

                var timetable = _timetableService.GenerateTimetable(model);

                return View("FinalTimetable", timetable);
            }
            catch (Exception exception)
            {
                return RedirectToAction("error", "Home");
            }
        }
    }
}
