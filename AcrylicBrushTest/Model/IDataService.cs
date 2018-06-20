using System.Threading.Tasks;

namespace AcrylicBrushTest.Model
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}