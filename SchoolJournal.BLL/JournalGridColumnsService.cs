

namespace SchoolJournal.BLL
{
    using System.Text;
    using System.Threading.Tasks;
    using Interfaces;
    using SchoolJournal.ViewModels;
    using DAL.Interfaces;
    using Mapster;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using SchoolJournal.Domain;

    public class JournalGridColumnsService : IJournalGridColumnsService
    {
        private readonly IColumnsRepository _columnsRepository;
        private readonly IColumnMarksRepository _columnMarksRepository;
        private readonly IColumnTypeRepository _columnTypeRepository;

        public JournalGridColumnsService(IColumnsRepository columnsRepository,
            IColumnTypeRepository columnTypeRepository,
            IColumnMarksRepository columnMarksRepository)
        {
            _columnsRepository = columnsRepository;
            _columnMarksRepository = columnMarksRepository;
            _columnTypeRepository = columnTypeRepository;
        }

        public List<JournalGridColumnViewModel> GetJournalGridColumns()
        {
            return _columnsRepository
                .List()
                .ToList()
                .Adapt<List<JournalGridColumnViewModel>>();
        }


        public async Task<bool> AddJournalGridLessonColumn(IEnumerable<StudentMarkViewModel> marks, DateTime inputValue)
        {
            //var currentDate = DateTime.Now;

            ColumnType columnType = await _columnTypeRepository.FindByName("LESSON");

            long columnId = await _columnsRepository.AddColumn(columnType.Id, inputValue);

            return await _columnMarksRepository.AddMarks(columnId, marks.Adapt<IEnumerable<StudentMarkModel>>());

        }

        public async Task<bool> DeleteJournalGridLessonColumnsAndMarks()
        {
            var deleteMarksResult = await _columnMarksRepository.DeleteAllMarks();
            var deleteColumnsResult = await _columnsRepository.DeleteAllColumns();
            return deleteColumnsResult && deleteMarksResult;
        }

    }
}
