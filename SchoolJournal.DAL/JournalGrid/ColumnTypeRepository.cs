namespace SchoolJournal.DAL.JournalGrid
{
    using SchoolJournal.DAL.Interfaces;
    using SchoolJournal.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Mapster;
    using System.Data.Entity;

    public class ColumnTypeRepository : RepositoryBase, IColumnTypeRepository
    {
        public ColumnTypeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        public async Task<ColumnType> FindByName(string typeName)
        {
<<<<<<< HEAD
            var columnType = await DbContext.ColumnsTypes
                .Where(ct => ct.TypeValue.Equals(typeName))
                .FirstOrDefaultAsync();


            return columnType.Adapt<ColumnType>();
        
=======
            //how to seed data to database
            throw new Exception("NEED TO SEED COLUMN TYPES(LESSON, EXAM etc) TO DB AND IMPLEMENT FINDBYNAME");
>>>>>>> 04518fc36e324843c29f48ee63898427baf89a7c
        }
    }
}         