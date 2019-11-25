namespace SchoolJournal.DAL.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain;

    public interface IColumnTypeRepository
    {
        ColumnType FindByName(string typeName);
    }
}
