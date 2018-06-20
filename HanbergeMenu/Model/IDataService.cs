using System.Threading.Tasks;

namespace HanbergeMenu.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}