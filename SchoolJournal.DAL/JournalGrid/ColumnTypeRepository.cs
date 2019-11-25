namespace SchoolJournal.DAL.JournalGrid
{
    using SchoolJournal.DAL.Interfaces;
    using SchoolJournal.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ColumnTypeRepository : RepositoryBase, IColumnTypeRepository
    {
        public ColumnTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public ColumnType FindByName(string typeName)
        {
            throw new Exception("NEED TO SEED COLUMN TYPES(LESSON, EXAM etc) TO DB AND IMPLEMENT FINDBYNAME");
        }
    }
}
