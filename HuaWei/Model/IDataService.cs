using System;

namespace HuaWei.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}