namespace SchoolJournal.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Newtonsoft.Json;
    using SchoolJournal.BLL.Interfaces;
    using SchoolJournal.ViewModels;

    public class SchoolController : Controller
    {
        private readonly IStudentsService _studentsService;

        private readonly IJournalGridColumnsService _journalGridColumnService;

        public SchoolController(IStudentsService studentsService, IJournalGridColumnsService journalGridColumnService)
        {
            _studentsService = studentsService;

            _journalGridColumnService = journalGridColumnService;
        }

        [HttpGet]
        public ActionResult JournalPage()
        {
            List<JournalGridStudentViewModel> studentsForJournalGrid = _studentsService.GetStudentsForJournalGrid();
            List<JournalGridColumnViewModel> journalGridColumns = _journalGridColumnService.GetJournalGridColumns();

            JournalGridPageViewModel journalGridPageViewModel = new JournalGridPageViewModel(studentsForJournalGrid, journalGridColumns);

            return View(journalGridPageViewModel);
        }



        [HttpPost]
        public ActionResult CreateColumn(IEnumerable<StudentMarkViewModel> marks)
        {
            //add create column in database
             return Json(marks.Count() > 0);
        }

    }
}