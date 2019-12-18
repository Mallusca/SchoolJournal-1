namespace SchoolJournal.DAL.Interfaces
{
    using Domain;
    using System.Threading.Tasks;

    public interface IColumnTypeRepository
    {
        Task<ColumnType> FindByName(string typeName);
    }
}
