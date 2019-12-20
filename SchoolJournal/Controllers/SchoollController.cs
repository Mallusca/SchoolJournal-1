namespace SchoolJournal.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
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
        public async Task<ActionResult> CreateColumn(IEnumerable<StudentMarkViewModel> marks, DateTime inputValue)
        {
<<<<<<< HEAD

            bool response = await _journalGridColumnService.AddJournalGridLessonColumn(marks, inputValue);

            return Json(response);
        }


        [HttpPost]
        public async Task<ActionResult> DeleteColumnAndMarks()
        {
            var result = await _journalGridColumnService.DeleteJournalGridLessonColumnsAndMarks();
            return Json(result);

        }


        public ActionResult Partial()
        {
            List<JournalGridStudentViewModel> studentsForJournalGrid = _studentsService.GetStudentsForJournalGrid();
            List<JournalGridColumnViewModel> journalGridColumns = _journalGridColumnService.GetJournalGridColumns();

            JournalGridPageViewModel journalGridPageViewModel = new JournalGridPageViewModel(studentsForJournalGrid, journalGridColumns);

            return PartialView(journalGridPageViewModel);
=======
            
             return Json(_journalGridColumnService.AddJournalGridLessonColumn(marks));
>>>>>>> 04518fc36e324843c29f48ee63898427baf89a7c
        }

    }
}
/*
 * убрать лишние роуты
 * 
 * добавить кнопку cancel (иконка крестик) которая отменяет создание колонки и скрывает инпуты и т.д.
 * 
 * добваить возможность выбрать дату - инпут в который вводишь дату, изначально в нём текущая дата, 
 * чтобы при добавлении колонки с указаной датой появлялась колонка с этой датой в нужном месте
 * 
 * добавить под таблицу кнопку удалить все колонки с оценками - тоже самое(в плане обновления паршиал вью на респонсе) что и добавить колонку только
 * новый роут и другое действие
 */



