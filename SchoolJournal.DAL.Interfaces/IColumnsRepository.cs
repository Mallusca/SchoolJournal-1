

namespace SchoolJournal.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Domain;

    public interface IColumnsRepository
    {
        IQueryable<JournalGridColumnModel> List();

        long AddColumn(long columnTypeId, DateTime columnDate);
    }
}
