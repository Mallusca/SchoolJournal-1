namespace SchoolJournal.DAL.Interfaces
{
    using SchoolJournal.Domain;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IColumnMarksRepository
    {
        Task<bool> AddMarks(long columnId, IEnumerable<StudentMarkModel> marks);

        Task<bool> DeleteAllMarks();
    }
}
