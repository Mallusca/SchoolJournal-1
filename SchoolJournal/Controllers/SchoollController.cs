﻿namespace SchoolJournal.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using SchoolJournal.BLL.Interfaces;
    using SchoolJournal.Domain;
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

        [Authorize]
        [HttpGet]
        public ActionResult JournalPage()
        {
            List<JournalGridStudentViewModel> studentsForJournalGrid = _studentsService.GetStudentsForJournalGrid();
            List<JournalGridColumnViewModel> journalGridColumns = _journalGridColumnService.GetJournalGridColumns();

            JournalGridPageViewModel journalGridPageViewModel = new JournalGridPageViewModel(studentsForJournalGrid, journalGridColumns);

            return View(journalGridPageViewModel);
        }


        [Authorize(Roles ="admin")]
        [HttpPost]
        public async Task<ActionResult> CreateColumn(IEnumerable<StudentMarkViewModel> marks, DateTime inputValue)
        {

            bool response = await _journalGridColumnService.AddJournalGridLessonColumn(marks, inputValue);

            return Json(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> DeleteColumnAndMarks()
        {
            var result = await _journalGridColumnService.DeleteJournalGridLessonColumnsAndMarks();
            return Json(result);

        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> CreateStudent(string studentFirstName, string studentLastName)
        {
            var result = await _studentsService.AddStudent(studentFirstName, studentLastName);
            return Json(result);
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> DeleteChosenStudent(long studentId)
        {
            var result = await _studentsService.DeleteChosenStudent(studentId);
            return Json(result);
        }

        [Authorize]
        public ActionResult Partial()
        {
            List<JournalGridStudentViewModel> studentsForJournalGrid = _studentsService.GetStudentsForJournalGrid();
            List<JournalGridColumnViewModel> journalGridColumns = _journalGridColumnService.GetJournalGridColumns();

            JournalGridPageViewModel journalGridPageViewModel = new JournalGridPageViewModel(studentsForJournalGrid, journalGridColumns);

            return PartialView(journalGridPageViewModel);
          
        }

        [Authorize]
        [Route("School/student/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var stud = _studentsService.StudentDetails(id);
            return View(stud);
        }

        // Parent(1) - (M)Student

    }
}



