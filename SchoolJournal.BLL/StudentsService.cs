namespace SchoolJournal.BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using SchoolJournal.ViewModels;
    using DAL.Interfaces;
    using Mapster;
    using SchoolJournal.Domain;

    public class StudentsService : IStudentsService
    {

        private readonly IStudentsRepository _studentsRepository;

        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public List<JournalGridStudentViewModel> GetStudentsForJournalGrid()
        {
            return _studentsRepository
                .GetStudentsForJournalGrid()
                .ToList()
                .Adapt<List<JournalGridStudentViewModel>>();
        }

        public async Task<bool> AddStudent(string studentFirstName, string studentLastName)
        {
           return await _studentsRepository.AddStudent(studentFirstName, studentLastName); 
        }


        public async Task<bool> DeleteChosenStudent(long studentId)
        {
            return await _studentsRepository.DeleteChosenStudent(studentId);
        }
    }
}
