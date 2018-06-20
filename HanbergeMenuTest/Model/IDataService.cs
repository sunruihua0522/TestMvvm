using System.Threading.Tasks;

namespace HanbergeMenuTest.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}