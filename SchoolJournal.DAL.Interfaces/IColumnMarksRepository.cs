namespace SchoolJournal.DAL.Interfaces
{
    using SchoolJournal.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public interface IColumnMarksRepository
    {
        bool AddMarks(long columnId, IEnumerable<StudentMarkModel> marks);
    }
}
