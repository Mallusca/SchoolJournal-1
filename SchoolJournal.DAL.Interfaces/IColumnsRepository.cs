

namespace SchoolJournal.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain;

    public interface IColumnsRepository
    {
        IQueryable<JournalGridColumnModel> List();

        Task<long> AddColumn(long columnTypeId, DateTime columnDate);

        Task<bool> DeleteAllColumns();
    }
}
