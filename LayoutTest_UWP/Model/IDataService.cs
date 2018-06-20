using System.Threading.Tasks;

namespace LayoutTest_UWP.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}