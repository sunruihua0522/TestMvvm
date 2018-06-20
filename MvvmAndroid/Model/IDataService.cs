using System;

namespace MvvmAndroid.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}